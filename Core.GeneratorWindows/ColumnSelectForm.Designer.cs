namespace Core.GeneratorWindows
{
    partial class ColumnSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColumnSelectForm));
            this.groupBoxtool = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tselectAll = new System.Windows.Forms.ToolStripButton();
            this.treverse = new System.Windows.Forms.ToolStripButton();
            this.tcansel = new System.Windows.Forms.ToolStripButton();
            this.tok = new System.Windows.Forms.ToolStripButton();
            this.groupColumns = new System.Windows.Forms.GroupBox();
            this.dataGridViewSelect = new System.Windows.Forms.DataGridView();
            this.groupBoxtool.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxtool
            // 
            this.groupBoxtool.Controls.Add(this.toolStrip1);
            this.groupBoxtool.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxtool.Location = new System.Drawing.Point(0, 0);
            this.groupBoxtool.Name = "groupBoxtool";
            this.groupBoxtool.Size = new System.Drawing.Size(887, 66);
            this.groupBoxtool.TabIndex = 1;
            this.groupBoxtool.TabStop = false;
            this.groupBoxtool.Text = "Opeation";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tselectAll,
            this.treverse,
            this.tcansel,
            this.tok});
            this.toolStrip1.Location = new System.Drawing.Point(3, 17);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(881, 46);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tselectAll
            // 
            this.tselectAll.Image = ((System.Drawing.Image)(resources.GetObject("tselectAll.Image")));
            this.tselectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tselectAll.Name = "tselectAll";
            this.tselectAll.Size = new System.Drawing.Size(52, 43);
            this.tselectAll.Text = "全选";
            this.tselectAll.Click += new System.EventHandler(this.tselectAll_Click);
            // 
            // treverse
            // 
            this.treverse.Image = ((System.Drawing.Image)(resources.GetObject("treverse.Image")));
            this.treverse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.treverse.Name = "treverse";
            this.treverse.Size = new System.Drawing.Size(52, 43);
            this.treverse.Text = "反选";
            this.treverse.Click += new System.EventHandler(this.treverse_Click);
            // 
            // tcansel
            // 
            this.tcansel.Image = ((System.Drawing.Image)(resources.GetObject("tcansel.Image")));
            this.tcansel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tcansel.Name = "tcansel";
            this.tcansel.Size = new System.Drawing.Size(52, 43);
            this.tcansel.Text = "取消";
            this.tcansel.Click += new System.EventHandler(this.tcansel_Click);
            // 
            // tok
            // 
            this.tok.Image = ((System.Drawing.Image)(resources.GetObject("tok.Image")));
            this.tok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tok.Name = "tok";
            this.tok.Size = new System.Drawing.Size(76, 43);
            this.tok.Text = "确定选择";
            this.tok.Click += new System.EventHandler(this.tok_Click);
            // 
            // groupColumns
            // 
            this.groupColumns.Controls.Add(this.dataGridViewSelect);
            this.groupColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupColumns.Location = new System.Drawing.Point(0, 66);
            this.groupColumns.Name = "groupColumns";
            this.groupColumns.Size = new System.Drawing.Size(887, 371);
            this.groupColumns.TabIndex = 2;
            this.groupColumns.TabStop = false;
            this.groupColumns.Text = "TableColumns";
            // 
            // dataGridViewSelect
            // 
            this.dataGridViewSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelect.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewSelect.Name = "dataGridViewSelect";
            this.dataGridViewSelect.RowTemplate.Height = 23;
            this.dataGridViewSelect.Size = new System.Drawing.Size(881, 351);
            this.dataGridViewSelect.TabIndex = 1;
            // 
            // ColumnSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 437);
            this.Controls.Add(this.groupColumns);
            this.Controls.Add(this.groupBoxtool);
            this.Name = "ColumnSelectForm";
            this.Text = "ColumnSelectForm";
            this.groupBoxtool.ResumeLayout(false);
            this.groupBoxtool.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxtool;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tselectAll;
        private System.Windows.Forms.ToolStripButton treverse;
        private System.Windows.Forms.ToolStripButton tcansel;
        private System.Windows.Forms.ToolStripButton tok;
        private System.Windows.Forms.GroupBox groupColumns;
        private System.Windows.Forms.DataGridView dataGridViewSelect;
    }
}