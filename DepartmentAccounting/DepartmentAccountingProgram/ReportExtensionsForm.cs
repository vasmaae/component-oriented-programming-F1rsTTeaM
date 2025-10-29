using DepartmentAccountingContracts.PluginContract;
using DepartmentAccountingContracts.Repository;
using System.Configuration;
using System.Reflection;

namespace LabWorkAccountingProgram;

public partial class ReportExtensionsForm : Form
{
    private readonly List<Type> _loadedTypes = [];
    private readonly Dictionary<(string, string), dynamic> _loadedPlugins = [];
    private Type? _contractType = null;
    private const string _textReport = "ReportDocumentWithContextTexts";
    private const string _chartPieReport = "ReportDocumentWithChartBar";

    public ReportExtensionsForm()
    {
        InitializeComponent();
        LoadPlugins();
        BuildComboBoxes();
    }

    private void LoadPlugins()
    {
        try
        {
            string? librariesPath = ConfigurationManager.AppSettings["PluginsLibrariesPath"];
            if (string.IsNullOrEmpty(librariesPath) || !Directory.Exists(librariesPath))
            {
                MessageBox.Show($"Плагины не найдены по указанному пути или путь не указан ({librariesPath})", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string assemblyName = new AssemblyName(args.Name).Name + ".dll";
                string assemblyPath = Path.Combine(librariesPath, assemblyName);

                if (File.Exists(assemblyPath))
                    return Assembly.LoadFrom(assemblyPath);

                return null;
            };

            var dllFiles = Directory.GetFiles(librariesPath, "*.dll");

            foreach (var dll in dllFiles)
            {
                var assembly = Assembly.LoadFrom(dll);
                if (assembly.GetTypes().Any(t => t.IsInterface && t.Name == nameof(IReportDocumentContract)))
                {
                    _contractType = assembly.GetTypes().First(t => t.IsInterface && t.Name == nameof(IReportDocumentContract));
                    break;
                }
            }

            if (_contractType is null)
                return;

            foreach (var dll in dllFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);

                    var types = assembly.GetTypes()
                        .Where(t => t.IsClass && !t.IsAbstract && _contractType.IsAssignableFrom(t));

                    foreach (var type in types)
                        _loadedTypes.Add(type);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке сборки {Path.GetFileName(dll)}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке плагинов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BuildComboBoxes()
    {
        foreach (var type in _loadedTypes)
        {
            if (type.Name.StartsWith(_textReport))
            {
                dynamic? plugin = Activator.CreateInstance(type) ?? null;
                if (plugin is not null)
                {
                    availableDocumentFormatsComboBox1.Items.Add(plugin.DocumentFormat);
                    _loadedPlugins[(plugin.DocumentFormat, _textReport)] = plugin;
                }
            }
            if (type.Name.StartsWith(_chartPieReport))
            {
                dynamic? plugin = Activator.CreateInstance(type) ?? null;
                if (plugin is not null)
                {
                    availableDocumentFormatsComboBox2.Items.Add(plugin.DocumentFormat);
                    _loadedPlugins[(plugin.DocumentFormat, _chartPieReport)] = plugin;
                }
            }
        }
    }

    private void DownloadButton1_Click(object sender, EventArgs e)
    {
        try
        {
            string fileFormat = availableDocumentFormatsComboBox1.SelectedItem as string ?? "";
            string filePath = ShowSaveFileDialog(fileFormat);
            if (!string.IsNullOrEmpty(filePath))
            {
                _loadedPlugins[(fileFormat, _textReport)]
                    .CreateDocumentAsync(filePath, "Отчёт о схемах расположения подразделений",
                    SharedRepository.Departments.GetAll()
                    .Select(l => $"{l.Name}: {l.LocationScheme}").
                    ToList()
                    );
                MessageBox.Show($"Файл сохранён как: {filePath}");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DownloadButton2_Click(object sender, EventArgs e)
    {
        try
        {
            string fileFormat = availableDocumentFormatsComboBox2.SelectedItem as string ?? "";
            string filePath = ShowSaveFileDialog(fileFormat);
            if (!string.IsNullOrEmpty(filePath))
            {
                var series = SharedRepository.Departments.GetAll()
                    .GroupBy(l => l.Specialization)
                    .Select(g => (Parameter: g.Key, Value: (double)g.Count()))
                    .ToList();
                _loadedPlugins[(fileFormat, _chartPieReport)]
                    .CreateDocumentAsync(
                    filePath,
                    "Отчёт о подразделениях и специализациях",
                    "Распределение по специализациям",
                    "Специализация",
                    series);
                MessageBox.Show($"Файл сохранён как: {filePath}");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DownloadButton3_Click(object sender, EventArgs e)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static string ShowSaveFileDialog(string format)
    {

        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = format switch
            {
                "Pdf" => "Файл Pdf|*.pdf",
                "Excel" => "Файл Excel|*.xlsx",
                "Word" => "Файл Word|*.docx",
                _ => ""
            };
            saveFileDialog.Title = "Сохранить файл";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
        }
        return string.Empty;
    }
}
