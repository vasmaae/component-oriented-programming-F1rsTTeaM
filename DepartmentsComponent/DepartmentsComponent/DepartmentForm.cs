using DepartmentAccountingContracts.Models;
using DepartmentAccountingContracts.Repository;
using System.ComponentModel;

namespace DepartmentsComponent;

public partial class DepartmentForm : Form
{
    private Guid? _departmentId;
    private bool _hasUnsavedChanges = false;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Guid Id
    {
        set
        {
            var department = SharedRepository.Departments.GetById(value);
            if (department is null) return;

            textBoxName.Text = department.Name;
            textBoxLocationScheme.Text = department.LocationScheme;
            controlSelectedCheckedListBoxPropertySpecialization.SelectedElement = department.Specialization;
            controlInputRegexPhoneNumber.Value = department.PhoneNumber;

            _departmentId = value;
        }
    }

    public DepartmentForm()
    {
        InitializeComponent();

        controlSelectedCheckedListBoxPropertySpecialization.Items.Clear();
        var specializations = SharedRepository.Specializations.GetAll();
        foreach (var specialization in specializations)
            controlSelectedCheckedListBoxPropertySpecialization.Items.Add(specialization.Name);

        controlInputRegexPhoneNumber.Template = "^\\d-\\d-\\d{2}$";
        controlInputRegexPhoneNumber.SetToolTip("9-9-99");
    }

    private void ButtonOk_Click(object sender, EventArgs e)
    {
        Save();
        Close();
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void DepartmentForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_hasUnsavedChanges)
        {
            var result = MessageBox.Show(
                "У вас есть несохраненные изменения. Вы хотите сохранить их?",
                "Предупреждение",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Save();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            _hasUnsavedChanges = false;
        }
    }

    private void Save()
    {
        try
        {
            if (string.IsNullOrEmpty(controlSelectedCheckedListBoxPropertySpecialization.SelectedElement) ||
                string.IsNullOrEmpty(controlInputRegexPhoneNumber.Value))
            {
                MessageBox.Show("Данные не корректны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_departmentId is not null)
            {
                SharedRepository.Departments.Update(
                    new Department
                    {
                        Id = _departmentId ?? Guid.NewGuid(),
                        Name = textBoxName.Text,
                        LocationScheme = textBoxLocationScheme.Text,
                        Specialization = controlSelectedCheckedListBoxPropertySpecialization.SelectedElement,
                        PhoneNumber = controlInputRegexPhoneNumber.Value
                    });
            }
            else
            {
                SharedRepository.Departments.Add(
                    new Department
                    {
                        Name = textBoxName.Text,
                        LocationScheme = textBoxLocationScheme.Text,
                        Specialization = controlSelectedCheckedListBoxPropertySpecialization.SelectedElement,
                        PhoneNumber = controlInputRegexPhoneNumber.Value
                    });
            }
            _hasUnsavedChanges = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TextBoxName_TextChanged(object sender, EventArgs e) => _hasUnsavedChanges = _departmentId is not null;

    private void TextBoxLocationScheme_TextChanged(object sender, EventArgs e) => _hasUnsavedChanges = _departmentId is not null;

    private void ControlSelectedCheckedListBoxPropertySpecialization_SelectedElementChange(object sender, EventArgs e) =>
        _hasUnsavedChanges = _departmentId is not null;
}