﻿namespace GCMS.Debts
{
    partial class frmPayDebt
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
            this.btnPayDebt = new System.Windows.Forms.Button();
            this.lblDebtID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalDebt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRenterName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbVisa = new System.Windows.Forms.RadioButton();
            this.rbWallet = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPayDebt
            // 
            this.btnPayDebt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayDebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnPayDebt.FlatAppearance.BorderSize = 0;
            this.btnPayDebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayDebt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayDebt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPayDebt.Image = global::GCMS.Properties.Resources.cash_img_32;
            this.btnPayDebt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayDebt.Location = new System.Drawing.Point(143, 441);
            this.btnPayDebt.Name = "btnPayDebt";
            this.btnPayDebt.Size = new System.Drawing.Size(155, 47);
            this.btnPayDebt.TabIndex = 5;
            this.btnPayDebt.Text = "Pay Debt";
            this.btnPayDebt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayDebt.UseVisualStyleBackColor = false;
            this.btnPayDebt.Click += new System.EventHandler(this.btnPayDebt_Click);
            // 
            // lblDebtID
            // 
            this.lblDebtID.AutoSize = true;
            this.lblDebtID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebtID.ForeColor = System.Drawing.Color.Black;
            this.lblDebtID.Location = new System.Drawing.Point(127, 125);
            this.lblDebtID.Name = "lblDebtID";
            this.lblDebtID.Size = new System.Drawing.Size(43, 23);
            this.lblDebtID.TabIndex = 29;
            this.lblDebtID.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 23);
            this.label5.TabIndex = 28;
            this.label5.Text = "Debt ID:";
            // 
            // lblTotalDebt
            // 
            this.lblTotalDebt.AutoSize = true;
            this.lblTotalDebt.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDebt.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblTotalDebt.Location = new System.Drawing.Point(162, 366);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(63, 34);
            this.lblTotalDebt.TabIndex = 27;
            this.lblTotalDebt.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 23);
            this.label4.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(101, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 34);
            this.label1.TabIndex = 25;
            this.label1.Text = "Debt Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "Renter :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 23);
            this.label2.TabIndex = 30;
            this.label2.Text = "Total Debt :";
            // 
            // lblRenterName
            // 
            this.lblRenterName.AutoSize = true;
            this.lblRenterName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenterName.ForeColor = System.Drawing.Color.Black;
            this.lblRenterName.Location = new System.Drawing.Point(26, 228);
            this.lblRenterName.Name = "lblRenterName";
            this.lblRenterName.Size = new System.Drawing.Size(43, 23);
            this.lblRenterName.TabIndex = 31;
            this.lblRenterName.Text = "???";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 94);
            this.panel1.TabIndex = 32;
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Checked = true;
            this.rbCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCash.Location = new System.Drawing.Point(30, 324);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(69, 24);
            this.rbCash.TabIndex = 33;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            // 
            // rbVisa
            // 
            this.rbVisa.AutoSize = true;
            this.rbVisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVisa.Location = new System.Drawing.Point(162, 324);
            this.rbVisa.Name = "rbVisa";
            this.rbVisa.Size = new System.Drawing.Size(63, 24);
            this.rbVisa.TabIndex = 34;
            this.rbVisa.Text = "Visa";
            this.rbVisa.UseVisualStyleBackColor = true;
            // 
            // rbWallet
            // 
            this.rbWallet.AutoSize = true;
            this.rbWallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbWallet.Location = new System.Drawing.Point(290, 324);
            this.rbWallet.Name = "rbWallet";
            this.rbWallet.Size = new System.Drawing.Size(77, 24);
            this.rbWallet.TabIndex = 35;
            this.rbWallet.Text = "Wallet";
            this.rbWallet.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 23);
            this.label6.TabIndex = 36;
            this.label6.Text = "Payment method:";
            // 
            // frmPayDebt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 500);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rbWallet);
            this.Controls.Add(this.rbVisa);
            this.Controls.Add(this.rbCash);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblRenterName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDebtID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotalDebt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPayDebt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayDebt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay Debt";
            this.Load += new System.EventHandler(this.frmPayDebt_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPayDebt;
        private System.Windows.Forms.Label lblDebtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalDebt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRenterName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbVisa;
        private System.Windows.Forms.RadioButton rbWallet;
        private System.Windows.Forms.Label label6;
    }
}