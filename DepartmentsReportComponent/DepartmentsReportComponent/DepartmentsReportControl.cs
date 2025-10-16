using DepartmentAccountingContracts.Models;
using DepartmentAccountingContracts.Repository;

namespace DepartmentsReportComponent;

public partial class DepartmentsReportControl : UserControl
{
    private List<Department> _filtredDepartments = [];

    public DepartmentsReportControl()
    {
        InitializeComponent();
        specializationComboBox.Items.AddRange([.. SharedRepository.Specializations.GetAll().Select(x => x.Name)]);
        specializationComboBox.SelectedIndex = 0;
        departmentsReportDataGridView.DataSource = _filtredDepartments;
    }

    private void ApplyButton_Click(object sender, EventArgs e)
    {
        if (specializationComboBox.SelectedItem is null)
            MessageBox.Show("Выберите специализацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        _filtredDepartments = SharedRepository.Departments.GetAll().Where(x => x.Specialization == specializationComboBox.SelectedItem).ToList();
        departmentsReportDataGridView.DataSource = _filtredDepartments;
        departmentsReportDataGridView.Columns["Id"]!.Visible = false;
    }
}
