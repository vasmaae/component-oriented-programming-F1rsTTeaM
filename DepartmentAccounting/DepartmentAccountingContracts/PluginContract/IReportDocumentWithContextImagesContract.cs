namespace DepartmentAccountingContracts.PluginContract;

public interface IReportDocumentWithContextImagesContract : IReportDocumentContract
{
    Task CreateDocumentAsync(string filePath, string header, List<byte[]> images);
}
