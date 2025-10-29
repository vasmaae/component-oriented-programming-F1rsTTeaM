namespace LabWorkAccountingProgram
{
    partial class ReportExtensionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            locationSchemesReportGroupBox = new GroupBox();
            availableDocumentFormatsComboBox1 = new ComboBox();
            downloadButton1 = new Button();
            chartBarByDepartmentsSpecializationsReportGroupBox = new GroupBox();
            availableDocumentFormatsComboBox2 = new ComboBox();
            downloadButton2 = new Button();
            locationSchemesReportGroupBox.SuspendLayout();
            chartBarByDepartmentsSpecializationsReportGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // locationSchemesReportGroupBox
            // 
            locationSchemesReportGroupBox.Controls.Add(availableDocumentFormatsComboBox1);
            locationSchemesReportGroupBox.Controls.Add(downloadButton1);
            locationSchemesReportGroupBox.Location = new Point(12, 12);
            locationSchemesReportGroupBox.Name = "locationSchemesReportGroupBox";
            locationSchemesReportGroupBox.Size = new Size(260, 83);
            locationSchemesReportGroupBox.TabIndex = 0;
            locationSchemesReportGroupBox.TabStop = false;
            locationSchemesReportGroupBox.Text = "Схемы расположения подразделений";
            // 
            // availableDocumentFormatsComboBox1
            // 
            availableDocumentFormatsComboBox1.FormattingEnabled = true;
            availableDocumentFormatsComboBox1.Location = new Point(6, 22);
            availableDocumentFormatsComboBox1.Name = "availableDocumentFormatsComboBox1";
            availableDocumentFormatsComboBox1.Size = new Size(248, 23);
            availableDocumentFormatsComboBox1.TabIndex = 1;
            // 
            // downloadButton1
            // 
            downloadButton1.Location = new Point(6, 51);
            downloadButton1.Name = "downloadButton1";
            downloadButton1.Size = new Size(248, 23);
            downloadButton1.TabIndex = 0;
            downloadButton1.Text = "Скачать";
            downloadButton1.UseVisualStyleBackColor = true;
            downloadButton1.Click += DownloadButton1_Click;
            // 
            // chartBarByDepartmentsSpecializationsReportGroupBox
            // 
            chartBarByDepartmentsSpecializationsReportGroupBox.Controls.Add(availableDocumentFormatsComboBox2);
            chartBarByDepartmentsSpecializationsReportGroupBox.Controls.Add(downloadButton2);
            chartBarByDepartmentsSpecializationsReportGroupBox.Location = new Point(12, 101);
            chartBarByDepartmentsSpecializationsReportGroupBox.Name = "chartBarByDepartmentsSpecializationsReportGroupBox";
            chartBarByDepartmentsSpecializationsReportGroupBox.Size = new Size(260, 83);
            chartBarByDepartmentsSpecializationsReportGroupBox.TabIndex = 1;
            chartBarByDepartmentsSpecializationsReportGroupBox.TabStop = false;
            chartBarByDepartmentsSpecializationsReportGroupBox.Text = "Подразделения и специализации";
            // 
            // availableDocumentFormatsComboBox2
            // 
            availableDocumentFormatsComboBox2.FormattingEnabled = true;
            availableDocumentFormatsComboBox2.Location = new Point(6, 22);
            availableDocumentFormatsComboBox2.Name = "availableDocumentFormatsComboBox2";
            availableDocumentFormatsComboBox2.Size = new Size(248, 23);
            availableDocumentFormatsComboBox2.TabIndex = 1;
            // 
            // downloadButton2
            // 
            downloadButton2.Location = new Point(6, 51);
            downloadButton2.Name = "downloadButton2";
            downloadButton2.Size = new Size(248, 23);
            downloadButton2.TabIndex = 0;
            downloadButton2.Text = "Скачать";
            downloadButton2.UseVisualStyleBackColor = true;
            downloadButton2.Click += DownloadButton2_Click;
            // 
            // ReportExtensionsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 194);
            Controls.Add(chartBarByDepartmentsSpecializationsReportGroupBox);
            Controls.Add(locationSchemesReportGroupBox);
            Name = "ReportExtensionsForm";
            Text = "Расширения";
            locationSchemesReportGroupBox.ResumeLayout(false);
            chartBarByDepartmentsSpecializationsReportGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox locationSchemesReportGroupBox;
        private ComboBox availableDocumentFormatsComboBox1;
        private Button downloadButton1;
        private GroupBox chartBarByDepartmentsSpecializationsReportGroupBox;
        private ComboBox availableDocumentFormatsComboBox2;
        private Button downloadButton2;
    }
}