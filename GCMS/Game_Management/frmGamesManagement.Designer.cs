namespace GCMS.Game_Manaegement
{
    partial class frmGamesManagement
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
            this.pnlDashborad = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpGames = new System.Windows.Forms.FlowLayoutPanel();
            this.gbAddNewGame = new System.Windows.Forms.GroupBox();
            this.nudGameRate = new System.Windows.Forms.NumericUpDown();
            this.btnAddNewGame = new System.Windows.Forms.Button();
            this.tbGameName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGameTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbNotActive = new System.Windows.Forms.RadioButton();
            this.pnlDashborad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbAddNewGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameRate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDashborad
            // 
            this.pnlDashborad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pnlDashborad.Controls.Add(this.label2);
            this.pnlDashborad.Controls.Add(this.pictureBox1);
            this.pnlDashborad.Controls.Add(this.button1);
            this.pnlDashborad.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDashborad.Location = new System.Drawing.Point(0, 0);
            this.pnlDashborad.Name = "pnlDashborad";
            this.pnlDashborad.Size = new System.Drawing.Size(349, 792);
            this.pnlDashborad.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(78, 763);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "© 2025 moneebcodebase.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GCMS.Properties.Resources.setting_gear_img_128;
            this.pictureBox1.Location = new System.Drawing.Point(101, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
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
            this.button1.Location = new System.Drawing.Point(-3, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(352, 77);
            this.button1.TabIndex = 13;
            this.button1.TabStop = false;
            this.button1.Text = "Games Management";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(349, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 32);
            this.panel1.TabIndex = 3;
            // 
            // flpGames
            // 
            this.flpGames.AutoScroll = true;
            this.flpGames.Location = new System.Drawing.Point(355, 209);
            this.flpGames.Name = "flpGames";
            this.flpGames.Size = new System.Drawing.Size(1101, 574);
            this.flpGames.TabIndex = 4;
            // 
            // gbAddNewGame
            // 
            this.gbAddNewGame.Controls.Add(this.rbNotActive);
            this.gbAddNewGame.Controls.Add(this.rbActive);
            this.gbAddNewGame.Controls.Add(this.cbGameTypes);
            this.gbAddNewGame.Controls.Add(this.label3);
            this.gbAddNewGame.Controls.Add(this.nudGameRate);
            this.gbAddNewGame.Controls.Add(this.btnAddNewGame);
            this.gbAddNewGame.Controls.Add(this.tbGameName);
            this.gbAddNewGame.Controls.Add(this.label5);
            this.gbAddNewGame.Controls.Add(this.label4);
            this.gbAddNewGame.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddNewGame.Location = new System.Drawing.Point(355, 38);
            this.gbAddNewGame.Name = "gbAddNewGame";
            this.gbAddNewGame.Size = new System.Drawing.Size(1101, 165);
            this.gbAddNewGame.TabIndex = 28;
            this.gbAddNewGame.TabStop = false;
            this.gbAddNewGame.Text = "Add New Game";
            // 
            // nudGameRate
            // 
            this.nudGameRate.DecimalPlaces = 2;
            this.nudGameRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGameRate.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudGameRate.Location = new System.Drawing.Point(200, 101);
            this.nudGameRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudGameRate.Name = "nudGameRate";
            this.nudGameRate.Size = new System.Drawing.Size(193, 30);
            this.nudGameRate.TabIndex = 37;
            // 
            // btnAddNewGame
            // 
            this.btnAddNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddNewGame.FlatAppearance.BorderSize = 0;
            this.btnAddNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewGame.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewGame.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNewGame.Image = global::GCMS.Properties.Resources.save_img_32;
            this.btnAddNewGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewGame.Location = new System.Drawing.Point(950, 64);
            this.btnAddNewGame.Name = "btnAddNewGame";
            this.btnAddNewGame.Size = new System.Drawing.Size(110, 51);
            this.btnAddNewGame.TabIndex = 36;
            this.btnAddNewGame.Text = "Add";
            this.btnAddNewGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNewGame.UseVisualStyleBackColor = false;
            this.btnAddNewGame.Click += new System.EventHandler(this.btnAddNewGame_Click);
            // 
            // tbGameName
            // 
            this.tbGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGameName.Location = new System.Drawing.Point(200, 51);
            this.tbGameName.Name = "tbGameName";
            this.tbGameName.Size = new System.Drawing.Size(193, 30);
            this.tbGameName.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 25);
            this.label5.TabIndex = 27;
            this.label5.Text = "Rate :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "Game Name :";
            // 
            // cbGameTypes
            // 
            this.cbGameTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGameTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGameTypes.FormattingEnabled = true;
            this.cbGameTypes.Location = new System.Drawing.Point(602, 51);
            this.cbGameTypes.Name = "cbGameTypes";
            this.cbGameTypes.Size = new System.Drawing.Size(206, 33);
            this.cbGameTypes.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 27);
            this.label3.TabIndex = 41;
            this.label3.Text = "Game Type :";
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Checked = true;
            this.rbActive.Location = new System.Drawing.Point(436, 104);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(106, 31);
            this.rbActive.TabIndex = 43;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Active";
            this.rbActive.UseVisualStyleBackColor = true;
            // 
            // rbNotActive
            // 
            this.rbNotActive.AutoSize = true;
            this.rbNotActive.Location = new System.Drawing.Point(578, 101);
            this.rbNotActive.Name = "rbNotActive";
            this.rbNotActive.Size = new System.Drawing.Size(151, 31);
            this.rbNotActive.TabIndex = 44;
            this.rbNotActive.Text = "Not Active";
            this.rbNotActive.UseVisualStyleBackColor = true;
            // 
            // frmGamesManaegement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 792);
            this.Controls.Add(this.gbAddNewGame);
            this.Controls.Add(this.flpGames);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDashborad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGamesManaegement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Store Manaegement";
            this.Load += new System.EventHandler(this.frmGamesManaegement_Load);
            this.pnlDashborad.ResumeLayout(false);
            this.pnlDashborad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbAddNewGame.ResumeLayout(false);
            this.gbAddNewGame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDashborad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpGames;
        private System.Windows.Forms.GroupBox gbAddNewGame;
        private System.Windows.Forms.NumericUpDown nudGameRate;
        private System.Windows.Forms.Button btnAddNewGame;
        private System.Windows.Forms.TextBox tbGameName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGameTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbNotActive;
        private System.Windows.Forms.RadioButton rbActive;
    }
}