using DepartmentAccountingContracts.PluginContract;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes.Charts;
using MigraDoc.Rendering;

namespace PdfPieChartReportPlugin;

public class PdfPieChartReport : IReportDocumentWithChartPieContract
{
    public string DocumentFormat => "Pdf";

    public async Task CreateDocumentAsync(string filePath, string header, string chartTitle, string seriesName, List<(string Parameter, double Value)> series)
    {
        var document = new Document();
        document.AddSection().AddParagraph(header, "NormalBold");
        var chart = new Chart(ChartType.Pie2D);
        var chartSeries = chart.SeriesCollection.AddSeries();
        chartSeries.Add([.. series.Select(x => x.Value)]);

        var xseries = chart.XValues.AddXSeries();
        xseries.Add([.. series.Select(x => x.Parameter)]);

        chart.DataLabel.Type = DataLabelType.Percent;
        chart.DataLabel.Position = DataLabelPosition.OutsideEnd;

        chart.Width = Unit.FromCentimeter(16);
        chart.Height = Unit.FromCentimeter(12);

        chart.TopArea.AddParagraph(chartTitle);

        chart.XAxis.MajorTickMark = TickMarkType.Outside;

        chart.YAxis.MajorTickMark = TickMarkType.Outside;
        chart.YAxis.HasMajorGridlines = true;

        chart.PlotArea.LineFormat.Width = 1;
        chart.PlotArea.LineFormat.Visible = true;

        chart.TopArea.AddLegend();

        document.LastSection.Add(chart);

        var renderer = new PdfDocumentRenderer(true)
        {
            Document = document
        };
        renderer.RenderDocument();
        renderer.PdfDocument.Save(filePath);
    }
}
