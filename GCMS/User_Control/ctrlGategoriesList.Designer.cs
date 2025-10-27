namespace GCMS.User_Control
{
    partial class ctrlGategoriesList
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
            this.flpCategoriesList = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNoCategories = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flpCategoriesList
            // 
            this.flpCategoriesList.AutoScroll = true;
            this.flpCategoriesList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpCategoriesList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpCategoriesList.Location = new System.Drawing.Point(0, 125);
            this.flpCategoriesList.Name = "flpCategoriesList";
            this.flpCategoriesList.Size = new System.Drawing.Size(277, 665);
            this.flpCategoriesList.TabIndex = 0;
            this.flpCategoriesList.WrapContents = false;
            // 
            // btnNoCategories
            // 
            this.btnNoCategories.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNoCategories.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnNoCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoCategories.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoCategories.Location = new System.Drawing.Point(29, 274);
            this.btnNoCategories.Name = "btnNoCategories";
            this.btnNoCategories.Size = new System.Drawing.Size(221, 90);
            this.btnNoCategories.TabIndex = 1;
            this.btnNoCategories.Text = "No Categories, please add new categories";
            this.btnNoCategories.UseVisualStyleBackColor = false;
            this.btnNoCategories.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Categories";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GCMS.Properties.Resources.store_img_48;
            this.pictureBox1.Location = new System.Drawing.Point(88, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlGategoriesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNoCategories);
            this.Controls.Add(this.flpCategoriesList);
            this.Name = "ctrlGategoriesList";
            this.Size = new System.Drawing.Size(277, 790);
            this.Load += new System.EventHandler(this.ctrlGategoriesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCategoriesList;
        private System.Windows.Forms.Button btnNoCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
