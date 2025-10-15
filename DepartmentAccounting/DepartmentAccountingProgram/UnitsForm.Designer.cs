namespace DepartmentAccountingProgram;

partial class UnitsForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        menuStrip = new MenuStrip();
        tabControl = new TabControl();
        SuspendLayout();
        // 
        // menuStrip
        // 
        menuStrip.Location = new Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(800, 24);
        menuStrip.TabIndex = 1;
        menuStrip.Text = "menuStrip1";
        // 
        // tabControl
        // 
        tabControl.Dock = DockStyle.Fill;
        tabControl.Location = new Point(0, 24);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(800, 426);
        tabControl.TabIndex = 0;
        tabControl.DoubleClick += TabControl_DoubleClick;
        // 
        // LabsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(tabControl);
        Controls.Add(menuStrip);
        Name = "LabsForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Учёт лабораторных работ";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private MenuStrip menuStrip;
    private TabControl tabControl;

}
