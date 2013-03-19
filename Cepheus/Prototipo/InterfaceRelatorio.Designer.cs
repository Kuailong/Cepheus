namespace Prototipo
{
    partial class InterfaceRelatorio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desenvolvedorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgGame = new System.Windows.Forms.DataGridView();
            this.dgcGameId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcGameName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcGameDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcGameTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgcGameDevelopId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDeveloper = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgType = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeveloper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgType)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gamesToolStripMenuItem,
            this.desenvolvedorasToolStripMenuItem,
            this.tiposToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // gamesToolStripMenuItem
            // 
            this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
            this.gamesToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.gamesToolStripMenuItem.Text = "Games";
            this.gamesToolStripMenuItem.Click += new System.EventHandler(this.gamesToolStripMenuItem_Click);
            // 
            // desenvolvedorasToolStripMenuItem
            // 
            this.desenvolvedorasToolStripMenuItem.Name = "desenvolvedorasToolStripMenuItem";
            this.desenvolvedorasToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.desenvolvedorasToolStripMenuItem.Text = "Desenvolvedoras";
            this.desenvolvedorasToolStripMenuItem.Click += new System.EventHandler(this.desenvolvedorasToolStripMenuItem_Click);
            // 
            // tiposToolStripMenuItem
            // 
            this.tiposToolStripMenuItem.Name = "tiposToolStripMenuItem";
            this.tiposToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.tiposToolStripMenuItem.Text = "Tipos";
            this.tiposToolStripMenuItem.Click += new System.EventHandler(this.tiposToolStripMenuItem_Click);
            // 
            // dgGame
            // 
            this.dgGame.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgGame.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgcGameId,
            this.dgcGameName,
            this.dgcGameDescription,
            this.dgcGameTypeId,
            this.dgcGameDevelopId});
            this.dgGame.Location = new System.Drawing.Point(12, 28);
            this.dgGame.Name = "dgGame";
            this.dgGame.Size = new System.Drawing.Size(769, 347);
            this.dgGame.TabIndex = 1;
            // 
            // dgcGameId
            // 
            this.dgcGameId.HeaderText = "Id";
            this.dgcGameId.Name = "dgcGameId";
            this.dgcGameId.ReadOnly = true;
            this.dgcGameId.Width = 50;
            // 
            // dgcGameName
            // 
            this.dgcGameName.HeaderText = "Nome";
            this.dgcGameName.Name = "dgcGameName";
            this.dgcGameName.ReadOnly = true;
            this.dgcGameName.Width = 250;
            // 
            // dgcGameDescription
            // 
            this.dgcGameDescription.HeaderText = "Descrição";
            this.dgcGameDescription.Name = "dgcGameDescription";
            this.dgcGameDescription.ReadOnly = true;
            this.dgcGameDescription.Width = 305;
            // 
            // dgcGameTypeId
            // 
            this.dgcGameTypeId.HeaderText = "Tipo Id";
            this.dgcGameTypeId.Name = "dgcGameTypeId";
            this.dgcGameTypeId.ReadOnly = true;
            this.dgcGameTypeId.Width = 50;
            // 
            // dgcGameDevelopId
            // 
            this.dgcGameDevelopId.HeaderText = "Desenv. Id";
            this.dgcGameDevelopId.Name = "dgcGameDevelopId";
            this.dgcGameDevelopId.ReadOnly = true;
            this.dgcGameDevelopId.Width = 70;
            // 
            // dgDeveloper
            // 
            this.dgDeveloper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDeveloper.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgDeveloper.Location = new System.Drawing.Point(12, 28);
            this.dgDeveloper.Name = "dgDeveloper";
            this.dgDeveloper.Size = new System.Drawing.Size(769, 347);
            this.dgDeveloper.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 425;
            // 
            // dgType
            // 
            this.dgType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgType.Location = new System.Drawing.Point(12, 28);
            this.dgType.Name = "dgType";
            this.dgType.Size = new System.Drawing.Size(769, 347);
            this.dgType.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Id";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 250;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 425;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // InterfaceRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 387);
            this.Controls.Add(this.dgType);
            this.Controls.Add(this.dgDeveloper);
            this.Controls.Add(this.dgGame);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InterfaceRelatorio";
            this.Text = "InterfaceRelatorio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDeveloper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desenvolvedorasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgGame;
        private System.Windows.Forms.DataGridView dgDeveloper;
        private System.Windows.Forms.DataGridView dgType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcGameId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcGameName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcGameDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcGameTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgcGameDevelopId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
    }
}