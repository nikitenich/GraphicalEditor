namespace GraphicalEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.izomPic = new System.Windows.Forms.PictureBox();
            this.xoyPic = new System.Windows.Forms.PictureBox();
            this.xozPic = new System.Windows.Forms.PictureBox();
            this.yozPic = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ActionTabs = new System.Windows.Forms.TabControl();
            this.ScaleTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ScaleAccuratelyGroupBox = new System.Windows.Forms.GroupBox();
            this.ScaleAccuratelyButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ScaleAccuratelyOZBox = new System.Windows.Forms.TextBox();
            this.ScaleAccuratelyOYBox = new System.Windows.Forms.TextBox();
            this.ScaleAccuratelyOXBox = new System.Windows.Forms.TextBox();
            this.ScaleRoughGroupBox = new System.Windows.Forms.GroupBox();
            this.ScaleButton = new System.Windows.Forms.Button();
            this.ScaleRoughTextBox = new System.Windows.Forms.TextBox();
            this.ScaleRoughcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.ScaleSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.ScaleAccuratelyRB = new System.Windows.Forms.RadioButton();
            this.ScaleRoughRB = new System.Windows.Forms.RadioButton();
            this.RotateTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RotateAccuratelyGroupBox = new System.Windows.Forms.GroupBox();
            this.RotateAccuratelyButton = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.RotateAccuratelyOZBox = new System.Windows.Forms.TextBox();
            this.RotateAccuratelyOYBox = new System.Windows.Forms.TextBox();
            this.RotateAccuratelyOXBox = new System.Windows.Forms.TextBox();
            this.RotateRoughGroupBox = new System.Windows.Forms.GroupBox();
            this.RotateRoughRightButton = new System.Windows.Forms.Button();
            this.RotateRoughLeftButton = new System.Windows.Forms.Button();
            this.RotateRoughTextBox = new System.Windows.Forms.TextBox();
            this.RotateRoughcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.RotateSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.RotateAccuratelyRB = new System.Windows.Forms.RadioButton();
            this.RotateRoughRB = new System.Windows.Forms.RadioButton();
            this.ShiftTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ShiftAccuratelyGroupBox = new System.Windows.Forms.GroupBox();
            this.ShiftAccuratelyButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ShiftAccuratelyOZBox = new System.Windows.Forms.TextBox();
            this.ShiftAccuratelyOYBox = new System.Windows.Forms.TextBox();
            this.ShiftAccuratelyOXBox = new System.Windows.Forms.TextBox();
            this.ShiftRoughGroupBox = new System.Windows.Forms.GroupBox();
            this.ShiftRoughRightButton = new System.Windows.Forms.Button();
            this.ShiftRoughLeftButton = new System.Windows.Forms.Button();
            this.ShiftRoughTextBox = new System.Windows.Forms.TextBox();
            this.ShiftRoughcheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.ShiftSelectGroupBox = new System.Windows.Forms.GroupBox();
            this.ShiftAccuratelyRB = new System.Windows.Forms.RadioButton();
            this.ShiftRoughRB = new System.Windows.Forms.RadioButton();
            this.CreateTab = new System.Windows.Forms.TabPage();
            this.CreateGroupBox = new System.Windows.Forms.GroupBox();
            this.DeleteEdgeButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.EditEdgeButton = new System.Windows.Forms.Button();
            this.VertexGrid = new System.Windows.Forms.DataGridView();
            this.AddEdgeButton = new System.Windows.Forms.Button();
            this.EdgesGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.vertexTB_X = new System.Windows.Forms.TextBox();
            this.edgeTB_end = new System.Windows.Forms.TextBox();
            this.vertexTB_Y = new System.Windows.Forms.TextBox();
            this.edgeTB_start = new System.Windows.Forms.TextBox();
            this.vertexTB_Z = new System.Windows.Forms.TextBox();
            this.DeleteVertexButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.EditVertexButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.AddVertexButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.StartTab = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_TX = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_TY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_TZ = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_RX = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_RY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_RZ = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_SX = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_SY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tss_SZ = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.izomPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xoyPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xozPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yozPic)).BeginInit();
            this.ActionTabs.SuspendLayout();
            this.ScaleTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ScaleAccuratelyGroupBox.SuspendLayout();
            this.ScaleRoughGroupBox.SuspendLayout();
            this.ScaleSelectGroupBox.SuspendLayout();
            this.RotateTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.RotateAccuratelyGroupBox.SuspendLayout();
            this.RotateRoughGroupBox.SuspendLayout();
            this.RotateSelectGroupBox.SuspendLayout();
            this.ShiftTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ShiftAccuratelyGroupBox.SuspendLayout();
            this.ShiftRoughGroupBox.SuspendLayout();
            this.ShiftSelectGroupBox.SuspendLayout();
            this.CreateTab.SuspendLayout();
            this.CreateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VertexGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdgesGrid)).BeginInit();
            this.StartTab.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ActionToolStripMenuItem,
            this.PrintToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1019, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.FileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // CreateToolStripMenuItem
            // 
            this.CreateToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.CreateToolStripMenuItem.BackgroundImage = global::GraphicalEditor.Properties.Resources.bg_menu_items;
            this.CreateToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            this.CreateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.CreateToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.CreateToolStripMenuItem.Text = "Создать";
            this.CreateToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.BackgroundImage")));
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.BackgroundImage")));
            this.SaveToolStripMenuItem.Enabled = false;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveAsToolStripMenuItem.BackgroundImage")));
            this.SaveAsToolStripMenuItem.Enabled = false;
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.SaveAsToolStripMenuItem.Text = "Сохранить как...";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditToolStripMenuItem.BackgroundImage")));
            this.EditToolStripMenuItem.Enabled = false;
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.EditToolStripMenuItem.Text = "Редактировать";
            this.EditToolStripMenuItem.Click += new System.EventHandler(this.EditToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.BackgroundImage")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ActionToolStripMenuItem
            // 
            this.ActionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScaleToolStripMenuItem,
            this.RotateToolStripMenuItem,
            this.ShiftToolStripMenuItem});
            this.ActionToolStripMenuItem.Enabled = false;
            this.ActionToolStripMenuItem.Name = "ActionToolStripMenuItem";
            this.ActionToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.ActionToolStripMenuItem.Text = "Действие";
            // 
            // ScaleToolStripMenuItem
            // 
            this.ScaleToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScaleToolStripMenuItem.BackgroundImage")));
            this.ScaleToolStripMenuItem.Name = "ScaleToolStripMenuItem";
            this.ScaleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.ScaleToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ScaleToolStripMenuItem.Text = "Масштаб";
            this.ScaleToolStripMenuItem.Click += new System.EventHandler(this.ScaleToolStripMenuItem_Click);
            // 
            // RotateToolStripMenuItem
            // 
            this.RotateToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RotateToolStripMenuItem.BackgroundImage")));
            this.RotateToolStripMenuItem.Name = "RotateToolStripMenuItem";
            this.RotateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RotateToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.RotateToolStripMenuItem.Text = "Поворот";
            this.RotateToolStripMenuItem.Click += new System.EventHandler(this.RotateToolStripMenuItem_Click);
            // 
            // ShiftToolStripMenuItem
            // 
            this.ShiftToolStripMenuItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ShiftToolStripMenuItem.BackgroundImage")));
            this.ShiftToolStripMenuItem.Name = "ShiftToolStripMenuItem";
            this.ShiftToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.ShiftToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.ShiftToolStripMenuItem.Text = "Сдвиг";
            this.ShiftToolStripMenuItem.Click += new System.EventHandler(this.ShiftToolStripMenuItem_Click);
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Enabled = false;
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.PrintToolStripMenuItem.Text = "Печать";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(58, 48);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.splitContainer.Panel1.Controls.Add(this.tableLayoutPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.splitContainer.Panel2.Controls.Add(this.ActionTabs);
            this.splitContainer.Size = new System.Drawing.Size(895, 602);
            this.splitContainer.SplitterDistance = 563;
            this.splitContainer.TabIndex = 1;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.izomPic, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.xoyPic, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.xozPic, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.yozPic, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(561, 600);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // izomPic
            // 
            this.izomPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            this.izomPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.izomPic.Location = new System.Drawing.Point(283, 303);
            this.izomPic.Name = "izomPic";
            this.izomPic.Size = new System.Drawing.Size(275, 274);
            this.izomPic.TabIndex = 10;
            this.izomPic.TabStop = false;
            // 
            // xoyPic
            // 
            this.xoyPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            this.xoyPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xoyPic.Location = new System.Drawing.Point(3, 303);
            this.xoyPic.Name = "xoyPic";
            this.xoyPic.Size = new System.Drawing.Size(274, 274);
            this.xoyPic.TabIndex = 9;
            this.xoyPic.TabStop = false;
            // 
            // xozPic
            // 
            this.xozPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            this.xozPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xozPic.Location = new System.Drawing.Point(283, 23);
            this.xozPic.Name = "xozPic";
            this.xozPic.Size = new System.Drawing.Size(275, 274);
            this.xozPic.TabIndex = 8;
            this.xozPic.TabStop = false;
            // 
            // yozPic
            // 
            this.yozPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(238)))), ((int)(((byte)(246)))));
            this.yozPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yozPic.Location = new System.Drawing.Point(3, 23);
            this.yozPic.Name = "yozPic";
            this.yozPic.Size = new System.Drawing.Size(274, 274);
            this.yozPic.TabIndex = 3;
            this.yozPic.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(283, 580);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Изометрия";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(3, 580);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "XOY";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(283, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "XOZ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "YOZ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActionTabs
            // 
            this.ActionTabs.Controls.Add(this.ScaleTab);
            this.ActionTabs.Controls.Add(this.RotateTab);
            this.ActionTabs.Controls.Add(this.ShiftTab);
            this.ActionTabs.Controls.Add(this.CreateTab);
            this.ActionTabs.Controls.Add(this.StartTab);
            this.ActionTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionTabs.ItemSize = new System.Drawing.Size(0, 1);
            this.ActionTabs.Location = new System.Drawing.Point(0, 0);
            this.ActionTabs.Name = "ActionTabs";
            this.ActionTabs.SelectedIndex = 0;
            this.ActionTabs.Size = new System.Drawing.Size(326, 600);
            this.ActionTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.ActionTabs.TabIndex = 0;
            this.ActionTabs.TabStop = false;
            // 
            // ScaleTab
            // 
            this.ScaleTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.ScaleTab.Controls.Add(this.groupBox2);
            this.ScaleTab.Location = new System.Drawing.Point(4, 24);
            this.ScaleTab.Name = "ScaleTab";
            this.ScaleTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScaleTab.Size = new System.Drawing.Size(318, 572);
            this.ScaleTab.TabIndex = 0;
            this.ScaleTab.Text = "Масштаб";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.groupBox2.Controls.Add(this.ScaleAccuratelyGroupBox);
            this.groupBox2.Controls.Add(this.ScaleRoughGroupBox);
            this.groupBox2.Controls.Add(this.ScaleSelectGroupBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 566);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Масштаб";
            // 
            // ScaleAccuratelyGroupBox
            // 
            this.ScaleAccuratelyGroupBox.Controls.Add(this.ScaleAccuratelyButton);
            this.ScaleAccuratelyGroupBox.Controls.Add(this.label15);
            this.ScaleAccuratelyGroupBox.Controls.Add(this.label16);
            this.ScaleAccuratelyGroupBox.Controls.Add(this.label17);
            this.ScaleAccuratelyGroupBox.Controls.Add(this.ScaleAccuratelyOZBox);
            this.ScaleAccuratelyGroupBox.Controls.Add(this.ScaleAccuratelyOYBox);
            this.ScaleAccuratelyGroupBox.Controls.Add(this.ScaleAccuratelyOXBox);
            this.ScaleAccuratelyGroupBox.Location = new System.Drawing.Point(3, 95);
            this.ScaleAccuratelyGroupBox.Name = "ScaleAccuratelyGroupBox";
            this.ScaleAccuratelyGroupBox.Size = new System.Drawing.Size(270, 148);
            this.ScaleAccuratelyGroupBox.TabIndex = 2;
            this.ScaleAccuratelyGroupBox.TabStop = false;
            this.ScaleAccuratelyGroupBox.Text = "Точный масштаб";
            this.ScaleAccuratelyGroupBox.Visible = false;
            // 
            // ScaleAccuratelyButton
            // 
            this.ScaleAccuratelyButton.Location = new System.Drawing.Point(97, 48);
            this.ScaleAccuratelyButton.Name = "ScaleAccuratelyButton";
            this.ScaleAccuratelyButton.Size = new System.Drawing.Size(80, 24);
            this.ScaleAccuratelyButton.TabIndex = 6;
            this.ScaleAccuratelyButton.Text = "Выполнить";
            this.ScaleAccuratelyButton.UseVisualStyleBackColor = true;
            this.ScaleAccuratelyButton.Click += new System.EventHandler(this.ScaleAccuratelyButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 77);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(22, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "OZ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 13);
            this.label16.TabIndex = 4;
            this.label16.Text = "OY";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "OX";
            // 
            // ScaleAccuratelyOZBox
            // 
            this.ScaleAccuratelyOZBox.Location = new System.Drawing.Point(35, 74);
            this.ScaleAccuratelyOZBox.Name = "ScaleAccuratelyOZBox";
            this.ScaleAccuratelyOZBox.Size = new System.Drawing.Size(42, 20);
            this.ScaleAccuratelyOZBox.TabIndex = 2;
            this.ScaleAccuratelyOZBox.Text = "1";
            this.ScaleAccuratelyOZBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScaleAccuratelyOZBox_KeyPress);
            // 
            // ScaleAccuratelyOYBox
            // 
            this.ScaleAccuratelyOYBox.Location = new System.Drawing.Point(35, 48);
            this.ScaleAccuratelyOYBox.Name = "ScaleAccuratelyOYBox";
            this.ScaleAccuratelyOYBox.Size = new System.Drawing.Size(42, 20);
            this.ScaleAccuratelyOYBox.TabIndex = 1;
            this.ScaleAccuratelyOYBox.Text = "1";
            this.ScaleAccuratelyOYBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScaleAccuratelyOYBox_KeyPress);
            // 
            // ScaleAccuratelyOXBox
            // 
            this.ScaleAccuratelyOXBox.Location = new System.Drawing.Point(36, 22);
            this.ScaleAccuratelyOXBox.Name = "ScaleAccuratelyOXBox";
            this.ScaleAccuratelyOXBox.Size = new System.Drawing.Size(42, 20);
            this.ScaleAccuratelyOXBox.TabIndex = 0;
            this.ScaleAccuratelyOXBox.Text = "1";
            this.ScaleAccuratelyOXBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScaleAccuratelyOXBox_KeyPress);
            // 
            // ScaleRoughGroupBox
            // 
            this.ScaleRoughGroupBox.Controls.Add(this.ScaleButton);
            this.ScaleRoughGroupBox.Controls.Add(this.ScaleRoughTextBox);
            this.ScaleRoughGroupBox.Controls.Add(this.ScaleRoughcheckedListBox);
            this.ScaleRoughGroupBox.Location = new System.Drawing.Point(3, 95);
            this.ScaleRoughGroupBox.Name = "ScaleRoughGroupBox";
            this.ScaleRoughGroupBox.Size = new System.Drawing.Size(270, 148);
            this.ScaleRoughGroupBox.TabIndex = 1;
            this.ScaleRoughGroupBox.TabStop = false;
            this.ScaleRoughGroupBox.Text = "Грубый масштаб";
            // 
            // ScaleButton
            // 
            this.ScaleButton.Location = new System.Drawing.Point(97, 85);
            this.ScaleButton.Name = "ScaleButton";
            this.ScaleButton.Size = new System.Drawing.Size(75, 23);
            this.ScaleButton.TabIndex = 3;
            this.ScaleButton.Text = "Выполнить";
            this.ScaleButton.UseVisualStyleBackColor = true;
            this.ScaleButton.Click += new System.EventHandler(this.ScaleButton_Click);
            // 
            // ScaleRoughTextBox
            // 
            this.ScaleRoughTextBox.Location = new System.Drawing.Point(97, 46);
            this.ScaleRoughTextBox.Name = "ScaleRoughTextBox";
            this.ScaleRoughTextBox.Size = new System.Drawing.Size(100, 20);
            this.ScaleRoughTextBox.TabIndex = 1;
            this.ScaleRoughTextBox.Text = "0";
            this.ScaleRoughTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScaleRoughTextBox_KeyPress);
            // 
            // ScaleRoughcheckedListBox
            // 
            this.ScaleRoughcheckedListBox.CheckOnClick = true;
            this.ScaleRoughcheckedListBox.FormattingEnabled = true;
            this.ScaleRoughcheckedListBox.Items.AddRange(new object[] {
            "OX",
            "OY",
            "OZ"});
            this.ScaleRoughcheckedListBox.Location = new System.Drawing.Point(16, 31);
            this.ScaleRoughcheckedListBox.Name = "ScaleRoughcheckedListBox";
            this.ScaleRoughcheckedListBox.Size = new System.Drawing.Size(59, 49);
            this.ScaleRoughcheckedListBox.TabIndex = 0;
            // 
            // ScaleSelectGroupBox
            // 
            this.ScaleSelectGroupBox.Controls.Add(this.ScaleAccuratelyRB);
            this.ScaleSelectGroupBox.Controls.Add(this.ScaleRoughRB);
            this.ScaleSelectGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScaleSelectGroupBox.Location = new System.Drawing.Point(3, 16);
            this.ScaleSelectGroupBox.Name = "ScaleSelectGroupBox";
            this.ScaleSelectGroupBox.Size = new System.Drawing.Size(306, 73);
            this.ScaleSelectGroupBox.TabIndex = 0;
            this.ScaleSelectGroupBox.TabStop = false;
            this.ScaleSelectGroupBox.Text = "Как?";
            // 
            // ScaleAccuratelyRB
            // 
            this.ScaleAccuratelyRB.AutoSize = true;
            this.ScaleAccuratelyRB.Location = new System.Drawing.Point(6, 42);
            this.ScaleAccuratelyRB.Name = "ScaleAccuratelyRB";
            this.ScaleAccuratelyRB.Size = new System.Drawing.Size(55, 17);
            this.ScaleAccuratelyRB.TabIndex = 1;
            this.ScaleAccuratelyRB.Text = "Точно";
            this.ScaleAccuratelyRB.UseVisualStyleBackColor = true;
            this.ScaleAccuratelyRB.CheckedChanged += new System.EventHandler(this.ScaleAccuratelyRB_CheckedChanged);
            // 
            // ScaleRoughRB
            // 
            this.ScaleRoughRB.AutoSize = true;
            this.ScaleRoughRB.Checked = true;
            this.ScaleRoughRB.Location = new System.Drawing.Point(6, 19);
            this.ScaleRoughRB.Name = "ScaleRoughRB";
            this.ScaleRoughRB.Size = new System.Drawing.Size(54, 17);
            this.ScaleRoughRB.TabIndex = 0;
            this.ScaleRoughRB.TabStop = true;
            this.ScaleRoughRB.Text = "Грубо";
            this.ScaleRoughRB.UseVisualStyleBackColor = true;
            this.ScaleRoughRB.CheckedChanged += new System.EventHandler(this.ScaleRoughRB_CheckedChanged);
            // 
            // RotateTab
            // 
            this.RotateTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.RotateTab.Controls.Add(this.groupBox3);
            this.RotateTab.Location = new System.Drawing.Point(4, 24);
            this.RotateTab.Name = "RotateTab";
            this.RotateTab.Padding = new System.Windows.Forms.Padding(3);
            this.RotateTab.Size = new System.Drawing.Size(318, 572);
            this.RotateTab.TabIndex = 1;
            this.RotateTab.Text = "Поворот";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.groupBox3.Controls.Add(this.RotateAccuratelyGroupBox);
            this.groupBox3.Controls.Add(this.RotateRoughGroupBox);
            this.groupBox3.Controls.Add(this.RotateSelectGroupBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 566);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поворот";
            // 
            // RotateAccuratelyGroupBox
            // 
            this.RotateAccuratelyGroupBox.Controls.Add(this.RotateAccuratelyButton);
            this.RotateAccuratelyGroupBox.Controls.Add(this.label18);
            this.RotateAccuratelyGroupBox.Controls.Add(this.label19);
            this.RotateAccuratelyGroupBox.Controls.Add(this.label20);
            this.RotateAccuratelyGroupBox.Controls.Add(this.RotateAccuratelyOZBox);
            this.RotateAccuratelyGroupBox.Controls.Add(this.RotateAccuratelyOYBox);
            this.RotateAccuratelyGroupBox.Controls.Add(this.RotateAccuratelyOXBox);
            this.RotateAccuratelyGroupBox.Location = new System.Drawing.Point(3, 95);
            this.RotateAccuratelyGroupBox.Name = "RotateAccuratelyGroupBox";
            this.RotateAccuratelyGroupBox.Size = new System.Drawing.Size(270, 148);
            this.RotateAccuratelyGroupBox.TabIndex = 2;
            this.RotateAccuratelyGroupBox.TabStop = false;
            this.RotateAccuratelyGroupBox.Text = "Точный поворот";
            this.RotateAccuratelyGroupBox.Visible = false;
            // 
            // RotateAccuratelyButton
            // 
            this.RotateAccuratelyButton.Location = new System.Drawing.Point(117, 51);
            this.RotateAccuratelyButton.Name = "RotateAccuratelyButton";
            this.RotateAccuratelyButton.Size = new System.Drawing.Size(80, 24);
            this.RotateAccuratelyButton.TabIndex = 6;
            this.RotateAccuratelyButton.Text = "Выполнить";
            this.RotateAccuratelyButton.UseVisualStyleBackColor = true;
            this.RotateAccuratelyButton.Click += new System.EventHandler(this.RotateAccuratelyButton_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "OZ";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(22, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "OY";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 13);
            this.label20.TabIndex = 3;
            this.label20.Text = "OX";
            // 
            // RotateAccuratelyOZBox
            // 
            this.RotateAccuratelyOZBox.Location = new System.Drawing.Point(36, 74);
            this.RotateAccuratelyOZBox.Name = "RotateAccuratelyOZBox";
            this.RotateAccuratelyOZBox.Size = new System.Drawing.Size(42, 20);
            this.RotateAccuratelyOZBox.TabIndex = 2;
            this.RotateAccuratelyOZBox.Text = "0";
            this.RotateAccuratelyOZBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RotateAccuratelyOZBox_KeyPress);
            // 
            // RotateAccuratelyOYBox
            // 
            this.RotateAccuratelyOYBox.Location = new System.Drawing.Point(36, 48);
            this.RotateAccuratelyOYBox.Name = "RotateAccuratelyOYBox";
            this.RotateAccuratelyOYBox.Size = new System.Drawing.Size(42, 20);
            this.RotateAccuratelyOYBox.TabIndex = 1;
            this.RotateAccuratelyOYBox.Text = "0";
            this.RotateAccuratelyOYBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RotateAccuratelyOYBox_KeyPress);
            // 
            // RotateAccuratelyOXBox
            // 
            this.RotateAccuratelyOXBox.Location = new System.Drawing.Point(36, 22);
            this.RotateAccuratelyOXBox.Name = "RotateAccuratelyOXBox";
            this.RotateAccuratelyOXBox.Size = new System.Drawing.Size(42, 20);
            this.RotateAccuratelyOXBox.TabIndex = 0;
            this.RotateAccuratelyOXBox.Text = "0";
            this.RotateAccuratelyOXBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RotateAccuratelyOXBox_KeyPress);
            // 
            // RotateRoughGroupBox
            // 
            this.RotateRoughGroupBox.Controls.Add(this.RotateRoughRightButton);
            this.RotateRoughGroupBox.Controls.Add(this.RotateRoughLeftButton);
            this.RotateRoughGroupBox.Controls.Add(this.RotateRoughTextBox);
            this.RotateRoughGroupBox.Controls.Add(this.RotateRoughcheckedListBox);
            this.RotateRoughGroupBox.Location = new System.Drawing.Point(3, 95);
            this.RotateRoughGroupBox.Name = "RotateRoughGroupBox";
            this.RotateRoughGroupBox.Size = new System.Drawing.Size(270, 148);
            this.RotateRoughGroupBox.TabIndex = 1;
            this.RotateRoughGroupBox.TabStop = false;
            this.RotateRoughGroupBox.Text = "Грубый поворот";
            // 
            // RotateRoughRightButton
            // 
            this.RotateRoughRightButton.Location = new System.Drawing.Point(122, 95);
            this.RotateRoughRightButton.Name = "RotateRoughRightButton";
            this.RotateRoughRightButton.Size = new System.Drawing.Size(75, 23);
            this.RotateRoughRightButton.TabIndex = 3;
            this.RotateRoughRightButton.Text = ">>>";
            this.RotateRoughRightButton.UseVisualStyleBackColor = true;
            this.RotateRoughRightButton.Click += new System.EventHandler(this.RotateRoughRightButton_Click);
            // 
            // RotateRoughLeftButton
            // 
            this.RotateRoughLeftButton.Location = new System.Drawing.Point(36, 95);
            this.RotateRoughLeftButton.Name = "RotateRoughLeftButton";
            this.RotateRoughLeftButton.Size = new System.Drawing.Size(75, 23);
            this.RotateRoughLeftButton.TabIndex = 2;
            this.RotateRoughLeftButton.Text = "<<<";
            this.RotateRoughLeftButton.UseVisualStyleBackColor = true;
            this.RotateRoughLeftButton.Click += new System.EventHandler(this.RotateRoughLeftButton_Click);
            // 
            // RotateRoughTextBox
            // 
            this.RotateRoughTextBox.Location = new System.Drawing.Point(97, 46);
            this.RotateRoughTextBox.Name = "RotateRoughTextBox";
            this.RotateRoughTextBox.Size = new System.Drawing.Size(100, 20);
            this.RotateRoughTextBox.TabIndex = 1;
            this.RotateRoughTextBox.Text = "0";
            this.RotateRoughTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RotateRoughTextBox_KeyPress);
            // 
            // RotateRoughcheckedListBox
            // 
            this.RotateRoughcheckedListBox.CheckOnClick = true;
            this.RotateRoughcheckedListBox.FormattingEnabled = true;
            this.RotateRoughcheckedListBox.Items.AddRange(new object[] {
            "OX",
            "OY",
            "OZ"});
            this.RotateRoughcheckedListBox.Location = new System.Drawing.Point(16, 31);
            this.RotateRoughcheckedListBox.Name = "RotateRoughcheckedListBox";
            this.RotateRoughcheckedListBox.Size = new System.Drawing.Size(59, 49);
            this.RotateRoughcheckedListBox.TabIndex = 0;
            // 
            // RotateSelectGroupBox
            // 
            this.RotateSelectGroupBox.Controls.Add(this.RotateAccuratelyRB);
            this.RotateSelectGroupBox.Controls.Add(this.RotateRoughRB);
            this.RotateSelectGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.RotateSelectGroupBox.Location = new System.Drawing.Point(3, 16);
            this.RotateSelectGroupBox.Name = "RotateSelectGroupBox";
            this.RotateSelectGroupBox.Size = new System.Drawing.Size(306, 73);
            this.RotateSelectGroupBox.TabIndex = 0;
            this.RotateSelectGroupBox.TabStop = false;
            this.RotateSelectGroupBox.Text = "Как?";
            // 
            // RotateAccuratelyRB
            // 
            this.RotateAccuratelyRB.AutoSize = true;
            this.RotateAccuratelyRB.Location = new System.Drawing.Point(6, 42);
            this.RotateAccuratelyRB.Name = "RotateAccuratelyRB";
            this.RotateAccuratelyRB.Size = new System.Drawing.Size(55, 17);
            this.RotateAccuratelyRB.TabIndex = 1;
            this.RotateAccuratelyRB.Text = "Точно";
            this.RotateAccuratelyRB.UseVisualStyleBackColor = true;
            this.RotateAccuratelyRB.CheckedChanged += new System.EventHandler(this.RotateAccuratelyRB_CheckedChanged);
            // 
            // RotateRoughRB
            // 
            this.RotateRoughRB.AutoSize = true;
            this.RotateRoughRB.Checked = true;
            this.RotateRoughRB.Location = new System.Drawing.Point(6, 19);
            this.RotateRoughRB.Name = "RotateRoughRB";
            this.RotateRoughRB.Size = new System.Drawing.Size(54, 17);
            this.RotateRoughRB.TabIndex = 0;
            this.RotateRoughRB.TabStop = true;
            this.RotateRoughRB.Text = "Грубо";
            this.RotateRoughRB.UseVisualStyleBackColor = true;
            this.RotateRoughRB.CheckedChanged += new System.EventHandler(this.RotateRoughRB_CheckedChanged);
            // 
            // ShiftTab
            // 
            this.ShiftTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.ShiftTab.Controls.Add(this.groupBox1);
            this.ShiftTab.Location = new System.Drawing.Point(4, 24);
            this.ShiftTab.Name = "ShiftTab";
            this.ShiftTab.Size = new System.Drawing.Size(318, 572);
            this.ShiftTab.TabIndex = 2;
            this.ShiftTab.Text = "Сдвиг";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.groupBox1.Controls.Add(this.ShiftAccuratelyGroupBox);
            this.groupBox1.Controls.Add(this.ShiftRoughGroupBox);
            this.groupBox1.Controls.Add(this.ShiftSelectGroupBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 572);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сдвиг";
            // 
            // ShiftAccuratelyGroupBox
            // 
            this.ShiftAccuratelyGroupBox.Controls.Add(this.ShiftAccuratelyButton);
            this.ShiftAccuratelyGroupBox.Controls.Add(this.label14);
            this.ShiftAccuratelyGroupBox.Controls.Add(this.label13);
            this.ShiftAccuratelyGroupBox.Controls.Add(this.label10);
            this.ShiftAccuratelyGroupBox.Controls.Add(this.ShiftAccuratelyOZBox);
            this.ShiftAccuratelyGroupBox.Controls.Add(this.ShiftAccuratelyOYBox);
            this.ShiftAccuratelyGroupBox.Controls.Add(this.ShiftAccuratelyOXBox);
            this.ShiftAccuratelyGroupBox.Location = new System.Drawing.Point(3, 95);
            this.ShiftAccuratelyGroupBox.Name = "ShiftAccuratelyGroupBox";
            this.ShiftAccuratelyGroupBox.Size = new System.Drawing.Size(270, 148);
            this.ShiftAccuratelyGroupBox.TabIndex = 2;
            this.ShiftAccuratelyGroupBox.TabStop = false;
            this.ShiftAccuratelyGroupBox.Text = "Точный сдвиг";
            this.ShiftAccuratelyGroupBox.Visible = false;
            // 
            // ShiftAccuratelyButton
            // 
            this.ShiftAccuratelyButton.Location = new System.Drawing.Point(117, 50);
            this.ShiftAccuratelyButton.Name = "ShiftAccuratelyButton";
            this.ShiftAccuratelyButton.Size = new System.Drawing.Size(80, 24);
            this.ShiftAccuratelyButton.TabIndex = 6;
            this.ShiftAccuratelyButton.Text = "Выполнить";
            this.ShiftAccuratelyButton.UseVisualStyleBackColor = true;
            this.ShiftAccuratelyButton.Click += new System.EventHandler(this.ShiftAccuratelyButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "OZ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "OY";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "OX";
            // 
            // ShiftAccuratelyOZBox
            // 
            this.ShiftAccuratelyOZBox.Location = new System.Drawing.Point(36, 76);
            this.ShiftAccuratelyOZBox.Name = "ShiftAccuratelyOZBox";
            this.ShiftAccuratelyOZBox.Size = new System.Drawing.Size(42, 20);
            this.ShiftAccuratelyOZBox.TabIndex = 2;
            this.ShiftAccuratelyOZBox.Text = "0";
            this.ShiftAccuratelyOZBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShiftAccuratelyOZBox_KeyPress);
            // 
            // ShiftAccuratelyOYBox
            // 
            this.ShiftAccuratelyOYBox.Location = new System.Drawing.Point(36, 50);
            this.ShiftAccuratelyOYBox.Name = "ShiftAccuratelyOYBox";
            this.ShiftAccuratelyOYBox.Size = new System.Drawing.Size(42, 20);
            this.ShiftAccuratelyOYBox.TabIndex = 1;
            this.ShiftAccuratelyOYBox.Text = "0";
            this.ShiftAccuratelyOYBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShiftAccuratelyOYBox_KeyPress);
            // 
            // ShiftAccuratelyOXBox
            // 
            this.ShiftAccuratelyOXBox.Location = new System.Drawing.Point(36, 22);
            this.ShiftAccuratelyOXBox.Name = "ShiftAccuratelyOXBox";
            this.ShiftAccuratelyOXBox.Size = new System.Drawing.Size(42, 20);
            this.ShiftAccuratelyOXBox.TabIndex = 0;
            this.ShiftAccuratelyOXBox.Text = "0";
            this.ShiftAccuratelyOXBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShiftAccuratelyOXBox_KeyPress);
            // 
            // ShiftRoughGroupBox
            // 
            this.ShiftRoughGroupBox.Controls.Add(this.ShiftRoughRightButton);
            this.ShiftRoughGroupBox.Controls.Add(this.ShiftRoughLeftButton);
            this.ShiftRoughGroupBox.Controls.Add(this.ShiftRoughTextBox);
            this.ShiftRoughGroupBox.Controls.Add(this.ShiftRoughcheckedListBox);
            this.ShiftRoughGroupBox.Location = new System.Drawing.Point(3, 95);
            this.ShiftRoughGroupBox.Name = "ShiftRoughGroupBox";
            this.ShiftRoughGroupBox.Size = new System.Drawing.Size(270, 148);
            this.ShiftRoughGroupBox.TabIndex = 1;
            this.ShiftRoughGroupBox.TabStop = false;
            this.ShiftRoughGroupBox.Text = "Грубый сдвиг";
            // 
            // ShiftRoughRightButton
            // 
            this.ShiftRoughRightButton.Location = new System.Drawing.Point(122, 95);
            this.ShiftRoughRightButton.Name = "ShiftRoughRightButton";
            this.ShiftRoughRightButton.Size = new System.Drawing.Size(75, 23);
            this.ShiftRoughRightButton.TabIndex = 3;
            this.ShiftRoughRightButton.Text = ">>>";
            this.ShiftRoughRightButton.UseVisualStyleBackColor = true;
            this.ShiftRoughRightButton.Click += new System.EventHandler(this.ShiftRoughRightButton_Click);
            // 
            // ShiftRoughLeftButton
            // 
            this.ShiftRoughLeftButton.Location = new System.Drawing.Point(41, 95);
            this.ShiftRoughLeftButton.Name = "ShiftRoughLeftButton";
            this.ShiftRoughLeftButton.Size = new System.Drawing.Size(75, 23);
            this.ShiftRoughLeftButton.TabIndex = 2;
            this.ShiftRoughLeftButton.Text = "<<<";
            this.ShiftRoughLeftButton.UseVisualStyleBackColor = true;
            this.ShiftRoughLeftButton.Click += new System.EventHandler(this.ShiftRoughLeftButton_Click);
            // 
            // ShiftRoughTextBox
            // 
            this.ShiftRoughTextBox.Location = new System.Drawing.Point(76, 32);
            this.ShiftRoughTextBox.Name = "ShiftRoughTextBox";
            this.ShiftRoughTextBox.Size = new System.Drawing.Size(100, 20);
            this.ShiftRoughTextBox.TabIndex = 1;
            this.ShiftRoughTextBox.Text = "0";
            this.ShiftRoughTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ShiftRoughTextBox_KeyPress);
            // 
            // ShiftRoughcheckedListBox
            // 
            this.ShiftRoughcheckedListBox.CheckOnClick = true;
            this.ShiftRoughcheckedListBox.FormattingEnabled = true;
            this.ShiftRoughcheckedListBox.Items.AddRange(new object[] {
            "OX",
            "OY",
            "OZ"});
            this.ShiftRoughcheckedListBox.Location = new System.Drawing.Point(11, 19);
            this.ShiftRoughcheckedListBox.Name = "ShiftRoughcheckedListBox";
            this.ShiftRoughcheckedListBox.Size = new System.Drawing.Size(59, 49);
            this.ShiftRoughcheckedListBox.TabIndex = 0;
            // 
            // ShiftSelectGroupBox
            // 
            this.ShiftSelectGroupBox.Controls.Add(this.ShiftAccuratelyRB);
            this.ShiftSelectGroupBox.Controls.Add(this.ShiftRoughRB);
            this.ShiftSelectGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShiftSelectGroupBox.Location = new System.Drawing.Point(3, 16);
            this.ShiftSelectGroupBox.Name = "ShiftSelectGroupBox";
            this.ShiftSelectGroupBox.Size = new System.Drawing.Size(312, 73);
            this.ShiftSelectGroupBox.TabIndex = 0;
            this.ShiftSelectGroupBox.TabStop = false;
            this.ShiftSelectGroupBox.Text = "Как?";
            // 
            // ShiftAccuratelyRB
            // 
            this.ShiftAccuratelyRB.AutoSize = true;
            this.ShiftAccuratelyRB.Location = new System.Drawing.Point(6, 42);
            this.ShiftAccuratelyRB.Name = "ShiftAccuratelyRB";
            this.ShiftAccuratelyRB.Size = new System.Drawing.Size(55, 17);
            this.ShiftAccuratelyRB.TabIndex = 1;
            this.ShiftAccuratelyRB.Text = "Точно";
            this.ShiftAccuratelyRB.UseVisualStyleBackColor = true;
            this.ShiftAccuratelyRB.CheckedChanged += new System.EventHandler(this.ShiftAccuratelyRB_CheckedChanged);
            // 
            // ShiftRoughRB
            // 
            this.ShiftRoughRB.AutoSize = true;
            this.ShiftRoughRB.Checked = true;
            this.ShiftRoughRB.Location = new System.Drawing.Point(6, 19);
            this.ShiftRoughRB.Name = "ShiftRoughRB";
            this.ShiftRoughRB.Size = new System.Drawing.Size(54, 17);
            this.ShiftRoughRB.TabIndex = 0;
            this.ShiftRoughRB.TabStop = true;
            this.ShiftRoughRB.Text = "Грубо";
            this.ShiftRoughRB.UseVisualStyleBackColor = true;
            this.ShiftRoughRB.CheckedChanged += new System.EventHandler(this.ShiftRoughRB_CheckedChanged);
            // 
            // CreateTab
            // 
            this.CreateTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.CreateTab.Controls.Add(this.CreateGroupBox);
            this.CreateTab.Location = new System.Drawing.Point(4, 5);
            this.CreateTab.Name = "CreateTab";
            this.CreateTab.Size = new System.Drawing.Size(318, 591);
            this.CreateTab.TabIndex = 3;
            this.CreateTab.Text = "Создать";
            // 
            // CreateGroupBox
            // 
            this.CreateGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.CreateGroupBox.Controls.Add(this.DeleteEdgeButton);
            this.CreateGroupBox.Controls.Add(this.label5);
            this.CreateGroupBox.Controls.Add(this.EditEdgeButton);
            this.CreateGroupBox.Controls.Add(this.VertexGrid);
            this.CreateGroupBox.Controls.Add(this.AddEdgeButton);
            this.CreateGroupBox.Controls.Add(this.EdgesGrid);
            this.CreateGroupBox.Controls.Add(this.label11);
            this.CreateGroupBox.Controls.Add(this.label6);
            this.CreateGroupBox.Controls.Add(this.label12);
            this.CreateGroupBox.Controls.Add(this.vertexTB_X);
            this.CreateGroupBox.Controls.Add(this.edgeTB_end);
            this.CreateGroupBox.Controls.Add(this.vertexTB_Y);
            this.CreateGroupBox.Controls.Add(this.edgeTB_start);
            this.CreateGroupBox.Controls.Add(this.vertexTB_Z);
            this.CreateGroupBox.Controls.Add(this.DeleteVertexButton);
            this.CreateGroupBox.Controls.Add(this.label7);
            this.CreateGroupBox.Controls.Add(this.EditVertexButton);
            this.CreateGroupBox.Controls.Add(this.label8);
            this.CreateGroupBox.Controls.Add(this.AddVertexButton);
            this.CreateGroupBox.Controls.Add(this.label9);
            this.CreateGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreateGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateGroupBox.Location = new System.Drawing.Point(0, 0);
            this.CreateGroupBox.Name = "CreateGroupBox";
            this.CreateGroupBox.Size = new System.Drawing.Size(318, 591);
            this.CreateGroupBox.TabIndex = 22;
            this.CreateGroupBox.TabStop = false;
            this.CreateGroupBox.Text = "Создать";
            // 
            // DeleteEdgeButton
            // 
            this.DeleteEdgeButton.Location = new System.Drawing.Point(203, 525);
            this.DeleteEdgeButton.Name = "DeleteEdgeButton";
            this.DeleteEdgeButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteEdgeButton.TabIndex = 21;
            this.DeleteEdgeButton.Text = "Удалить";
            this.DeleteEdgeButton.UseVisualStyleBackColor = true;
            this.DeleteEdgeButton.Click += new System.EventHandler(this.DeleteEdgeButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(115, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Вершины";
            // 
            // EditEdgeButton
            // 
            this.EditEdgeButton.Location = new System.Drawing.Point(203, 496);
            this.EditEdgeButton.Name = "EditEdgeButton";
            this.EditEdgeButton.Size = new System.Drawing.Size(75, 23);
            this.EditEdgeButton.TabIndex = 20;
            this.EditEdgeButton.Text = "Изменить";
            this.EditEdgeButton.UseVisualStyleBackColor = true;
            this.EditEdgeButton.Click += new System.EventHandler(this.EditEdgeButton_Click);
            // 
            // VertexGrid
            // 
            this.VertexGrid.AllowUserToAddRows = false;
            this.VertexGrid.AllowUserToDeleteRows = false;
            this.VertexGrid.AllowUserToResizeColumns = false;
            this.VertexGrid.AllowUserToResizeRows = false;
            this.VertexGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VertexGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.x,
            this.y,
            this.z});
            this.VertexGrid.Location = new System.Drawing.Point(16, 32);
            this.VertexGrid.MultiSelect = false;
            this.VertexGrid.Name = "VertexGrid";
            this.VertexGrid.ReadOnly = true;
            this.VertexGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VertexGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VertexGrid.Size = new System.Drawing.Size(292, 162);
            this.VertexGrid.TabIndex = 0;
            this.VertexGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.VertexGrid_RowsAdded);
            this.VertexGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.VertexGrid_RowsRemoved);
            // 
            // AddEdgeButton
            // 
            this.AddEdgeButton.Location = new System.Drawing.Point(203, 467);
            this.AddEdgeButton.Name = "AddEdgeButton";
            this.AddEdgeButton.Size = new System.Drawing.Size(75, 23);
            this.AddEdgeButton.TabIndex = 19;
            this.AddEdgeButton.Text = "Добавить";
            this.AddEdgeButton.UseVisualStyleBackColor = true;
            this.AddEdgeButton.Click += new System.EventHandler(this.AddEdgeButton_Click);
            // 
            // EdgesGrid
            // 
            this.EdgesGrid.AllowUserToAddRows = false;
            this.EdgesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.EdgesGrid.Location = new System.Drawing.Point(16, 302);
            this.EdgesGrid.Name = "EdgesGrid";
            this.EdgesGrid.Size = new System.Drawing.Size(292, 159);
            this.EdgesGrid.TabIndex = 1;
            this.EdgesGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.EdgesGrid_RowsAdded);
            this.EdgesGrid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.EdgesGrid_RowsRemoved);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Начало";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Конец";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(118, 482);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Конец";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(115, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Рёбра";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(66, 482);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Начало";
            // 
            // vertexTB_X
            // 
            this.vertexTB_X.Location = new System.Drawing.Point(57, 230);
            this.vertexTB_X.Name = "vertexTB_X";
            this.vertexTB_X.Size = new System.Drawing.Size(33, 20);
            this.vertexTB_X.TabIndex = 4;
            this.vertexTB_X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vertexTB_X_KeyPress);
            // 
            // edgeTB_end
            // 
            this.edgeTB_end.Location = new System.Drawing.Point(121, 498);
            this.edgeTB_end.Name = "edgeTB_end";
            this.edgeTB_end.Size = new System.Drawing.Size(33, 20);
            this.edgeTB_end.TabIndex = 14;
            this.edgeTB_end.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edgeTB_end_KeyPress);
            // 
            // vertexTB_Y
            // 
            this.vertexTB_Y.Location = new System.Drawing.Point(98, 230);
            this.vertexTB_Y.Name = "vertexTB_Y";
            this.vertexTB_Y.Size = new System.Drawing.Size(33, 20);
            this.vertexTB_Y.TabIndex = 5;
            this.vertexTB_Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vertexTB_Y_KeyPress);
            // 
            // edgeTB_start
            // 
            this.edgeTB_start.Location = new System.Drawing.Point(69, 498);
            this.edgeTB_start.Name = "edgeTB_start";
            this.edgeTB_start.Size = new System.Drawing.Size(33, 20);
            this.edgeTB_start.TabIndex = 13;
            this.edgeTB_start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edgeTB_start_KeyPress);
            // 
            // vertexTB_Z
            // 
            this.vertexTB_Z.Location = new System.Drawing.Point(139, 230);
            this.vertexTB_Z.Name = "vertexTB_Z";
            this.vertexTB_Z.Size = new System.Drawing.Size(33, 20);
            this.vertexTB_Z.TabIndex = 6;
            this.vertexTB_Z.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vertexTB_Z_KeyPress);
            // 
            // DeleteVertexButton
            // 
            this.DeleteVertexButton.Location = new System.Drawing.Point(203, 257);
            this.DeleteVertexButton.Name = "DeleteVertexButton";
            this.DeleteVertexButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteVertexButton.TabIndex = 12;
            this.DeleteVertexButton.Text = "Удалить";
            this.DeleteVertexButton.UseVisualStyleBackColor = true;
            this.DeleteVertexButton.Click += new System.EventHandler(this.DeleteVertexButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "X";
            // 
            // EditVertexButton
            // 
            this.EditVertexButton.Location = new System.Drawing.Point(203, 228);
            this.EditVertexButton.Name = "EditVertexButton";
            this.EditVertexButton.Size = new System.Drawing.Size(75, 23);
            this.EditVertexButton.TabIndex = 11;
            this.EditVertexButton.Text = "Изменить";
            this.EditVertexButton.UseVisualStyleBackColor = true;
            this.EditVertexButton.Click += new System.EventHandler(this.EditVertexButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(107, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Y";
            // 
            // AddVertexButton
            // 
            this.AddVertexButton.Location = new System.Drawing.Point(203, 200);
            this.AddVertexButton.Name = "AddVertexButton";
            this.AddVertexButton.Size = new System.Drawing.Size(75, 23);
            this.AddVertexButton.TabIndex = 10;
            this.AddVertexButton.Text = "Добавить";
            this.AddVertexButton.UseVisualStyleBackColor = true;
            this.AddVertexButton.Click += new System.EventHandler(this.AddVertexButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(146, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Z";
            // 
            // StartTab
            // 
            this.StartTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.StartTab.Controls.Add(this.label21);
            this.StartTab.Location = new System.Drawing.Point(4, 24);
            this.StartTab.Name = "StartTab";
            this.StartTab.Size = new System.Drawing.Size(318, 572);
            this.StartTab.TabIndex = 4;
            this.StartTab.Text = "StartTab";
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(0, 0);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(318, 572);
            this.label21.TabIndex = 0;
            this.label21.Text = "Начни работу с пункта \"Файл\" :)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(207)))), ((int)(((byte)(217)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tss_TX,
            this.tss_TY,
            this.tss_TZ,
            this.toolStripStatusLabel5,
            this.tss_RX,
            this.tss_RY,
            this.tss_RZ,
            this.toolStripStatusLabel9,
            this.tss_SX,
            this.tss_SY,
            this.tss_SZ});
            this.statusStrip.Location = new System.Drawing.Point(0, 678);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip.Size = new System.Drawing.Size(1019, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Сдвиг";
            // 
            // tss_TX
            // 
            this.tss_TX.AutoSize = false;
            this.tss_TX.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss_TX.Name = "tss_TX";
            this.tss_TX.Size = new System.Drawing.Size(50, 17);
            this.tss_TX.Text = "Tx=";
            this.tss_TX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tss_TY
            // 
            this.tss_TY.AutoSize = false;
            this.tss_TY.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss_TY.Name = "tss_TY";
            this.tss_TY.Size = new System.Drawing.Size(50, 17);
            this.tss_TY.Text = "Ty=";
            this.tss_TY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tss_TZ
            // 
            this.tss_TZ.AutoSize = false;
            this.tss_TZ.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss_TZ.Name = "tss_TZ";
            this.tss_TZ.Size = new System.Drawing.Size(50, 17);
            this.tss_TZ.Text = "Tz=";
            this.tss_TZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel5.Text = "Поворот";
            // 
            // tss_RX
            // 
            this.tss_RX.AutoSize = false;
            this.tss_RX.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss_RX.Name = "tss_RX";
            this.tss_RX.Size = new System.Drawing.Size(50, 17);
            this.tss_RX.Text = "Rx=";
            this.tss_RX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tss_RY
            // 
            this.tss_RY.AutoSize = false;
            this.tss_RY.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss_RY.Name = "tss_RY";
            this.tss_RY.Size = new System.Drawing.Size(50, 17);
            this.tss_RY.Text = "Ry=";
            this.tss_RY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tss_RZ
            // 
            this.tss_RZ.AutoSize = false;
            this.tss_RZ.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss_RZ.Name = "tss_RZ";
            this.tss_RZ.Size = new System.Drawing.Size(50, 17);
            this.tss_RZ.Text = "Rz=";
            this.tss_RZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel9.Text = "Масштаб";
            // 
            // tss_SX
            // 
            this.tss_SX.AutoSize = false;
            this.tss_SX.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss_SX.Name = "tss_SX";
            this.tss_SX.Size = new System.Drawing.Size(50, 17);
            this.tss_SX.Text = "Sx=";
            this.tss_SX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tss_SY
            // 
            this.tss_SY.AutoSize = false;
            this.tss_SY.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss_SY.Name = "tss_SY";
            this.tss_SY.Size = new System.Drawing.Size(50, 17);
            this.tss_SY.Text = "Sy=";
            this.tss_SY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tss_SZ
            // 
            this.tss_SZ.AutoSize = false;
            this.tss_SZ.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tss_SZ.Name = "tss_SZ";
            this.tss_SZ.Size = new System.Drawing.Size(50, 17);
            this.tss_SZ.Text = "Sz=";
            this.tss_SZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Visible = false;
            this.Column1.Width = 50;
            // 
            // x
            // 
            this.x.HeaderText = "X";
            this.x.Name = "x";
            this.x.ReadOnly = true;
            this.x.Width = 50;
            // 
            // y
            // 
            this.y.HeaderText = "Y";
            this.y.Name = "y";
            this.y.ReadOnly = true;
            this.y.Width = 50;
            // 
            // z
            // 
            this.z.HeaderText = "Z";
            this.z.Name = "z";
            this.z.ReadOnly = true;
            this.z.Width = 50;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::GraphicalEditor.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1019, 700);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(920, 686);
            this.Name = "MainForm";
            this.Text = "Графический редактор by nikitenich";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.izomPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xoyPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xozPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yozPic)).EndInit();
            this.ActionTabs.ResumeLayout(false);
            this.ScaleTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ScaleAccuratelyGroupBox.ResumeLayout(false);
            this.ScaleAccuratelyGroupBox.PerformLayout();
            this.ScaleRoughGroupBox.ResumeLayout(false);
            this.ScaleRoughGroupBox.PerformLayout();
            this.ScaleSelectGroupBox.ResumeLayout(false);
            this.ScaleSelectGroupBox.PerformLayout();
            this.RotateTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.RotateAccuratelyGroupBox.ResumeLayout(false);
            this.RotateAccuratelyGroupBox.PerformLayout();
            this.RotateRoughGroupBox.ResumeLayout(false);
            this.RotateRoughGroupBox.PerformLayout();
            this.RotateSelectGroupBox.ResumeLayout(false);
            this.RotateSelectGroupBox.PerformLayout();
            this.ShiftTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ShiftAccuratelyGroupBox.ResumeLayout(false);
            this.ShiftAccuratelyGroupBox.PerformLayout();
            this.ShiftRoughGroupBox.ResumeLayout(false);
            this.ShiftRoughGroupBox.PerformLayout();
            this.ShiftSelectGroupBox.ResumeLayout(false);
            this.ShiftSelectGroupBox.PerformLayout();
            this.CreateTab.ResumeLayout(false);
            this.CreateGroupBox.ResumeLayout(false);
            this.CreateGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VertexGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdgesGrid)).EndInit();
            this.StartTab.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tss_TZ;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl ActionTabs;
        private System.Windows.Forms.TabPage ScaleTab;
        private System.Windows.Forms.TabPage RotateTab;
        private System.Windows.Forms.TabPage ShiftTab;
        private System.Windows.Forms.TabPage CreateTab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView EdgesGrid;
        private System.Windows.Forms.DataGridView VertexGrid;
        private System.Windows.Forms.TabPage StartTab;
        private System.Windows.Forms.Button DeleteVertexButton;
        private System.Windows.Forms.Button EditVertexButton;
        private System.Windows.Forms.Button AddVertexButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox vertexTB_Z;
        private System.Windows.Forms.TextBox vertexTB_Y;
        private System.Windows.Forms.TextBox vertexTB_X;
        private System.Windows.Forms.GroupBox CreateGroupBox;
        private System.Windows.Forms.Button DeleteEdgeButton;
        private System.Windows.Forms.Button EditEdgeButton;
        private System.Windows.Forms.Button AddEdgeButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox edgeTB_end;
        private System.Windows.Forms.TextBox edgeTB_start;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox ShiftSelectGroupBox;
        private System.Windows.Forms.RadioButton ShiftAccuratelyRB;
        private System.Windows.Forms.RadioButton ShiftRoughRB;
        private System.Windows.Forms.GroupBox ShiftAccuratelyGroupBox;
        private System.Windows.Forms.GroupBox ShiftRoughGroupBox;
        private System.Windows.Forms.Button ShiftAccuratelyButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ShiftAccuratelyOZBox;
        private System.Windows.Forms.TextBox ShiftAccuratelyOYBox;
        private System.Windows.Forms.TextBox ShiftAccuratelyOXBox;
        private System.Windows.Forms.CheckedListBox ShiftRoughcheckedListBox;
        private System.Windows.Forms.Button ShiftRoughRightButton;
        private System.Windows.Forms.Button ShiftRoughLeftButton;
        private System.Windows.Forms.TextBox ShiftRoughTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox ScaleAccuratelyGroupBox;
        private System.Windows.Forms.Button ScaleAccuratelyButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox ScaleAccuratelyOZBox;
        private System.Windows.Forms.TextBox ScaleAccuratelyOYBox;
        private System.Windows.Forms.TextBox ScaleAccuratelyOXBox;
        private System.Windows.Forms.GroupBox ScaleRoughGroupBox;
        private System.Windows.Forms.Button ScaleButton;
        private System.Windows.Forms.TextBox ScaleRoughTextBox;
        private System.Windows.Forms.CheckedListBox ScaleRoughcheckedListBox;
        private System.Windows.Forms.GroupBox ScaleSelectGroupBox;
        private System.Windows.Forms.RadioButton ScaleAccuratelyRB;
        private System.Windows.Forms.RadioButton ScaleRoughRB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox RotateAccuratelyGroupBox;
        private System.Windows.Forms.Button RotateAccuratelyButton;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox RotateAccuratelyOZBox;
        private System.Windows.Forms.TextBox RotateAccuratelyOYBox;
        private System.Windows.Forms.TextBox RotateAccuratelyOXBox;
        private System.Windows.Forms.GroupBox RotateRoughGroupBox;
        private System.Windows.Forms.Button RotateRoughRightButton;
        private System.Windows.Forms.Button RotateRoughLeftButton;
        private System.Windows.Forms.TextBox RotateRoughTextBox;
        private System.Windows.Forms.CheckedListBox RotateRoughcheckedListBox;
        private System.Windows.Forms.GroupBox RotateSelectGroupBox;
        private System.Windows.Forms.RadioButton RotateAccuratelyRB;
        private System.Windows.Forms.RadioButton RotateRoughRB;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ToolStripStatusLabel tss_TX;
        private System.Windows.Forms.ToolStripStatusLabel tss_TY;
        private System.Windows.Forms.ToolStripStatusLabel tss_RX;
        private System.Windows.Forms.ToolStripStatusLabel tss_RY;
        private System.Windows.Forms.ToolStripStatusLabel tss_RZ;
        private System.Windows.Forms.ToolStripStatusLabel tss_SX;
        private System.Windows.Forms.ToolStripStatusLabel tss_SY;
        private System.Windows.Forms.ToolStripStatusLabel tss_SZ;
        private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.PictureBox yozPic;
        private System.Windows.Forms.PictureBox izomPic;
        private System.Windows.Forms.PictureBox xoyPic;
        private System.Windows.Forms.PictureBox xozPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn x;
        private System.Windows.Forms.DataGridViewTextBoxColumn y;
        private System.Windows.Forms.DataGridViewTextBoxColumn z;
    }
}

