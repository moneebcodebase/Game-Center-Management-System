namespace GCMS.Renters
{
    partial class frmRenters
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddRenter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.folvRentersList = new BrightIdeasSoftware.FastObjectListView();
            this.TabRenters = new System.Windows.Forms.TabControl();
            this.RentersPage = new System.Windows.Forms.TabPage();
            this.RenterInfoPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRenterID = new System.Windows.Forms.Label();
            this.lblRenterName = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.rbBaned = new System.Windows.Forms.RadioButton();
            this.rbNotBaned = new System.Windows.Forms.RadioButton();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folvRentersList)).BeginInit();
            this.TabRenters.SuspendLayout();
            this.RentersPage.SuspendLayout();
            this.RenterInfoPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 609);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "© 2025 moneebcodebase.";
            // 
            // btnAddRenter
            // 
            this.btnAddRenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddRenter.FlatAppearance.BorderSize = 0;
            this.btnAddRenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRenter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRenter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddRenter.Image = global::GCMS.Properties.Resources.add_img_32;
            this.btnAddRenter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRenter.Location = new System.Drawing.Point(681, 95);
            this.btnAddRenter.Name = "btnAddRenter";
            this.btnAddRenter.Size = new System.Drawing.Size(183, 47);
            this.btnAddRenter.TabIndex = 21;
            this.btnAddRenter.Text = "Add Renter";
            this.btnAddRenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRenter.UseVisualStyleBackColor = false;
            this.btnAddRenter.Click += new System.EventHandler(this.btnAddRenter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GCMS.Properties.Resources.search_img_32;
            this.pictureBox1.Location = new System.Drawing.Point(25, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(73, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 27);
            this.label1.TabIndex = 18;
            this.label1.Text = "Search :";
            // 
            // tbSearch
            // 
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(193, 95);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(245, 30);
            this.tbSearch.TabIndex = 17;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::GCMS.Properties.Resources.list_img_64;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(255, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(405, 77);
            this.button1.TabIndex = 16;
            this.button1.Text = "Renters List";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // folvRentersList
            // 
            this.folvRentersList.BackColor = System.Drawing.Color.White;
            this.folvRentersList.CellEditUseWholeCell = false;
            this.folvRentersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folvRentersList.EmptyListMsg = "Did not find any renters, click the add renter button to add new renter";
            this.folvRentersList.EmptyListMsgFont = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folvRentersList.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folvRentersList.HideSelection = false;
            this.folvRentersList.Location = new System.Drawing.Point(3, 3);
            this.folvRentersList.MultiSelect = false;
            this.folvRentersList.Name = "folvRentersList";
            this.folvRentersList.ShowGroups = false;
            this.folvRentersList.Size = new System.Drawing.Size(838, 419);
            this.folvRentersList.TabIndex = 15;
            this.folvRentersList.UseCompatibleStateImageBehavior = false;
            this.folvRentersList.UseFiltering = true;
            this.folvRentersList.View = System.Windows.Forms.View.Details;
            this.folvRentersList.VirtualMode = true;
            this.folvRentersList.DoubleClick += new System.EventHandler(this.folvRentersList_DoubleClick);
            // 
            // TabRenters
            // 
            this.TabRenters.Controls.Add(this.RentersPage);
            this.TabRenters.Controls.Add(this.RenterInfoPage);
            this.TabRenters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabRenters.Location = new System.Drawing.Point(12, 148);
            this.TabRenters.Name = "TabRenters";
            this.TabRenters.SelectedIndex = 0;
            this.TabRenters.Size = new System.Drawing.Size(852, 458);
            this.TabRenters.TabIndex = 23;
            // 
            // RentersPage
            // 
            this.RentersPage.Controls.Add(this.folvRentersList);
            this.RentersPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RentersPage.Location = new System.Drawing.Point(4, 29);
            this.RentersPage.Name = "RentersPage";
            this.RentersPage.Padding = new System.Windows.Forms.Padding(3);
            this.RentersPage.Size = new System.Drawing.Size(844, 425);
            this.RentersPage.TabIndex = 0;
            this.RentersPage.Text = "Renters";
            this.RentersPage.UseVisualStyleBackColor = true;
            // 
            // RenterInfoPage
            // 
            this.RenterInfoPage.BackColor = System.Drawing.Color.Transparent;
            this.RenterInfoPage.Controls.Add(this.btnUpdateStatus);
            this.RenterInfoPage.Controls.Add(this.rbNotBaned);
            this.RenterInfoPage.Controls.Add(this.rbBaned);
            this.RenterInfoPage.Controls.Add(this.lblNationalNo);
            this.RenterInfoPage.Controls.Add(this.lblRenterName);
            this.RenterInfoPage.Controls.Add(this.lblRenterID);
            this.RenterInfoPage.Controls.Add(this.groupBox1);
            this.RenterInfoPage.Controls.Add(this.label5);
            this.RenterInfoPage.Controls.Add(this.label4);
            this.RenterInfoPage.Controls.Add(this.label3);
            this.RenterInfoPage.Location = new System.Drawing.Point(4, 29);
            this.RenterInfoPage.Name = "RenterInfoPage";
            this.RenterInfoPage.Padding = new System.Windows.Forms.Padding(3);
            this.RenterInfoPage.Size = new System.Drawing.Size(844, 425);
            this.RenterInfoPage.TabIndex = 1;
            this.RenterInfoPage.Text = "Renter Info";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPhoneNumber);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(818, 153);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contact Info";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(37, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 26;
            this.label7.Text = "Email :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Phone Number :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Renter National Number :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "Renter Full Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 22;
            this.label3.Text = "Renter ID :";
            // 
            // lblRenterID
            // 
            this.lblRenterID.AutoSize = true;
            this.lblRenterID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenterID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblRenterID.Location = new System.Drawing.Point(141, 26);
            this.lblRenterID.Name = "lblRenterID";
            this.lblRenterID.Size = new System.Drawing.Size(48, 25);
            this.lblRenterID.TabIndex = 28;
            this.lblRenterID.Text = "???";
            // 
            // lblRenterName
            // 
            this.lblRenterName.AutoSize = true;
            this.lblRenterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenterName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblRenterName.Location = new System.Drawing.Point(216, 78);
            this.lblRenterName.Name = "lblRenterName";
            this.lblRenterName.Size = new System.Drawing.Size(48, 25);
            this.lblRenterName.TabIndex = 29;
            this.lblRenterName.Text = "???";
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationalNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblNationalNo.Location = new System.Drawing.Point(264, 129);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(48, 25);
            this.lblNationalNo.TabIndex = 30;
            this.lblNationalNo.Text = "???";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblEmail.Location = new System.Drawing.Point(133, 41);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 25);
            this.lblEmail.TabIndex = 31;
            this.lblEmail.Text = "???";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblPhoneNumber.Location = new System.Drawing.Point(214, 80);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(48, 25);
            this.lblPhoneNumber.TabIndex = 32;
            this.lblPhoneNumber.Text = "???";
            // 
            // rbBaned
            // 
            this.rbBaned.AutoSize = true;
            this.rbBaned.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBaned.Location = new System.Drawing.Point(259, 360);
            this.rbBaned.Name = "rbBaned";
            this.rbBaned.Size = new System.Drawing.Size(206, 33);
            this.rbBaned.TabIndex = 31;
            this.rbBaned.TabStop = true;
            this.rbBaned.Text = "Renter Is Baned";
            this.rbBaned.UseVisualStyleBackColor = true;
            // 
            // rbNotBaned
            // 
            this.rbNotBaned.AutoSize = true;
            this.rbNotBaned.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNotBaned.Location = new System.Drawing.Point(20, 360);
            this.rbNotBaned.Name = "rbNotBaned";
            this.rbNotBaned.Size = new System.Drawing.Size(200, 33);
            this.rbNotBaned.TabIndex = 32;
            this.rbNotBaned.TabStop = true;
            this.rbNotBaned.Text = "Renter Is Active";
            this.rbNotBaned.UseVisualStyleBackColor = true;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdateStatus.Image = global::GCMS.Properties.Resources.save_img_32;
            this.btnUpdateStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateStatus.Location = new System.Drawing.Point(629, 354);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(212, 47);
            this.btnUpdateStatus.TabIndex = 24;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.UpdateStatus_Click);
            // 
            // frmRenters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(876, 638);
            this.Controls.Add(this.TabRenters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddRenter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenters";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Renters";
            this.Load += new System.EventHandler(this.frmRenters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folvRentersList)).EndInit();
            this.TabRenters.ResumeLayout(false);
            this.RentersPage.ResumeLayout(false);
            this.RenterInfoPage.ResumeLayout(false);
            this.RenterInfoPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddRenter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button button1;
        private BrightIdeasSoftware.FastObjectListView folvRentersList;
        private System.Windows.Forms.TabControl TabRenters;
        private System.Windows.Forms.TabPage RentersPage;
        private System.Windows.Forms.TabPage RenterInfoPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRenterID;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.RadioButton rbNotBaned;
        private System.Windows.Forms.RadioButton rbBaned;
        private System.Windows.Forms.Button btnUpdateStatus;
    }
}