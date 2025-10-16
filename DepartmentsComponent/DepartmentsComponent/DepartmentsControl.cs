using ControlsLibraryNet90.Models;
using DepartmentAccountingContracts.Models;
using DepartmentAccountingContracts.Repository;
using System.ComponentModel;

namespace DepartmentsComponent;

public partial class DepartmentsControl : UserControl
{
    private readonly BindingList<Department> _departments;

    public DepartmentsControl()
    {
        InitializeComponent();
        SharedRepository.Departments.DataChanged += LoadData;
        _departments = [];
        List<DataTableColumnConfig> columnConfigList = [
            new DataTableColumnConfig { ColumnHeader = "Идентификатор", MemberName = "Id", UseProperites = true, Visible = false },
            new DataTableColumnConfig { ColumnHeader = "Наименование", MemberName = "Name", UseProperites = true, Visible = true },
            new DataTableColumnConfig { ColumnHeader = "Схема расположения", MemberName = "LocationScheme", UseProperites = true, Visible = true },
            new DataTableColumnConfig { ColumnHeader = "Специализация", MemberName = "Specialization", UseProperites = true, Visible = true },
            new DataTableColumnConfig { ColumnHeader = "Рабочий телефон", MemberName = "PhoneNumber", UseProperites = true, Visible = true }
            ];
        departmentsDataTableCell.LoadColumns(columnConfigList);
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            _departments.Clear();
            var data = SharedRepository.Departments.GetAll();
            foreach (var item in data)
                _departments.Add(item);

            departmentsDataTableCell.Clear();
            for (int i = 0; i < _departments.Count; i++)
                for (int j = 0; j < 5; j++)
                    departmentsDataTableCell.AddCell(i, j, _departments[i]);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _departments.RaiseListChangedEvents = true;
            _departments.ResetBindings();

        }
    }

    private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DepartmentForm departmentForm = new();
        departmentForm.ShowDialog();
        LoadData();
    }

    private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        DepartmentForm departmentForm = new();
        departmentForm.Id = departmentsDataTableCell.GetSelectedObject<Department>().Id;
        departmentForm.ShowDialog();
        LoadData();
    }

    private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;
        SharedRepository.Departments.Delete(departmentsDataTableCell.GetSelectedObject<Department>().Id);
    }
}
