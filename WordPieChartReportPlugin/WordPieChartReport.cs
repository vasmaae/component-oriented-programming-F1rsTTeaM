using DepartmentAccountingContracts.PluginContract;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WordPieChartReportPlugin;

public class WordPieChartReport : IReportDocumentWithChartPieContract
{
    public string DocumentFormat => "Word";

    public async Task CreateDocumentAsync(
    string filePath,
    string header,
    string chartTitle,
    string seriesName,
    List<(string Parameter, double Value)> series)
    {
        await Task.Run(() =>
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                var mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document(new Body());

                var body = mainPart.Document.Body;

                body.Append(
                    new DocumentFormat.OpenXml.Drawing.Paragraph(
                        new DocumentFormat.OpenXml.Drawing.Run(
                            new DocumentFormat.OpenXml.Drawing.Text(header)
                        )
                    )
                    {
                        ParagraphProperties = new DocumentFormat.OpenXml.Drawing.ParagraphProperties(
                            new Justification() { Val = JustificationValues.Center }
                        )
                    });

                var chartPart = mainPart.AddNewPart<ChartPart>();

                GeneratePieChartPart(chartPart, chartTitle, seriesName, series);

                var element = new Drawing(
                    new Inline(
                        new Extent() { Cx = 5486400, Cy = 3200400 },
                        new EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                        new DocProperties() { Id = (UInt32Value)1U, Name = "Pie Chart" },
                        new DocumentFormat.OpenXml.Drawing.NonVisualGraphicFrameDrawingProperties(new GraphicFrameLocks() { NoChangeAspect = true }),
                        new Graphic(
                            new GraphicData(
                                new ChartReference() { Id = mainPart.GetIdOfPart(chartPart) }
                            )
                            { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                        )
                    )
                );

                var chartParagraph = new DocumentFormat.OpenXml.Drawing.Paragraph(new DocumentFormat.OpenXml.Drawing.Run(element));
                body.Append(chartParagraph);

                mainPart.Document.Save();
            }
        });
    }

    private void GeneratePieChartPart(ChartPart chartPart, string chartTitle, string seriesName, List<(string Parameter, double Value)> series)
    {
        var chartSpace = new ChartSpace();
        chartSpace.Append(new EditingLanguage() { Val = "en-US" });

        var chart = new DocumentFormat.OpenXml.Drawing.Chart();

        var title = new Title(
            new ChartText(
                new RichText(
                    new BodyProperties(),
                    new ListStyle(),
                    new DocumentFormat.OpenXml.Drawing.Paragraph(new DocumentFormat.OpenXml.Drawing.Run(new DocumentFormat.OpenXml.Drawing.Text(chartTitle)))
                )
            )
        );

        chart.Append(title);

        var plotArea = new PlotArea();
        plotArea.Append(new Layout());

        var pieChart = new PieChart();

        var pieSeries = new PieChartSeries(
            new DocumentFormat.OpenXml.Drawing.Charts.Index() { Val = 0U },
            new Order() { Val = 0U },
            new SeriesText(new NumericValue(seriesName))
        );

        var categories = new CategoryAxisData(
            new StringLiteral(
                new PointCount() { Val = (uint)series.Count },
                (OpenXmlElement)series.Select((s, i) => new StringPoint() { Index = (uint)i, NumericValue = new NumericValue(s.Parameter) })
            )
        );

        var values = new Values(
            new NumberLiteral(
                new PointCount() { Val = (uint)series.Count },
                (OpenXmlElement)series.Select((s, i) => new NumericPoint() { Index = (uint)i, NumericValue = new NumericValue(s.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)) })
            )
        );

        pieSeries.Append(categories);
        pieSeries.Append(values);
        pieChart.Append(pieSeries);

        var legend = new Legend(
            new LegendPosition() { Val = LegendPositionValues.Right },
            new Layout()
        );

        plotArea.Append(pieChart);
        chart.Append(plotArea);
        chart.Append(legend);
        chart.Append(new PlotVisibleOnly() { Val = true });

        chartSpace.Append(chart);
        chartPart.ChartSpace = chartSpace;
        chartPart.ChartSpace.Save();
    }
}
