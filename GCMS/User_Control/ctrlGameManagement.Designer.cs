namespace GCMS.User_Control
{
    partial class ctrlGameManagement
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbGameType = new System.Windows.Forms.GroupBox();
            this.tbGameName = new System.Windows.Forms.TextBox();
            this.rbDeactivate = new System.Windows.Forms.RadioButton();
            this.rbActivate = new System.Windows.Forms.RadioButton();
            this.nudGameRate = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbGameType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbGameType
            // 
            this.gbGameType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbGameType.Controls.Add(this.tbGameName);
            this.gbGameType.Controls.Add(this.rbDeactivate);
            this.gbGameType.Controls.Add(this.rbActivate);
            this.gbGameType.Controls.Add(this.nudGameRate);
            this.gbGameType.Controls.Add(this.label2);
            this.gbGameType.Controls.Add(this.lblGameName);
            this.gbGameType.Controls.Add(this.btnSave);
            this.gbGameType.Controls.Add(this.pictureBox1);
            this.gbGameType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbGameType.ForeColor = System.Drawing.Color.White;
            this.gbGameType.Location = new System.Drawing.Point(19, 15);
            this.gbGameType.Name = "gbGameType";
            this.gbGameType.Size = new System.Drawing.Size(470, 271);
            this.gbGameType.TabIndex = 1;
            this.gbGameType.TabStop = false;
            this.gbGameType.Text = "Type";
            // 
            // tbGameName
            // 
            this.tbGameName.Location = new System.Drawing.Point(180, 75);
            this.tbGameName.Name = "tbGameName";
            this.tbGameName.Size = new System.Drawing.Size(272, 27);
            this.tbGameName.TabIndex = 9;
            // 
            // rbDeactivate
            // 
            this.rbDeactivate.AutoSize = true;
            this.rbDeactivate.Location = new System.Drawing.Point(312, 166);
            this.rbDeactivate.Name = "rbDeactivate";
            this.rbDeactivate.Size = new System.Drawing.Size(120, 24);
            this.rbDeactivate.TabIndex = 8;
            this.rbDeactivate.TabStop = true;
            this.rbDeactivate.Text = "Deactivate";
            this.rbDeactivate.UseVisualStyleBackColor = true;
            // 
            // rbActivate
            // 
            this.rbActivate.AutoSize = true;
            this.rbActivate.Location = new System.Drawing.Point(180, 166);
            this.rbActivate.Name = "rbActivate";
            this.rbActivate.Size = new System.Drawing.Size(98, 24);
            this.rbActivate.TabIndex = 7;
            this.rbActivate.TabStop = true;
            this.rbActivate.Text = "Activate";
            this.rbActivate.UseVisualStyleBackColor = true;
            // 
            // nudGameRate
            // 
            this.nudGameRate.DecimalPlaces = 2;
            this.nudGameRate.Location = new System.Drawing.Point(236, 124);
            this.nudGameRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudGameRate.Name = "nudGameRate";
            this.nudGameRate.Size = new System.Drawing.Size(100, 27);
            this.nudGameRate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rate";
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblGameName.Location = new System.Drawing.Point(176, 37);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(150, 23);
            this.lblGameName.TabIndex = 3;
            this.lblGameName.Text = "Game Name :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(205, 217);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GCMS.Properties.Resources.setting_gear_img_128;
            this.pictureBox1.Location = new System.Drawing.Point(16, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlGameManaegement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.gbGameType);
            this.Name = "ctrlGameManaegement";
            this.Size = new System.Drawing.Size(509, 302);
            this.Load += new System.EventHandler(this.ctrlGameManaegement_Load);
            this.gbGameType.ResumeLayout(false);
            this.gbGameType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGameRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGameType;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudGameRate;
        private System.Windows.Forms.RadioButton rbDeactivate;
        private System.Windows.Forms.RadioButton rbActivate;
        private System.Windows.Forms.TextBox tbGameName;
    }
}
