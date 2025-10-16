namespace DepartmentsComponent
{
    partial class DepartmentForm
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
            labelName = new Label();
            textBoxName = new TextBox();
            labelLocationScheme = new Label();
            textBoxLocationScheme = new TextBox();
            labelSpecialization = new Label();
            controlSelectedCheckedListBoxPropertySpecialization = new ControlsLibraryNet90.Selected.ControlSelectedCheckedListBoxProperty();
            labelPhoneNumber = new Label();
            controlInputRegexPhoneNumber = new ControlsLibraryNet90.Input.ControlInputRegexPhoneNumber();
            buttonOk = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 9);
            labelName.Name = "labelName";
            labelName.Size = new Size(93, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Наименование:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 27);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(247, 23);
            textBoxName.TabIndex = 1;
            textBoxName.TextChanged += TextBoxName_TextChanged;
            // 
            // labelLocationScheme
            // 
            labelLocationScheme.AutoSize = true;
            labelLocationScheme.Location = new Point(12, 53);
            labelLocationScheme.Name = "labelLocationScheme";
            labelLocationScheme.Size = new Size(129, 15);
            labelLocationScheme.TabIndex = 2;
            labelLocationScheme.Text = "Схема расположения:";
            // 
            // textBoxLocationScheme
            // 
            textBoxLocationScheme.Location = new Point(12, 71);
            textBoxLocationScheme.Name = "textBoxLocationScheme";
            textBoxLocationScheme.Size = new Size(247, 23);
            textBoxLocationScheme.TabIndex = 3;
            textBoxLocationScheme.TextChanged += TextBoxLocationScheme_TextChanged;
            // 
            // labelSpecialization
            // 
            labelSpecialization.AutoSize = true;
            labelSpecialization.Location = new Point(12, 97);
            labelSpecialization.Name = "labelSpecialization";
            labelSpecialization.Size = new Size(96, 15);
            labelSpecialization.TabIndex = 4;
            labelSpecialization.Text = "Специализация:";
            // 
            // controlSelectedCheckedListBoxPropertySpecialization
            // 
            controlSelectedCheckedListBoxPropertySpecialization.Location = new Point(12, 115);
            controlSelectedCheckedListBoxPropertySpecialization.Name = "controlSelectedCheckedListBoxPropertySpecialization";
            controlSelectedCheckedListBoxPropertySpecialization.SelectedElement = "";
            controlSelectedCheckedListBoxPropertySpecialization.Size = new Size(247, 131);
            controlSelectedCheckedListBoxPropertySpecialization.TabIndex = 5;
            controlSelectedCheckedListBoxPropertySpecialization.SelectedElementChange += ControlSelectedCheckedListBoxPropertySpecialization_SelectedElementChange;
            // 
            // labelPhoneNumber
            // 
            labelPhoneNumber.AutoSize = true;
            labelPhoneNumber.Location = new Point(12, 249);
            labelPhoneNumber.Name = "labelPhoneNumber";
            labelPhoneNumber.Size = new Size(108, 15);
            labelPhoneNumber.TabIndex = 6;
            labelPhoneNumber.Text = "Рабочий телефон:";
            // 
            // controlInputRegexPhoneNumber
            // 
            controlInputRegexPhoneNumber.Location = new Point(12, 267);
            controlInputRegexPhoneNumber.Name = "controlInputRegexPhoneNumber";
            controlInputRegexPhoneNumber.Size = new Size(247, 23);
            controlInputRegexPhoneNumber.TabIndex = 7;
            controlInputRegexPhoneNumber.Template = "^((\\+7|8)+\\(\\d{4}\\))?\\d{0,2}-\\d{0,2}-\\d{0,2}$";
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(12, 296);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(117, 23);
            buttonOk.TabIndex = 8;
            buttonOk.Text = "ОК";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += ButtonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(142, 296);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(117, 23);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // DepartmentForm
            // 
            AcceptButton = buttonOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(271, 332);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(controlInputRegexPhoneNumber);
            Controls.Add(labelPhoneNumber);
            Controls.Add(controlSelectedCheckedListBoxPropertySpecialization);
            Controls.Add(labelSpecialization);
            Controls.Add(textBoxLocationScheme);
            Controls.Add(labelLocationScheme);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Name = "DepartmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Подразделение";
            FormClosing += DepartmentForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelName;
        private TextBox textBoxName;
        private Label labelLocationScheme;
        private TextBox textBoxLocationScheme;
        private Label labelSpecialization;
        private ControlsLibraryNet90.Selected.ControlSelectedCheckedListBoxProperty controlSelectedCheckedListBoxPropertySpecialization;
        private Label labelPhoneNumber;
        private ControlsLibraryNet90.Input.ControlInputRegexPhoneNumber controlInputRegexPhoneNumber;
        private Button buttonOk;
        private Button buttonCancel;
    }
}