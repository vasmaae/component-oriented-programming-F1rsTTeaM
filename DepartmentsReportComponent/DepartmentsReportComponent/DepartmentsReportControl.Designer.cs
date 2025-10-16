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
            departmentsReportGroupBox = new GroupBox();
            specializationLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)departmentsReportDataGridView).BeginInit();
            departmentsReportGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // departmentsReportDataGridView
            // 
            departmentsReportDataGridView.AllowUserToAddRows = false;
            departmentsReportDataGridView.AllowUserToDeleteRows = false;
            departmentsReportDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            departmentsReportDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            departmentsReportDataGridView.Dock = DockStyle.Fill;
            departmentsReportDataGridView.Location = new Point(3, 19);
            departmentsReportDataGridView.Name = "departmentsReportDataGridView";
            departmentsReportDataGridView.ReadOnly = true;
            departmentsReportDataGridView.RowHeadersVisible = false;
            departmentsReportDataGridView.Size = new Size(585, 272);
            departmentsReportDataGridView.TabIndex = 0;
            // 
            // specializationComboBox
            // 
            specializationComboBox.FormattingEnabled = true;
            specializationComboBox.Location = new Point(3, 18);
            specializationComboBox.Name = "specializationComboBox";
            specializationComboBox.Size = new Size(150, 23);
            specializationComboBox.TabIndex = 1;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(3, 47);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(150, 23);
            applyButton.TabIndex = 2;
            applyButton.Text = "Сформировать";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += ApplyButton_Click;
            // 
            // departmentsReportGroupBox
            // 
            departmentsReportGroupBox.Controls.Add(departmentsReportDataGridView);
            departmentsReportGroupBox.Dock = DockStyle.Right;
            departmentsReportGroupBox.Location = new Point(159, 0);
            departmentsReportGroupBox.Name = "departmentsReportGroupBox";
            departmentsReportGroupBox.Size = new Size(591, 294);
            departmentsReportGroupBox.TabIndex = 3;
            departmentsReportGroupBox.TabStop = false;
            departmentsReportGroupBox.Text = "Отчёт по подразделениям";
            // 
            // specializationLabel
            // 
            specializationLabel.AutoSize = true;
            specializationLabel.Location = new Point(3, 0);
            specializationLabel.Name = "specializationLabel";
            specializationLabel.Size = new Size(93, 15);
            specializationLabel.TabIndex = 4;
            specializationLabel.Text = "Специализация";
            // 
            // DepartmentsReportControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(specializationLabel);
            Controls.Add(departmentsReportGroupBox);
            Controls.Add(applyButton);
            Controls.Add(specializationComboBox);
            Name = "DepartmentsReportControl";
            Size = new Size(750, 294);
            ((System.ComponentModel.ISupportInitialize)departmentsReportDataGridView).EndInit();
            departmentsReportGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView departmentsReportDataGridView;
        private ComboBox specializationComboBox;
        private Button applyButton;
        private GroupBox departmentsReportGroupBox;
        private Label specializationLabel;
    }
}
