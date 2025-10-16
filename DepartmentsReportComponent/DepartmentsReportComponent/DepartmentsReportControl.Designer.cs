namespace DepartmentsReportComponent
{
    partial class DepartmentsReportControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            departmentsReportDataGridView = new DataGridView();
            specializationComboBox = new ComboBox();
            applyButton = new Button();
            ((System.ComponentModel.ISupportInitialize)departmentsReportDataGridView).BeginInit();
            SuspendLayout();
            // 
            // departmentsReportDataGridView
            // 
            departmentsReportDataGridView.AllowUserToAddRows = false;
            departmentsReportDataGridView.AllowUserToDeleteRows = false;
            departmentsReportDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            departmentsReportDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            departmentsReportDataGridView.Dock = DockStyle.Bottom;
            departmentsReportDataGridView.Location = new Point(0, 32);
            departmentsReportDataGridView.Name = "departmentsReportDataGridView";
            departmentsReportDataGridView.ReadOnly = true;
            departmentsReportDataGridView.RowHeadersVisible = false;
            departmentsReportDataGridView.Size = new Size(240, 170);
            departmentsReportDataGridView.TabIndex = 0;
            // 
            // specializationComboBox
            // 
            specializationComboBox.FormattingEnabled = true;
            specializationComboBox.Location = new Point(3, 3);
            specializationComboBox.Name = "specializationComboBox";
            specializationComboBox.Size = new Size(121, 23);
            specializationComboBox.TabIndex = 1;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(130, 3);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(107, 23);
            applyButton.TabIndex = 2;
            applyButton.Text = "Сформировать";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += ApplyButton_Click;
            // 
            // DepartmentsReportControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(applyButton);
            Controls.Add(specializationComboBox);
            Controls.Add(departmentsReportDataGridView);
            Name = "DepartmentsReportControl";
            Size = new Size(240, 202);
            ((System.ComponentModel.ISupportInitialize)departmentsReportDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView departmentsReportDataGridView;
        private ComboBox specializationComboBox;
        private Button applyButton;
    }
}
