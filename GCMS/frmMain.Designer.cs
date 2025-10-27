namespace GCMS
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.btnRenters = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.SST = new System.Windows.Forms.StatusStrip();
            this.SSTLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnUsername = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnUsersManagement = new System.Windows.Forms.Button();
            this.btnGamesManagement = new System.Windows.Forms.Button();
            this.btnStore = new System.Windows.Forms.Button();
            this.btnDebts = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWatchDateTime = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tcGAMES = new System.Windows.Forms.TabControl();
            this.tabPlaystation = new System.Windows.Forms.TabPage();
            this.flpPlaystations = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPool = new System.Windows.Forms.TabPage();
            this.flpPoolTables = new System.Windows.Forms.FlowLayoutPanel();
            this.tabTennisTable = new System.Windows.Forms.TabPage();
            this.flpTennisTables = new System.Windows.Forms.FlowLayoutPanel();
            this.tabFoosballTable = new System.Windows.Forms.TabPage();
            this.flpFoosballTables = new System.Windows.Forms.FlowLayoutPanel();
            this.tabChessTable = new System.Windows.Forms.TabPage();
            this.flpChessTables = new System.Windows.Forms.FlowLayoutPanel();
            this.tabDeviceRentals = new System.Windows.Forms.TabPage();
            this.flpDeviceRentals = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTotalCash = new System.Windows.Forms.Panel();
            this.lblTotalCash = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTotalHours = new System.Windows.Forms.Panel();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TimerClock = new System.Windows.Forms.Timer(this.components);
            this.pnlDashboard.SuspendLayout();
            this.SST.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tcGAMES.SuspendLayout();
            this.tabPlaystation.SuspendLayout();
            this.tabPool.SuspendLayout();
            this.tabTennisTable.SuspendLayout();
            this.tabFoosballTable.SuspendLayout();
            this.tabChessTable.SuspendLayout();
            this.tabDeviceRentals.SuspendLayout();
            this.pnlTotalCash.SuspendLayout();
            this.pnlTotalHours.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pnlDashboard.Controls.Add(this.btnRenters);
            this.pnlDashboard.Controls.Add(this.btnReports);
            this.pnlDashboard.Controls.Add(this.SST);
            this.pnlDashboard.Controls.Add(this.btnUsername);
            this.pnlDashboard.Controls.Add(this.pictureBox1);
            this.pnlDashboard.Controls.Add(this.btnUsersManagement);
            this.pnlDashboard.Controls.Add(this.btnGamesManagement);
            this.pnlDashboard.Controls.Add(this.btnStore);
            this.pnlDashboard.Controls.Add(this.btnDebts);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(390, 764);
            this.pnlDashboard.TabIndex = 0;
            this.pnlDashboard.MouseHover += new System.EventHandler(this.pnlDashboard_MouseHover);
            // 
            // btnRenters
            // 
            this.btnRenters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnRenters.FlatAppearance.BorderSize = 0;
            this.btnRenters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRenters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenters.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenters.ForeColor = System.Drawing.Color.White;
            this.btnRenters.Image = global::GCMS.Properties.Resources.Rentals_img_48;
            this.btnRenters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenters.Location = new System.Drawing.Point(4, 577);
            this.btnRenters.Name = "btnRenters";
            this.btnRenters.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRenters.Size = new System.Drawing.Size(390, 66);
            this.btnRenters.TabIndex = 9;
            this.btnRenters.Text = "Renters";
            this.btnRenters.UseVisualStyleBackColor = false;
            this.btnRenters.Click += new System.EventHandler(this.Renters_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::GCMS.Properties.Resources.system_management_img_48;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 505);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(387, 66);
            this.btnReports.TabIndex = 8;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            this.btnReports.MouseHover += new System.EventHandler(this.btnReports_MouseHover);
            // 
            // SST
            // 
            this.SST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.SST.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SSTLabel1});
            this.SST.Location = new System.Drawing.Point(0, 730);
            this.SST.Name = "SST";
            this.SST.Size = new System.Drawing.Size(390, 34);
            this.SST.TabIndex = 7;
            this.SST.Text = "statusStrip1";
            // 
            // SSTLabel1
            // 
            this.SSTLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSTLabel1.ForeColor = System.Drawing.Color.White;
            this.SSTLabel1.Name = "SSTLabel1";
            this.SSTLabel1.Size = new System.Drawing.Size(180, 28);
            this.SSTLabel1.Text = "Welcom to GCMS ..";
            // 
            // btnUsername
            // 
            this.btnUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnUsername.FlatAppearance.BorderSize = 0;
            this.btnUsername.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsername.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsername.ForeColor = System.Drawing.Color.White;
            this.btnUsername.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsername.Location = new System.Drawing.Point(-3, 177);
            this.btnUsername.Name = "btnUsername";
            this.btnUsername.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUsername.Size = new System.Drawing.Size(393, 66);
            this.btnUsername.TabIndex = 6;
            this.btnUsername.Text = "Username";
            this.btnUsername.UseVisualStyleBackColor = false;
            this.btnUsername.Click += new System.EventHandler(this.btnUsername_Click);
            this.btnUsername.MouseHover += new System.EventHandler(this.btnUser_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GCMS.Properties.Resources.user_img_96;
            this.pictureBox1.Location = new System.Drawing.Point(150, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // btnUsersManagement
            // 
            this.btnUsersManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnUsersManagement.FlatAppearance.BorderSize = 0;
            this.btnUsersManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnUsersManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsersManagement.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsersManagement.ForeColor = System.Drawing.Color.White;
            this.btnUsersManagement.Image = global::GCMS.Properties.Resources.account_setting_img_48;
            this.btnUsersManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsersManagement.Location = new System.Drawing.Point(1, 649);
            this.btnUsersManagement.Name = "btnUsersManagement";
            this.btnUsersManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnUsersManagement.Size = new System.Drawing.Size(390, 66);
            this.btnUsersManagement.TabIndex = 4;
            this.btnUsersManagement.Text = "Users Management";
            this.btnUsersManagement.UseVisualStyleBackColor = false;
            this.btnUsersManagement.Click += new System.EventHandler(this.btnUsersManagement_Click);
            this.btnUsersManagement.MouseHover += new System.EventHandler(this.btnAccountSetting_MouseHover);
            // 
            // btnGamesManagement
            // 
            this.btnGamesManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnGamesManagement.FlatAppearance.BorderSize = 0;
            this.btnGamesManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGamesManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGamesManagement.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGamesManagement.ForeColor = System.Drawing.Color.White;
            this.btnGamesManagement.Image = global::GCMS.Properties.Resources.Edit_img_48;
            this.btnGamesManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGamesManagement.Location = new System.Drawing.Point(0, 435);
            this.btnGamesManagement.Name = "btnGamesManagement";
            this.btnGamesManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGamesManagement.Size = new System.Drawing.Size(387, 66);
            this.btnGamesManagement.TabIndex = 3;
            this.btnGamesManagement.Text = "Games Managment";
            this.btnGamesManagement.UseVisualStyleBackColor = false;
            this.btnGamesManagement.Click += new System.EventHandler(this.btnGamesManagement_Click);
            this.btnGamesManagement.MouseHover += new System.EventHandler(this.btnManagement_MouseHover);
            // 
            // btnStore
            // 
            this.btnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnStore.FlatAppearance.BorderSize = 0;
            this.btnStore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnStore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStore.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStore.ForeColor = System.Drawing.Color.White;
            this.btnStore.Image = global::GCMS.Properties.Resources.store_img_48;
            this.btnStore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStore.Location = new System.Drawing.Point(0, 365);
            this.btnStore.Name = "btnStore";
            this.btnStore.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStore.Size = new System.Drawing.Size(390, 66);
            this.btnStore.TabIndex = 2;
            this.btnStore.Text = "Store";
            this.btnStore.UseVisualStyleBackColor = false;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            this.btnStore.MouseHover += new System.EventHandler(this.btnStore_MouseHover);
            // 
            // btnDebts
            // 
            this.btnDebts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnDebts.FlatAppearance.BorderSize = 0;
            this.btnDebts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnDebts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebts.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDebts.ForeColor = System.Drawing.Color.White;
            this.btnDebts.Image = global::GCMS.Properties.Resources.debts_img_48;
            this.btnDebts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDebts.Location = new System.Drawing.Point(0, 295);
            this.btnDebts.Name = "btnDebts";
            this.btnDebts.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDebts.Size = new System.Drawing.Size(390, 66);
            this.btnDebts.TabIndex = 1;
            this.btnDebts.Text = "Debts";
            this.btnDebts.UseVisualStyleBackColor = false;
            this.btnDebts.Click += new System.EventHandler(this.btnDebts_Click);
            this.btnDebts.MouseHover += new System.EventHandler(this.btnDebts_MouseHover);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel2.Controls.Add(this.lblWatchDateTime);
            this.panel2.Controls.Add(this.btnMinimize);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(390, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(887, 43);
            this.panel2.TabIndex = 1;
            // 
            // lblWatchDateTime
            // 
            this.lblWatchDateTime.AutoSize = true;
            this.lblWatchDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWatchDateTime.ForeColor = System.Drawing.Color.White;
            this.lblWatchDateTime.Location = new System.Drawing.Point(488, 11);
            this.lblWatchDateTime.Name = "lblWatchDateTime";
            this.lblWatchDateTime.Size = new System.Drawing.Size(103, 29);
            this.lblWatchDateTime.TabIndex = 10;
            this.lblWatchDateTime.Text = "00:00:00";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(757, 8);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(56, 32);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "---";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(828, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel3.Location = new System.Drawing.Point(112, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 22);
            this.panel3.TabIndex = 2;
            // 
            // tcGAMES
            // 
            this.tcGAMES.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcGAMES.Controls.Add(this.tabPlaystation);
            this.tcGAMES.Controls.Add(this.tabPool);
            this.tcGAMES.Controls.Add(this.tabTennisTable);
            this.tcGAMES.Controls.Add(this.tabFoosballTable);
            this.tcGAMES.Controls.Add(this.tabChessTable);
            this.tcGAMES.Controls.Add(this.tabDeviceRentals);
            this.tcGAMES.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcGAMES.Location = new System.Drawing.Point(393, 136);
            this.tcGAMES.Name = "tcGAMES";
            this.tcGAMES.SelectedIndex = 0;
            this.tcGAMES.Size = new System.Drawing.Size(884, 625);
            this.tcGAMES.TabIndex = 2;
            this.tcGAMES.MouseHover += new System.EventHandler(this.tcGAMES_MouseHover);
            // 
            // tabPlaystation
            // 
            this.tabPlaystation.BackColor = System.Drawing.Color.White;
            this.tabPlaystation.Controls.Add(this.flpPlaystations);
            this.tabPlaystation.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tabPlaystation.Location = new System.Drawing.Point(4, 34);
            this.tabPlaystation.Name = "tabPlaystation";
            this.tabPlaystation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlaystation.Size = new System.Drawing.Size(876, 587);
            this.tabPlaystation.TabIndex = 3;
            this.tabPlaystation.Text = "Playstation";
            // 
            // flpPlaystations
            // 
            this.flpPlaystations.AutoScroll = true;
            this.flpPlaystations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPlaystations.Location = new System.Drawing.Point(3, 3);
            this.flpPlaystations.Name = "flpPlaystations";
            this.flpPlaystations.Size = new System.Drawing.Size(870, 581);
            this.flpPlaystations.TabIndex = 3;
            this.flpPlaystations.MouseHover += new System.EventHandler(this.flpPlaystations_MouseHover);
            // 
            // tabPool
            // 
            this.tabPool.BackColor = System.Drawing.Color.White;
            this.tabPool.Controls.Add(this.flpPoolTables);
            this.tabPool.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPool.Location = new System.Drawing.Point(4, 34);
            this.tabPool.Name = "tabPool";
            this.tabPool.Padding = new System.Windows.Forms.Padding(3);
            this.tabPool.Size = new System.Drawing.Size(876, 587);
            this.tabPool.TabIndex = 0;
            this.tabPool.Text = "Pool Tables";
            // 
            // flpPoolTables
            // 
            this.flpPoolTables.AutoScroll = true;
            this.flpPoolTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPoolTables.Location = new System.Drawing.Point(3, 3);
            this.flpPoolTables.Name = "flpPoolTables";
            this.flpPoolTables.Size = new System.Drawing.Size(870, 581);
            this.flpPoolTables.TabIndex = 0;
            this.flpPoolTables.MouseHover += new System.EventHandler(this.flpPoolTables_MouseHover);
            // 
            // tabTennisTable
            // 
            this.tabTennisTable.BackColor = System.Drawing.Color.White;
            this.tabTennisTable.Controls.Add(this.flpTennisTables);
            this.tabTennisTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTennisTable.Location = new System.Drawing.Point(4, 34);
            this.tabTennisTable.Name = "tabTennisTable";
            this.tabTennisTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTennisTable.Size = new System.Drawing.Size(876, 587);
            this.tabTennisTable.TabIndex = 1;
            this.tabTennisTable.Text = "Tennis Tables";
            // 
            // flpTennisTables
            // 
            this.flpTennisTables.AutoScroll = true;
            this.flpTennisTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTennisTables.Location = new System.Drawing.Point(3, 3);
            this.flpTennisTables.Name = "flpTennisTables";
            this.flpTennisTables.Size = new System.Drawing.Size(870, 581);
            this.flpTennisTables.TabIndex = 1;
            this.flpTennisTables.MouseHover += new System.EventHandler(this.flpTennisTables_MouseHover);
            // 
            // tabFoosballTable
            // 
            this.tabFoosballTable.BackColor = System.Drawing.Color.White;
            this.tabFoosballTable.Controls.Add(this.flpFoosballTables);
            this.tabFoosballTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tabFoosballTable.Location = new System.Drawing.Point(4, 34);
            this.tabFoosballTable.Name = "tabFoosballTable";
            this.tabFoosballTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabFoosballTable.Size = new System.Drawing.Size(876, 587);
            this.tabFoosballTable.TabIndex = 2;
            this.tabFoosballTable.Text = "Foosball Tables";
            // 
            // flpFoosballTables
            // 
            this.flpFoosballTables.AutoScroll = true;
            this.flpFoosballTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFoosballTables.Location = new System.Drawing.Point(3, 3);
            this.flpFoosballTables.Name = "flpFoosballTables";
            this.flpFoosballTables.Size = new System.Drawing.Size(870, 581);
            this.flpFoosballTables.TabIndex = 2;
            this.flpFoosballTables.MouseHover += new System.EventHandler(this.flpFoosballTables_MouseHover);
            // 
            // tabChessTable
            // 
            this.tabChessTable.BackColor = System.Drawing.Color.White;
            this.tabChessTable.Controls.Add(this.flpChessTables);
            this.tabChessTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tabChessTable.Location = new System.Drawing.Point(4, 34);
            this.tabChessTable.Name = "tabChessTable";
            this.tabChessTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabChessTable.Size = new System.Drawing.Size(876, 587);
            this.tabChessTable.TabIndex = 4;
            this.tabChessTable.Text = "Chess Table";
            // 
            // flpChessTables
            // 
            this.flpChessTables.AutoScroll = true;
            this.flpChessTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChessTables.Location = new System.Drawing.Point(3, 3);
            this.flpChessTables.Name = "flpChessTables";
            this.flpChessTables.Size = new System.Drawing.Size(870, 581);
            this.flpChessTables.TabIndex = 4;
            this.flpChessTables.MouseHover += new System.EventHandler(this.flpChessTables_MouseHover);
            // 
            // tabDeviceRentals
            // 
            this.tabDeviceRentals.BackColor = System.Drawing.Color.White;
            this.tabDeviceRentals.Controls.Add(this.flpDeviceRentals);
            this.tabDeviceRentals.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tabDeviceRentals.Location = new System.Drawing.Point(4, 34);
            this.tabDeviceRentals.Name = "tabDeviceRentals";
            this.tabDeviceRentals.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeviceRentals.Size = new System.Drawing.Size(876, 587);
            this.tabDeviceRentals.TabIndex = 5;
            this.tabDeviceRentals.Text = "Device Rentals";
            // 
            // flpDeviceRentals
            // 
            this.flpDeviceRentals.AutoScroll = true;
            this.flpDeviceRentals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDeviceRentals.Location = new System.Drawing.Point(3, 3);
            this.flpDeviceRentals.Name = "flpDeviceRentals";
            this.flpDeviceRentals.Size = new System.Drawing.Size(870, 581);
            this.flpDeviceRentals.TabIndex = 5;
            this.flpDeviceRentals.MouseHover += new System.EventHandler(this.flpDeviceRentals_MouseHover);
            // 
            // pnlTotalCash
            // 
            this.pnlTotalCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlTotalCash.Controls.Add(this.lblTotalCash);
            this.pnlTotalCash.Controls.Add(this.label1);
            this.pnlTotalCash.Location = new System.Drawing.Point(419, 49);
            this.pnlTotalCash.Name = "pnlTotalCash";
            this.pnlTotalCash.Size = new System.Drawing.Size(174, 81);
            this.pnlTotalCash.TabIndex = 3;
            this.pnlTotalCash.MouseHover += new System.EventHandler(this.pnlTotalCash_MouseHover);
            // 
            // lblTotalCash
            // 
            this.lblTotalCash.AutoSize = true;
            this.lblTotalCash.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCash.ForeColor = System.Drawing.Color.White;
            this.lblTotalCash.Location = new System.Drawing.Point(69, 44);
            this.lblTotalCash.Name = "lblTotalCash";
            this.lblTotalCash.Size = new System.Drawing.Size(29, 19);
            this.lblTotalCash.TabIndex = 1;
            this.lblTotalCash.Text = "$0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(45, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Cash";
            // 
            // pnlTotalHours
            // 
            this.pnlTotalHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlTotalHours.Controls.Add(this.lblTotalTime);
            this.pnlTotalHours.Controls.Add(this.label3);
            this.pnlTotalHours.Location = new System.Drawing.Point(632, 49);
            this.pnlTotalHours.Name = "pnlTotalHours";
            this.pnlTotalHours.Size = new System.Drawing.Size(174, 81);
            this.pnlTotalHours.TabIndex = 4;
            this.pnlTotalHours.MouseHover += new System.EventHandler(this.pnlTotalHours_MouseHover);
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTime.ForeColor = System.Drawing.Color.White;
            this.lblTotalTime.Location = new System.Drawing.Point(49, 44);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(79, 19);
            this.lblTotalTime.TabIndex = 2;
            this.lblTotalTime.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Total Hours";
            // 
            // TimerClock
            // 
            this.TimerClock.Interval = 1000;
            this.TimerClock.Tick += new System.EventHandler(this.TimerClock_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1277, 764);
            this.Controls.Add(this.pnlTotalHours);
            this.Controls.Add(this.pnlTotalCash);
            this.Controls.Add(this.tcGAMES);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlDashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GCMS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MouseHover += new System.EventHandler(this.frmMain_MouseHover);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlDashboard.PerformLayout();
            this.SST.ResumeLayout(false);
            this.SST.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tcGAMES.ResumeLayout(false);
            this.tabPlaystation.ResumeLayout(false);
            this.tabPool.ResumeLayout(false);
            this.tabTennisTable.ResumeLayout(false);
            this.tabFoosballTable.ResumeLayout(false);
            this.tabChessTable.ResumeLayout(false);
            this.tabDeviceRentals.ResumeLayout(false);
            this.pnlTotalCash.ResumeLayout(false);
            this.pnlTotalCash.PerformLayout();
            this.pnlTotalHours.ResumeLayout(false);
            this.pnlTotalHours.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnGamesManagement;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Button btnDebts;
        private System.Windows.Forms.Button btnUsersManagement;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUsername;
        private System.Windows.Forms.StatusStrip SST;
        private System.Windows.Forms.ToolStripStatusLabel SSTLabel1;
        private System.Windows.Forms.TabControl tcGAMES;
        private System.Windows.Forms.TabPage tabPool;
        private System.Windows.Forms.TabPage tabTennisTable;
        private System.Windows.Forms.TabPage tabFoosballTable;
        private System.Windows.Forms.TabPage tabPlaystation;
        private System.Windows.Forms.TabPage tabChessTable;
        private System.Windows.Forms.TabPage tabDeviceRentals;
        private System.Windows.Forms.Panel pnlTotalCash;
        private System.Windows.Forms.Panel pnlTotalHours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalCash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.FlowLayoutPanel flpPoolTables;
        private System.Windows.Forms.FlowLayoutPanel flpTennisTables;
        private System.Windows.Forms.FlowLayoutPanel flpFoosballTables;
        private System.Windows.Forms.FlowLayoutPanel flpPlaystations;
        private System.Windows.Forms.FlowLayoutPanel flpChessTables;
        private System.Windows.Forms.FlowLayoutPanel flpDeviceRentals;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnRenters;
        private System.Windows.Forms.Label lblWatchDateTime;
        private System.Windows.Forms.Timer TimerClock;
    }
}