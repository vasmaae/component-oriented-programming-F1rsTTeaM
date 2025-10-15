using DepartmentAccountingContracts.Models;
using DepartmentAccountingContracts.Repository;
using System.ComponentModel;

namespace SpecializationsComponent;

public partial class SpecializationsControl : UserControl
{
    private readonly BindingList<Specialization> _specializations;

    public SpecializationsControl()
    {
        InitializeComponent();
        SharedRepository.Specializations.DataChanged += LoadData;
        _specializations = [];

        specializationsDataGridView.DataSource = _specializations;
        specializationsDataGridView.Columns["Id"]!.Visible = false;
        specializationsDataGridView.Columns["Name"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        specializationsDataGridView.AllowUserToAddRows = false;
        specializationsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        specializationsDataGridView.MultiSelect = true;
        LoadData();
    }

    private void LoadData()
    {
        try
        {
            _specializations.Clear();
            var data = SharedRepository.Specializations.GetAll();
            foreach (var item in data)
                _specializations.Add(item);
        }
        finally
        {
            _specializations.RaiseListChangedEvents = true;
            _specializations.ResetBindings();
        }
    }

    private void SpecializationsDataGridView_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Insert:
                try
                {
                    _specializations.Add(new Specialization());
                    specializationsDataGridView.CurrentCell = specializationsDataGridView.Rows[specializationsDataGridView.Rows.Count - 1].Cells[0];
                    specializationsDataGridView.BeginEdit(false);
                    e.Handled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                break;
            case Keys.Delete:
                var selectedRows = specializationsDataGridView.SelectedRows;
                if (selectedRows.Count > 0 &&
                    MessageBox.Show($"Вы уверены, что хотите удалить выбранные записи? ({selectedRows.Count})",
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    var idsToRemove = new List<Guid>();
                    foreach (DataGridViewRow row in selectedRows)
                    {
                        var severity = row.DataBoundItem as Specialization;
                        if (severity is not null)
                            idsToRemove.Add(severity.Id);
                        _specializations.Remove(severity);
                    }
                    if (idsToRemove.Count > 0)
                        SharedRepository.Specializations.Delete(idsToRemove);
                    e.Handled = true;
                }
                break;
        }
    }

    private void SpecializationsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            var editedSeverity = specializationsDataGridView.Rows[e.RowIndex].DataBoundItem as Specialization;
            var editedCell = specializationsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (editedCell.Value is string value)
                if (!string.IsNullOrEmpty(value.Trim()))
                {
                    if (SharedRepository.Specializations.GetById(editedSeverity.Id) is not null)
                        SharedRepository.Specializations.Update(editedSeverity);
                    else
                        SharedRepository.Specializations.Add(editedSeverity);
                }
                else
                {
                    SharedRepository.Specializations.Delete(editedSeverity.Id);
                }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message} {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            LoadData();
        }
    }
}
