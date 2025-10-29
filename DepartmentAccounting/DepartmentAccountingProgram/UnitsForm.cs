using DepartmentAccountingContracts.ComponentContracts;
using DepartmentAccountingContracts.Enums;
using LabWorkAccountingProgram;
using System.Configuration;
using System.Reflection;

namespace DepartmentAccountingProgram;

public partial class UnitsForm : Form
{
    private readonly Dictionary<ComponentCategory, ToolStripMenuItem> _typeMenus = [];
    private readonly List<IComponentContract> _loadedComponents = [];
    private LicenseLevel _licenseLevel;

    public UnitsForm()
    {
        InitializeComponent();
        LoadLicenseLevel();
        LoadComponents();
        BuildMenu();
        LoadPlugins();
    }

    private void LoadLicenseLevel()
    {
        try
        {
            string? licensePath = ConfigurationManager.AppSettings["LicensePath"];
            if (string.IsNullOrEmpty(licensePath) || !File.Exists(licensePath))
            {
                MessageBox.Show($"���� �������� �� ������ ��� ���� � ����� �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _licenseLevel = LicenseLevel.Minimal;
                return;
            }

            var licenseLevel = File.ReadAllText(licensePath).Trim();
            _licenseLevel = licenseLevel switch
            {
                "Minimal" => LicenseLevel.Minimal,
                "Basic" => LicenseLevel.Basic,
                "Advanced" => LicenseLevel.Advanced,
                _ => LicenseLevel.Minimal,
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show($"������ ��� �������� ��������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _licenseLevel = LicenseLevel.Minimal;
        }
    }

    private void LoadComponents()
    {
        try
        {
            string? librariesPath = ConfigurationManager.AppSettings["ComponentsLibrariesPath"];
            if (string.IsNullOrEmpty(librariesPath) || !Directory.Exists(librariesPath))
            {
                MessageBox.Show($"���������� �� ������� �� ���������� ���� ��� ���� �� ������ ({librariesPath})", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dllFiles = Directory.GetFiles(librariesPath, "*.dll");
            foreach (var dll in dllFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dll);
                    var types = assembly.GetTypes()
                        .Where(t => typeof(IComponentContract).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                    foreach (var type in types)
                    {
                        var component = Activator.CreateInstance(type) as IComponentContract;
                        if (component is not null && IsComponentAllowed(component.Type))
                            _loadedComponents.Add(component);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"������ ��� �������� ������ {Path.GetFileName(dll)}: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"������ ��� �������� �����������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool IsComponentAllowed(ComponentType componentType)
    {
        return _licenseLevel switch
        {
            LicenseLevel.Minimal => componentType == ComponentType.Specialization,
            LicenseLevel.Basic => componentType == ComponentType.Specialization || componentType == ComponentType.Department,
            LicenseLevel.Advanced => componentType == ComponentType.Specialization || componentType == ComponentType.Department || componentType == ComponentType.DepartmentReport,
            _ => false,
        };
    }

    private void BuildMenu()
    {
        var directoriesMenu = new ToolStripMenuItem("�����������");
        var reportsMenu = new ToolStripMenuItem("������");

        _typeMenus[ComponentCategory.Entity] = directoriesMenu;
        _typeMenus[ComponentCategory.Report] = reportsMenu;

        menuStrip.Items.Add(directoriesMenu);
        menuStrip.Items.Add(reportsMenu);

        foreach (var component in _loadedComponents)
        {
            if (_typeMenus.TryGetValue(component.Category, out var categoryMenu))
            {
                var subItem = new ToolStripMenuItem(component.DisplayName);
                subItem.Tag = component;
                subItem.Click += SubMenuItem_Click;
                categoryMenu.DropDownItems.Add(subItem);
            }
        }
    }

    private void LoadPlugins()
    {
        try
        {
            var extensionsMenuItem = new ToolStripMenuItem("Расширения");
            _typeMenus[ComponentCategory.Report].DropDownItems.Add(extensionsMenuItem);
            extensionsMenuItem.Click += (sender, e) =>
            {
                var reportExtensionsForm = new ReportExtensionsForm();
                reportExtensionsForm.ShowDialog();
            };
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке плагинов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void SubMenuItem_Click(object sender, EventArgs e)
    {
        if (sender is ToolStripMenuItem menuItem && menuItem.Tag is IComponentContract component)
        {
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Text == component.DisplayName)
                {
                    tabControl.SelectedTab = tab;
                    return;
                }
            }

            var tabPage = new TabPage(component.DisplayName);
            var control = component.Control;
            control.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;
        }
    }

    private void TabControl_DoubleClick(object sender, EventArgs e)
    {
        if (tabControl.SelectedTab is null)
            return;
        tabControl.TabPages.Remove(tabControl.SelectedTab);
    }
}
