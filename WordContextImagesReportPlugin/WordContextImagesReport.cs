using DepartmentAccountingContracts.PluginContract;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace WordContextImagesReportPlugin;

public class WordContextImagesReport : IReportDocumentWithContextImagesContract
{
    public string DocumentFormat => "Word";

    public async Task CreateDocumentAsync(string filePath, string header, List<byte[]> images)
    {
        using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
        {
            MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
            mainPart.Document = new Document();
            mainPart.Document.Body = new Body();

            mainPart.AddNewPart<StyleDefinitionsPart>().Styles = GenerateDefaultStyles();

            if (!string.IsNullOrWhiteSpace(header))
            {
                Paragraph headerParagraph = new Paragraph(
                    new ParagraphProperties(
                        new ParagraphStyleId() { Val = "Heading1" }
                    ),
                    new Run(
                        new Text(header)
                    )
                );
                mainPart.Document.Body.AppendChild(headerParagraph);
            }

            foreach (var imageBytes in images)
            {
                if (imageBytes == null || imageBytes.Length == 0)
                    continue;

                PartTypeInfo imageType = GetImagePartType(imageBytes);

                ImagePart imagePart = mainPart.AddImagePart(imageType);
                using (var stream = new MemoryStream(imageBytes))
                {
                    imagePart.FeedData(stream);
                }

                AddImageToBody(mainPart, mainPart.GetIdOfPart(imagePart));
            }

            mainPart.Document.Save();
        }
    }

    private static void AddImageToBody(MainDocumentPart mainPart, string relationshipId)
    {
        long widthEmu = 5000000L;
        long heightEmu = 4000000L;

        var element = new Drawing(
            new DW.Inline(
                new DW.Extent { Cx = widthEmu, Cy = heightEmu },
                new DW.EffectExtent { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                new DW.DocProperties { Id = (UInt32Value)1U, Name = "Picture" },
                new DW.NonVisualGraphicFrameDrawingProperties(
                    new A.GraphicFrameLocks { NoChangeAspect = true }),
                new A.Graphic(
                    new A.GraphicData(
                        new PIC.Picture(
                            new PIC.NonVisualPictureProperties(
                                new PIC.NonVisualDrawingProperties { Id = (UInt32Value)0U, Name = "Image" },
                                new PIC.NonVisualPictureDrawingProperties()
                            ),
                            new PIC.BlipFill(
                                new A.Blip
                                {
                                    Embed = relationshipId,
                                    CompressionState = A.BlipCompressionValues.Print
                                },
                                new A.Stretch(new A.FillRectangle())
                            ),
                            new PIC.ShapeProperties(
                                new A.Transform2D(
                                    new A.Offset { X = 0L, Y = 0L },
                                    new A.Extents { Cx = widthEmu, Cy = heightEmu }
                                ),
                                new A.PresetGeometry(new A.AdjustValueList())
                                {
                                    Preset = A.ShapeTypeValues.Rectangle
                                }
                            )
                        )
                    )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }
                )
            )
            {
                DistanceFromTop = 0U,
                DistanceFromBottom = 0U,
                DistanceFromLeft = 0U,
                DistanceFromRight = 0U
            });

        var paragraph = new Paragraph(new Run(element));
        mainPart.Document.Body.AppendChild(paragraph);
    }

    private static PartTypeInfo GetImagePartType(byte[] imageBytes)
    {
        if (imageBytes.Length < 4)
            return ImagePartType.Jpeg;
        if (imageBytes[0] == 0xFF && imageBytes[1] == 0xD8 && imageBytes[2] == 0xFF)
            return ImagePartType.Jpeg;
        if (imageBytes[0] == 0x89 && imageBytes[1] == 0x50 && imageBytes[2] == 0x4E && imageBytes[3] == 0x47)
            return ImagePartType.Png;

        return ImagePartType.Jpeg;
    }

    private static Styles GenerateDefaultStyles()
    {
        return new Styles(
            new Style
            {
                Type = StyleValues.Paragraph,
                StyleId = "Heading1",
                StyleName = new StyleName { Val = "heading 1" },
                StyleParagraphProperties = new StyleParagraphProperties(
                    new SpacingBetweenLines { Line = "240", LineRule = LineSpacingRuleValues.Auto },
                    new Indentation { FirstLine = "0" }
                ),
                StyleRunProperties = new StyleRunProperties(
                    new RunFonts { Ascii = "Arial", HighAnsi = "Arial" },
                    new Bold(),
                    new FontSize { Val = "32" },
                    new DocumentFormat.OpenXml.Office2013.Word.Color { Val = "2E74B5" }
                )
            }
        );
    }
}
