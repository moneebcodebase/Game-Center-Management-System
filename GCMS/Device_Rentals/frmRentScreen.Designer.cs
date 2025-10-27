namespace GCMS.Device_Rentals
{
    partial class frmRentScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGameID = new System.Windows.Forms.Label();
            this.lblGameType = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblTotalPayment = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpStartingDate = new System.Windows.Forms.DateTimePicker();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRenterName = new System.Windows.Forms.Label();
            this.btnRent = new System.Windows.Forms.Button();
            this.btnCancelSelection = new System.Windows.Forms.Button();
            this.btnSelectRenter = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRetePerHour = new System.Windows.Forms.Label();
            this.chkMakePayment = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbVisa = new System.Windows.Forms.RadioButton();
            this.rbWallet = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 769);
            this.panel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GCMS.Properties.Resources.DeviceRental_96;
            this.pictureBox1.Location = new System.Drawing.Point(100, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 740);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "© 2025 moneebcodebase.";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(297, 77);
            this.button1.TabIndex = 15;
            this.button1.TabStop = false;
            this.button1.Text = "Device Rental";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(314, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Game ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(314, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Game Type :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(314, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Game Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(314, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Rate Per Hour :";
            // 
            // lblGameID
            // 
            this.lblGameID.AutoSize = true;
            this.lblGameID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameID.Location = new System.Drawing.Point(515, 9);
            this.lblGameID.Name = "lblGameID";
            this.lblGameID.Size = new System.Drawing.Size(46, 23);
            this.lblGameID.TabIndex = 8;
            this.lblGameID.Text = "???";
            // 
            // lblGameType
            // 
            this.lblGameType.AutoSize = true;
            this.lblGameType.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameType.Location = new System.Drawing.Point(515, 54);
            this.lblGameType.Name = "lblGameType";
            this.lblGameType.Size = new System.Drawing.Size(46, 23);
            this.lblGameType.TabIndex = 9;
            this.lblGameType.Text = "???";
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.Location = new System.Drawing.Point(515, 99);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(46, 23);
            this.lblGameName.TabIndex = 10;
            this.lblGameName.Text = "???";
            // 
            // lblTotalPayment
            // 
            this.lblTotalPayment.AutoSize = true;
            this.lblTotalPayment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPayment.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTotalPayment.Location = new System.Drawing.Point(464, 447);
            this.lblTotalPayment.Name = "lblTotalPayment";
            this.lblTotalPayment.Size = new System.Drawing.Size(43, 23);
            this.lblTotalPayment.TabIndex = 11;
            this.lblTotalPayment.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(314, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Select Renter : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(314, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "Rental Duration:";
            // 
            // dtpStartingDate
            // 
            this.dtpStartingDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartingDate.Enabled = false;
            this.dtpStartingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartingDate.Location = new System.Drawing.Point(406, 396);
            this.dtpStartingDate.Name = "dtpStartingDate";
            this.dtpStartingDate.Size = new System.Drawing.Size(132, 28);
            this.dtpStartingDate.TabIndex = 25;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(639, 397);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(132, 28);
            this.dtpReturnDate.TabIndex = 2;
            this.dtpReturnDate.ValueChanged += new System.EventHandler(this.dtpReturnDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(334, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 21);
            this.label8.TabIndex = 27;
            this.label8.Text = "From :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(579, 403);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 21);
            this.label9.TabIndex = 28;
            this.label9.Text = "To :";
            // 
            // lblRenterName
            // 
            this.lblRenterName.AutoSize = true;
            this.lblRenterName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenterName.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblRenterName.Location = new System.Drawing.Point(334, 315);
            this.lblRenterName.Name = "lblRenterName";
            this.lblRenterName.Size = new System.Drawing.Size(43, 23);
            this.lblRenterName.TabIndex = 29;
            this.lblRenterName.Text = "???";
            // 
            // btnRent
            // 
            this.btnRent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnRent.FlatAppearance.BorderSize = 0;
            this.btnRent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRent.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRent.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRent.Image = global::GCMS.Properties.Resources.rent_32;
            this.btnRent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRent.Location = new System.Drawing.Point(622, 710);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(166, 47);
            this.btnRent.TabIndex = 6;
            this.btnRent.Text = "Save Rent";
            this.btnRent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRent.UseVisualStyleBackColor = false;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // btnCancelSelection
            // 
            this.btnCancelSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelSelection.BackColor = System.Drawing.Color.White;
            this.btnCancelSelection.FlatAppearance.BorderSize = 0;
            this.btnCancelSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelSelection.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelSelection.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelSelection.Image = global::GCMS.Properties.Resources.cancel_img_32;
            this.btnCancelSelection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelSelection.Location = new System.Drawing.Point(550, 249);
            this.btnCancelSelection.Name = "btnCancelSelection";
            this.btnCancelSelection.Size = new System.Drawing.Size(238, 47);
            this.btnCancelSelection.TabIndex = 1;
            this.btnCancelSelection.Text = "Cancel Selection";
            this.btnCancelSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelSelection.UseVisualStyleBackColor = false;
            this.btnCancelSelection.Click += new System.EventHandler(this.btnCancelSelection_Click);
            // 
            // btnSelectRenter
            // 
            this.btnSelectRenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectRenter.BackColor = System.Drawing.Color.White;
            this.btnSelectRenter.FlatAppearance.BorderSize = 0;
            this.btnSelectRenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectRenter.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectRenter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelectRenter.Image = global::GCMS.Properties.Resources.select_img_32;
            this.btnSelectRenter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectRenter.Location = new System.Drawing.Point(375, 249);
            this.btnSelectRenter.Name = "btnSelectRenter";
            this.btnSelectRenter.Size = new System.Drawing.Size(132, 47);
            this.btnSelectRenter.TabIndex = 0;
            this.btnSelectRenter.Text = "Select";
            this.btnSelectRenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectRenter.UseVisualStyleBackColor = false;
            this.btnSelectRenter.Click += new System.EventHandler(this.btnSelectRenter_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(314, 447);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 23);
            this.label10.TabIndex = 31;
            this.label10.Text = "Total Cost :";
            // 
            // lblRetePerHour
            // 
            this.lblRetePerHour.AutoSize = true;
            this.lblRetePerHour.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetePerHour.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblRetePerHour.Location = new System.Drawing.Point(515, 144);
            this.lblRetePerHour.Name = "lblRetePerHour";
            this.lblRetePerHour.Size = new System.Drawing.Size(43, 23);
            this.lblRetePerHour.TabIndex = 32;
            this.lblRetePerHour.Text = "???";
            // 
            // chkMakePayment
            // 
            this.chkMakePayment.AutoSize = true;
            this.chkMakePayment.Checked = true;
            this.chkMakePayment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMakePayment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMakePayment.Location = new System.Drawing.Point(313, 600);
            this.chkMakePayment.Name = "chkMakePayment";
            this.chkMakePayment.Size = new System.Drawing.Size(180, 27);
            this.chkMakePayment.TabIndex = 4;
            this.chkMakePayment.Text = "Make Payment";
            this.chkMakePayment.UseVisualStyleBackColor = true;
            this.chkMakePayment.CheckedChanged += new System.EventHandler(this.chkMakePayment_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(314, 518);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 23);
            this.label11.TabIndex = 37;
            this.label11.Text = "Note :";
            // 
            // tbNote
            // 
            this.tbNote.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNote.Location = new System.Drawing.Point(406, 507);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(364, 55);
            this.tbNote.TabIndex = 3;
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Checked = true;
            this.rbCash.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCash.Location = new System.Drawing.Point(332, 654);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(74, 25);
            this.rbCash.TabIndex = 38;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            // 
            // rbVisa
            // 
            this.rbVisa.AutoSize = true;
            this.rbVisa.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVisa.Location = new System.Drawing.Point(446, 654);
            this.rbVisa.Name = "rbVisa";
            this.rbVisa.Size = new System.Drawing.Size(66, 25);
            this.rbVisa.TabIndex = 39;
            this.rbVisa.Text = "Visa";
            this.rbVisa.UseVisualStyleBackColor = true;
            // 
            // rbWallet
            // 
            this.rbWallet.AutoSize = true;
            this.rbWallet.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWallet.Location = new System.Drawing.Point(550, 654);
            this.rbWallet.Name = "rbWallet";
            this.rbWallet.Size = new System.Drawing.Size(84, 25);
            this.rbWallet.TabIndex = 40;
            this.rbWallet.Text = "Wallet";
            this.rbWallet.UseVisualStyleBackColor = true;
            // 
            // frmRentScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 769);
            this.Controls.Add(this.rbWallet);
            this.Controls.Add(this.rbVisa);
            this.Controls.Add(this.rbCash);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chkMakePayment);
            this.Controls.Add(this.lblRetePerHour);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.lblRenterName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpReturnDate);
            this.Controls.Add(this.dtpStartingDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelSelection);
            this.Controls.Add(this.btnSelectRenter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotalPayment);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.lblGameType);
            this.Controls.Add(this.lblGameID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRentScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rent ";
            this.Load += new System.EventHandler(this.frmRentScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGameID;
        private System.Windows.Forms.Label lblGameType;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Label lblTotalPayment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelSelection;
        private System.Windows.Forms.Button btnSelectRenter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpStartingDate;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRetePerHour;
        private System.Windows.Forms.CheckBox chkMakePayment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbVisa;
        private System.Windows.Forms.RadioButton rbWallet;
    }
}