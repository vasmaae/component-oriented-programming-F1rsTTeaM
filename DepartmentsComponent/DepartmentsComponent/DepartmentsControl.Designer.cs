namespace DepartmentsComponent
{
    partial class DepartmentsControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            departmentsDataTableCell = new ControlsLibraryNet90.Data.ControlDataTableCell();
            menuStrip1 = new MenuStrip();
            createToolStripMenuItem = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // departmentsDataTableCell
            // 
            departmentsDataTableCell.Dock = DockStyle.Fill;
            departmentsDataTableCell.Location = new Point(0, 24);
            departmentsDataTableCell.Name = "departmentsDataTableCell";
            departmentsDataTableCell.Size = new Size(240, 150);
            departmentsDataTableCell.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { createToolStripMenuItem, updateToolStripMenuItem, deleteToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(240, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            createToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            createToolStripMenuItem.Size = new Size(71, 20);
            createToolStripMenuItem.Text = "Добавить";
            createToolStripMenuItem.Click += CreateToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.U;
            updateToolStripMenuItem.Size = new Size(99, 20);
            updateToolStripMenuItem.Text = "Редактировать";
            updateToolStripMenuItem.Click += UpdateToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            deleteToolStripMenuItem.Size = new Size(63, 20);
            deleteToolStripMenuItem.Text = "Удалить";
            deleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // DepartmentsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(departmentsDataTableCell);
            Controls.Add(menuStrip1);
            Name = "DepartmentsControl";
            Size = new Size(240, 174);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ControlsLibraryNet90.Data.ControlDataTableCell departmentsDataTableCell;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem createToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}
