namespace Core.GeneratorWindows
{
    partial class Geneartor
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Geneartor));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageGenerator = new System.Windows.Forms.TabPage();
            this.pGeneratorMain = new System.Windows.Forms.Panel();
            this.pGeneratorLeft = new System.Windows.Forms.Panel();
            this.pGeneratorTree = new System.Windows.Forms.Panel();
            this.treedb = new System.Windows.Forms.TreeView();
            this.tooldb = new System.Windows.Forms.ToolStrip();
            this.tooldbrefresh = new System.Windows.Forms.ToolStripButton();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabPageVariables = new System.Windows.Forms.TabPage();
            this.dataVariables = new System.Windows.Forms.DataGridView();
            this.tabPageDataType = new System.Windows.Forms.TabPage();
            this.imageListcollection = new System.Windows.Forms.ImageList(this.components);
            this.pSnippet = new System.Windows.Forms.Panel();
            this.ptop = new System.Windows.Forms.Panel();
            this.pdsnippet = new System.Windows.Forms.Panel();
            this.ContentMenuSnippet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CMS新建模板 = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS修改 = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS删除 = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS启用 = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS禁用 = new System.Windows.Forms.ToolStripMenuItem();
            this.CMS看生成代码 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewSnippet = new System.Windows.Forms.TreeView();
            this.tabControlMainSeeting = new System.Windows.Forms.TabControl();
            this.tGenerator = new System.Windows.Forms.TabPage();
            this.tSnippet = new System.Windows.Forms.TabPage();
            this.cIsFind = new System.Windows.Forms.CheckBox();
            this.cLanguage = new System.Windows.Forms.ComboBox();
            this.cIsEnabled = new System.Windows.Forms.CheckBox();
            this.cIsMerge = new System.Windows.Forms.CheckBox();
            this.tFileName = new System.Windows.Forms.TextBox();
            this.tName = new System.Windows.Forms.TextBox();
            this.lGeneratorFloder = new System.Windows.Forms.Label();
            this.lLanguage = new System.Windows.Forms.Label();
            this.lFileName = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabPageGenerator.SuspendLayout();
            this.pGeneratorMain.SuspendLayout();
            this.pGeneratorLeft.SuspendLayout();
            this.pGeneratorTree.SuspendLayout();
            this.tooldb.SuspendLayout();
            this.tabPageSetting.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabPageVariables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataVariables)).BeginInit();
            this.pSnippet.SuspendLayout();
            this.pdsnippet.SuspendLayout();
            this.ContentMenuSnippet.SuspendLayout();
            this.tabControlMainSeeting.SuspendLayout();
            this.tSnippet.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageGenerator);
            this.tabMain.Controls.Add(this.tabPageSetting);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1350, 690);
            this.tabMain.TabIndex = 0;
            // 
            // tabPageGenerator
            // 
            this.tabPageGenerator.Controls.Add(this.pGeneratorMain);
            this.tabPageGenerator.Controls.Add(this.pGeneratorLeft);
            this.tabPageGenerator.Location = new System.Drawing.Point(4, 22);
            this.tabPageGenerator.Name = "tabPageGenerator";
            this.tabPageGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGenerator.Size = new System.Drawing.Size(1342, 664);
            this.tabPageGenerator.TabIndex = 0;
            this.tabPageGenerator.Text = "Generator";
            this.tabPageGenerator.UseVisualStyleBackColor = true;
            // 
            // pGeneratorMain
            // 
            this.pGeneratorMain.Controls.Add(this.tabControlMainSeeting);
            this.pGeneratorMain.Controls.Add(this.pSnippet);
            this.pGeneratorMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGeneratorMain.Location = new System.Drawing.Point(288, 3);
            this.pGeneratorMain.Name = "pGeneratorMain";
            this.pGeneratorMain.Size = new System.Drawing.Size(1051, 658);
            this.pGeneratorMain.TabIndex = 1;
            // 
            // pGeneratorLeft
            // 
            this.pGeneratorLeft.Controls.Add(this.pGeneratorTree);
            this.pGeneratorLeft.Controls.Add(this.tooldb);
            this.pGeneratorLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pGeneratorLeft.Location = new System.Drawing.Point(3, 3);
            this.pGeneratorLeft.Name = "pGeneratorLeft";
            this.pGeneratorLeft.Size = new System.Drawing.Size(285, 658);
            this.pGeneratorLeft.TabIndex = 0;
            // 
            // pGeneratorTree
            // 
            this.pGeneratorTree.Controls.Add(this.treedb);
            this.pGeneratorTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGeneratorTree.Location = new System.Drawing.Point(0, 25);
            this.pGeneratorTree.Name = "pGeneratorTree";
            this.pGeneratorTree.Size = new System.Drawing.Size(285, 633);
            this.pGeneratorTree.TabIndex = 1;
            // 
            // treedb
            // 
            this.treedb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treedb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treedb.Location = new System.Drawing.Point(0, 0);
            this.treedb.Name = "treedb";
            this.treedb.Size = new System.Drawing.Size(285, 633);
            this.treedb.TabIndex = 0;
            // 
            // tooldb
            // 
            this.tooldb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooldbrefresh});
            this.tooldb.Location = new System.Drawing.Point(0, 0);
            this.tooldb.Name = "tooldb";
            this.tooldb.Size = new System.Drawing.Size(285, 25);
            this.tooldb.TabIndex = 0;
            this.tooldb.Text = "toolStrip1";
            // 
            // tooldbrefresh
            // 
            this.tooldbrefresh.Image = ((System.Drawing.Image)(resources.GetObject("tooldbrefresh.Image")));
            this.tooldbrefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooldbrefresh.Name = "tooldbrefresh";
            this.tooldbrefresh.Size = new System.Drawing.Size(72, 22);
            this.tooldbrefresh.Text = "Refresh";
            this.tooldbrefresh.Click += new System.EventHandler(this.tooldbrefresh_Click);
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.tabSettings);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(1342, 664);
            this.tabPageSetting.TabIndex = 1;
            this.tabPageSetting.Text = "Setting";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPageVariables);
            this.tabSettings.Controls.Add(this.tabPageDataType);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Location = new System.Drawing.Point(3, 3);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(1336, 658);
            this.tabSettings.TabIndex = 0;
            // 
            // tabPageVariables
            // 
            this.tabPageVariables.Controls.Add(this.dataVariables);
            this.tabPageVariables.Location = new System.Drawing.Point(4, 22);
            this.tabPageVariables.Name = "tabPageVariables";
            this.tabPageVariables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVariables.Size = new System.Drawing.Size(1328, 632);
            this.tabPageVariables.TabIndex = 0;
            this.tabPageVariables.Text = "Variables";
            this.tabPageVariables.UseVisualStyleBackColor = true;
            // 
            // dataVariables
            // 
            this.dataVariables.AllowUserToAddRows = false;
            this.dataVariables.AllowUserToDeleteRows = false;
            this.dataVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataVariables.Location = new System.Drawing.Point(3, 3);
            this.dataVariables.Name = "dataVariables";
            this.dataVariables.RowTemplate.Height = 23;
            this.dataVariables.Size = new System.Drawing.Size(1322, 626);
            this.dataVariables.TabIndex = 0;
            // 
            // tabPageDataType
            // 
            this.tabPageDataType.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataType.Name = "tabPageDataType";
            this.tabPageDataType.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataType.Size = new System.Drawing.Size(1328, 632);
            this.tabPageDataType.TabIndex = 1;
            this.tabPageDataType.Text = "DataType";
            this.tabPageDataType.UseVisualStyleBackColor = true;
            // 
            // imageListcollection
            // 
            this.imageListcollection.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListcollection.ImageStream")));
            this.imageListcollection.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListcollection.Images.SetKeyName(0, "DataBaseAddress.png");
            this.imageListcollection.Images.SetKeyName(1, "DataBase.png");
            this.imageListcollection.Images.SetKeyName(2, "Floder.png");
            this.imageListcollection.Images.SetKeyName(3, "Table.png");
            this.imageListcollection.Images.SetKeyName(4, "refersh.png");
            // 
            // pSnippet
            // 
            this.pSnippet.Controls.Add(this.pdsnippet);
            this.pSnippet.Controls.Add(this.ptop);
            this.pSnippet.Dock = System.Windows.Forms.DockStyle.Left;
            this.pSnippet.Location = new System.Drawing.Point(0, 0);
            this.pSnippet.Name = "pSnippet";
            this.pSnippet.Size = new System.Drawing.Size(247, 658);
            this.pSnippet.TabIndex = 0;
            // 
            // ptop
            // 
            this.ptop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptop.Location = new System.Drawing.Point(0, 0);
            this.ptop.Name = "ptop";
            this.ptop.Size = new System.Drawing.Size(247, 288);
            this.ptop.TabIndex = 0;
            // 
            // pdsnippet
            // 
            this.pdsnippet.Controls.Add(this.treeViewSnippet);
            this.pdsnippet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdsnippet.Location = new System.Drawing.Point(0, 288);
            this.pdsnippet.Name = "pdsnippet";
            this.pdsnippet.Size = new System.Drawing.Size(247, 370);
            this.pdsnippet.TabIndex = 1;
            // 
            // ContentMenuSnippet
            // 
            this.ContentMenuSnippet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CMS新建模板,
            this.CMS修改,
            this.CMS删除,
            this.CMS启用,
            this.CMS禁用,
            this.CMS看生成代码});
            this.ContentMenuSnippet.Name = "CMS";
            this.ContentMenuSnippet.Size = new System.Drawing.Size(137, 136);
            // 
            // CMS新建模板
            // 
            this.CMS新建模板.Image = ((System.Drawing.Image)(resources.GetObject("CMS新建模板.Image")));
            this.CMS新建模板.Name = "CMS新建模板";
            this.CMS新建模板.Size = new System.Drawing.Size(136, 22);
            this.CMS新建模板.Text = "新建模板";
            // 
            // CMS修改
            // 
            this.CMS修改.Image = ((System.Drawing.Image)(resources.GetObject("CMS修改.Image")));
            this.CMS修改.Name = "CMS修改";
            this.CMS修改.Size = new System.Drawing.Size(136, 22);
            this.CMS修改.Text = "修改";
            // 
            // CMS删除
            // 
            this.CMS删除.Image = ((System.Drawing.Image)(resources.GetObject("CMS删除.Image")));
            this.CMS删除.Name = "CMS删除";
            this.CMS删除.Size = new System.Drawing.Size(136, 22);
            this.CMS删除.Text = "删除";
            // 
            // CMS启用
            // 
            this.CMS启用.Image = ((System.Drawing.Image)(resources.GetObject("CMS启用.Image")));
            this.CMS启用.Name = "CMS启用";
            this.CMS启用.Size = new System.Drawing.Size(136, 22);
            this.CMS启用.Text = "启用";
            // 
            // CMS禁用
            // 
            this.CMS禁用.Image = ((System.Drawing.Image)(resources.GetObject("CMS禁用.Image")));
            this.CMS禁用.Name = "CMS禁用";
            this.CMS禁用.Size = new System.Drawing.Size(136, 22);
            this.CMS禁用.Text = "禁用";
            // 
            // CMS看生成代码
            // 
            this.CMS看生成代码.Image = ((System.Drawing.Image)(resources.GetObject("CMS看生成代码.Image")));
            this.CMS看生成代码.Name = "CMS看生成代码";
            this.CMS看生成代码.Size = new System.Drawing.Size(136, 22);
            this.CMS看生成代码.Text = "看生成代码";
            // 
            // treeViewSnippet
            // 
            this.treeViewSnippet.ContextMenuStrip = this.ContentMenuSnippet;
            this.treeViewSnippet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewSnippet.Location = new System.Drawing.Point(0, 0);
            this.treeViewSnippet.Name = "treeViewSnippet";
            this.treeViewSnippet.Size = new System.Drawing.Size(247, 370);
            this.treeViewSnippet.TabIndex = 0;
            // 
            // tabControlMainSeeting
            // 
            this.tabControlMainSeeting.Controls.Add(this.tGenerator);
            this.tabControlMainSeeting.Controls.Add(this.tSnippet);
            this.tabControlMainSeeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMainSeeting.Location = new System.Drawing.Point(247, 0);
            this.tabControlMainSeeting.Name = "tabControlMainSeeting";
            this.tabControlMainSeeting.SelectedIndex = 0;
            this.tabControlMainSeeting.Size = new System.Drawing.Size(804, 658);
            this.tabControlMainSeeting.TabIndex = 1;
            // 
            // tGenerator
            // 
            this.tGenerator.Location = new System.Drawing.Point(4, 22);
            this.tGenerator.Name = "tGenerator";
            this.tGenerator.Padding = new System.Windows.Forms.Padding(3);
            this.tGenerator.Size = new System.Drawing.Size(796, 632);
            this.tGenerator.TabIndex = 0;
            this.tGenerator.Text = "Generator";
            this.tGenerator.UseVisualStyleBackColor = true;
            // 
            // tSnippet
            // 
            this.tSnippet.Controls.Add(this.cIsFind);
            this.tSnippet.Controls.Add(this.cLanguage);
            this.tSnippet.Controls.Add(this.cIsEnabled);
            this.tSnippet.Controls.Add(this.cIsMerge);
            this.tSnippet.Controls.Add(this.tFileName);
            this.tSnippet.Controls.Add(this.tName);
            this.tSnippet.Controls.Add(this.lGeneratorFloder);
            this.tSnippet.Controls.Add(this.lLanguage);
            this.tSnippet.Controls.Add(this.lFileName);
            this.tSnippet.Controls.Add(this.lName);
            this.tSnippet.Location = new System.Drawing.Point(4, 22);
            this.tSnippet.Name = "tSnippet";
            this.tSnippet.Padding = new System.Windows.Forms.Padding(3);
            this.tSnippet.Size = new System.Drawing.Size(796, 632);
            this.tSnippet.TabIndex = 1;
            this.tSnippet.Text = "SnippetSetting";
            this.tSnippet.UseVisualStyleBackColor = true;
            // 
            // cIsFind
            // 
            this.cIsFind.AutoSize = true;
            this.cIsFind.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cIsFind.Location = new System.Drawing.Point(53, 213);
            this.cIsFind.Name = "cIsFind";
            this.cIsFind.Size = new System.Drawing.Size(113, 25);
            this.cIsFind.TabIndex = 37;
            this.cIsFind.Text = "自动查找";
            this.cIsFind.UseVisualStyleBackColor = true;
            // 
            // cLanguage
            // 
            this.cLanguage.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cLanguage.FormattingEnabled = true;
            this.cLanguage.Location = new System.Drawing.Point(146, 250);
            this.cLanguage.Name = "cLanguage";
            this.cLanguage.Size = new System.Drawing.Size(149, 29);
            this.cLanguage.TabIndex = 36;
            // 
            // cIsEnabled
            // 
            this.cIsEnabled.AutoSize = true;
            this.cIsEnabled.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cIsEnabled.Location = new System.Drawing.Point(53, 170);
            this.cIsEnabled.Name = "cIsEnabled";
            this.cIsEnabled.Size = new System.Drawing.Size(71, 25);
            this.cIsEnabled.TabIndex = 35;
            this.cIsEnabled.Text = "启用";
            this.cIsEnabled.UseVisualStyleBackColor = true;
            // 
            // cIsMerge
            // 
            this.cIsMerge.AutoSize = true;
            this.cIsMerge.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cIsMerge.Location = new System.Drawing.Point(53, 127);
            this.cIsMerge.Name = "cIsMerge";
            this.cIsMerge.Size = new System.Drawing.Size(71, 25);
            this.cIsMerge.TabIndex = 34;
            this.cIsMerge.Text = "合并";
            this.cIsMerge.UseVisualStyleBackColor = true;
            // 
            // tFileName
            // 
            this.tFileName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tFileName.Location = new System.Drawing.Point(146, 51);
            this.tFileName.Name = "tFileName";
            this.tFileName.Size = new System.Drawing.Size(378, 31);
            this.tFileName.TabIndex = 33;
            // 
            // tName
            // 
            this.tName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tName.Location = new System.Drawing.Point(146, 16);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(378, 31);
            this.tName.TabIndex = 32;
            // 
            // lGeneratorFloder
            // 
            this.lGeneratorFloder.AutoSize = true;
            this.lGeneratorFloder.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lGeneratorFloder.Location = new System.Drawing.Point(46, 89);
            this.lGeneratorFloder.Name = "lGeneratorFloder";
            this.lGeneratorFloder.Size = new System.Drawing.Size(94, 21);
            this.lGeneratorFloder.TabIndex = 31;
            this.lGeneratorFloder.Text = "文件夹：";
            // 
            // lLanguage
            // 
            this.lLanguage.AutoSize = true;
            this.lLanguage.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lLanguage.Location = new System.Drawing.Point(49, 253);
            this.lLanguage.Name = "lLanguage";
            this.lLanguage.Size = new System.Drawing.Size(73, 21);
            this.lLanguage.TabIndex = 30;
            this.lLanguage.Text = "语言：";
            // 
            // lFileName
            // 
            this.lFileName.AutoSize = true;
            this.lFileName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lFileName.Location = new System.Drawing.Point(5, 55);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(136, 21);
            this.lFileName.TabIndex = 29;
            this.lFileName.Text = "文件规则名：";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lName.Location = new System.Drawing.Point(25, 19);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(115, 21);
            this.lName.TabIndex = 28;
            this.lName.Text = "模版名称：";
            // 
            // Geneartor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 690);
            this.Controls.Add(this.tabMain);
            this.Name = "Geneartor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator";
            this.tabMain.ResumeLayout(false);
            this.tabPageGenerator.ResumeLayout(false);
            this.pGeneratorMain.ResumeLayout(false);
            this.pGeneratorLeft.ResumeLayout(false);
            this.pGeneratorLeft.PerformLayout();
            this.pGeneratorTree.ResumeLayout(false);
            this.tooldb.ResumeLayout(false);
            this.tooldb.PerformLayout();
            this.tabPageSetting.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabPageVariables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataVariables)).EndInit();
            this.pSnippet.ResumeLayout(false);
            this.pdsnippet.ResumeLayout(false);
            this.ContentMenuSnippet.ResumeLayout(false);
            this.tabControlMainSeeting.ResumeLayout(false);
            this.tSnippet.ResumeLayout(false);
            this.tSnippet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageGenerator;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.Panel pGeneratorLeft;
        private System.Windows.Forms.Panel pGeneratorMain;
        private System.Windows.Forms.ToolStrip tooldb;
        private System.Windows.Forms.ToolStripButton tooldbrefresh;
        private System.Windows.Forms.Panel pGeneratorTree;
        private System.Windows.Forms.TreeView treedb;
        private System.Windows.Forms.ImageList imageListcollection;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPageVariables;
        private System.Windows.Forms.TabPage tabPageDataType;
        private System.Windows.Forms.DataGridView dataVariables;
        private System.Windows.Forms.Panel pSnippet;
        private System.Windows.Forms.Panel pdsnippet;
        private System.Windows.Forms.Panel ptop;
        private System.Windows.Forms.ContextMenuStrip ContentMenuSnippet;
        private System.Windows.Forms.ToolStripMenuItem CMS新建模板;
        private System.Windows.Forms.ToolStripMenuItem CMS修改;
        private System.Windows.Forms.ToolStripMenuItem CMS删除;
        private System.Windows.Forms.ToolStripMenuItem CMS启用;
        private System.Windows.Forms.ToolStripMenuItem CMS禁用;
        private System.Windows.Forms.ToolStripMenuItem CMS看生成代码;
        private System.Windows.Forms.TreeView treeViewSnippet;
        private System.Windows.Forms.TabControl tabControlMainSeeting;
        private System.Windows.Forms.TabPage tGenerator;
        private System.Windows.Forms.TabPage tSnippet;
        private System.Windows.Forms.CheckBox cIsFind;
        private System.Windows.Forms.ComboBox cLanguage;
        private System.Windows.Forms.CheckBox cIsEnabled;
        private System.Windows.Forms.CheckBox cIsMerge;
        private System.Windows.Forms.TextBox tFileName;
        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Label lGeneratorFloder;
        private System.Windows.Forms.Label lLanguage;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.Label lName;
    }
}

