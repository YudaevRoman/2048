
namespace CourseWorkOOP2048
{
    partial class Game2048
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game2048));
            this.lShowScore = new System.Windows.Forms.Label();
            this.lScore = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьНовуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повторитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pPlayingField = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lShowScore
            // 
            this.lShowScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lShowScore.Location = new System.Drawing.Point(350, 32);
            this.lShowScore.MaximumSize = new System.Drawing.Size(70, 24);
            this.lShowScore.Name = "lShowScore";
            this.lShowScore.Size = new System.Drawing.Size(67, 24);
            this.lShowScore.TabIndex = 1;
            this.lShowScore.Text = "0";
            this.lShowScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lScore
            // 
            this.lScore.AutoSize = true;
            this.lScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lScore.Location = new System.Drawing.Point(265, 32);
            this.lScore.Name = "lScore";
            this.lScore.Size = new System.Drawing.Size(79, 24);
            this.lScore.TabIndex = 2;
            this.lScore.Text = "Score:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.действияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.начатьНовуюToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // начатьНовуюToolStripMenuItem
            // 
            this.начатьНовуюToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("начатьНовуюToolStripMenuItem.Image")));
            this.начатьНовуюToolStripMenuItem.Name = "начатьНовуюToolStripMenuItem";
            this.начатьНовуюToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.начатьНовуюToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.начатьНовуюToolStripMenuItem.Text = "Новая игра";
            this.начатьНовуюToolStripMenuItem.Click += new System.EventHandler(this.начатьНовуюToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("выходToolStripMenuItem.Image")));
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // действияToolStripMenuItem
            // 
            this.действияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вернутьToolStripMenuItem,
            this.повторитьToolStripMenuItem});
            this.действияToolStripMenuItem.Name = "действияToolStripMenuItem";
            this.действияToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.действияToolStripMenuItem.Text = "Действия";
            // 
            // вернутьToolStripMenuItem
            // 
            this.вернутьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("вернутьToolStripMenuItem.Image")));
            this.вернутьToolStripMenuItem.Name = "вернутьToolStripMenuItem";
            this.вернутьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.вернутьToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.вернутьToolStripMenuItem.Text = "Отменить";
            this.вернутьToolStripMenuItem.Click += new System.EventHandler(this.вернутьToolStripMenuItem_Click);
            // 
            // повторитьToolStripMenuItem
            // 
            this.повторитьToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("повторитьToolStripMenuItem.Image")));
            this.повторитьToolStripMenuItem.Name = "повторитьToolStripMenuItem";
            this.повторитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.повторитьToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.повторитьToolStripMenuItem.Text = "Повторить";
            this.повторитьToolStripMenuItem.Click += new System.EventHandler(this.повторитьToolStripMenuItem_Click);
            // 
            // pPlayingField
            // 
            this.pPlayingField.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pPlayingField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pPlayingField.Location = new System.Drawing.Point(12, 59);
            this.pPlayingField.Name = "pPlayingField";
            this.pPlayingField.Size = new System.Drawing.Size(410, 410);
            this.pPlayingField.TabIndex = 3;
            // 
            // Game2048
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(434, 481);
            this.Controls.Add(this.pPlayingField);
            this.Controls.Add(this.lScore);
            this.Controls.Add(this.lShowScore);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("asinastra", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.Name = "Game2048";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game2048";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game2048_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lShowScore;
        private System.Windows.Forms.Label lScore;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьНовуюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повторитьToolStripMenuItem;
        private System.Windows.Forms.Panel pPlayingField;
    }
}