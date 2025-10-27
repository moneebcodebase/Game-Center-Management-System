namespace GCMS.Store
{
    partial class frmStore
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
            this.SST = new System.Windows.Forms.StatusStrip();
            this.SSTLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.btnStoreManagement = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCart = new System.Windows.Forms.Button();
            this.flpItems = new System.Windows.Forms.FlowLayoutPanel();
            this.pbStoreImage = new System.Windows.Forms.PictureBox();
            this.ctrlGategoriesList1 = new GCMS.User_Control.ctrlGategoriesList();
            this.SST.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.flpItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStoreImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(279, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1645, 32);
            this.panel1.TabIndex = 1;
            this.panel1.MouseHover += new System.EventHandler(this.panel1_MouseHover);
            // 
            // SST
            // 
            this.SST.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.SST.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SSTLabel});
            this.SST.Location = new System.Drawing.Point(279, 1029);
            this.SST.Name = "SST";
            this.SST.Size = new System.Drawing.Size(1645, 26);
            this.SST.TabIndex = 2;
            // 
            // SSTLabel
            // 
            this.SSTLabel.ForeColor = System.Drawing.Color.White;
            this.SSTLabel.Name = "SSTLabel";
            this.SSTLabel.Size = new System.Drawing.Size(184, 20);
            this.SSTLabel.Text = "© 2025 moneebcodebase.";
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pnlOptions.Controls.Add(this.btnStoreManagement);
            this.pnlOptions.Controls.Add(this.label1);
            this.pnlOptions.Controls.Add(this.btnCart);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlOptions.Location = new System.Drawing.Point(1692, 32);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(232, 997);
            this.pnlOptions.TabIndex = 3;
            this.pnlOptions.MouseHover += new System.EventHandler(this.pnlOptions_MouseHover);
            // 
            // btnStoreManagement
            // 
            this.btnStoreManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnStoreManagement.FlatAppearance.BorderSize = 0;
            this.btnStoreManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnStoreManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoreManagement.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoreManagement.ForeColor = System.Drawing.Color.White;
            this.btnStoreManagement.Image = global::GCMS.Properties.Resources.setting_Gear_img_32;
            this.btnStoreManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStoreManagement.Location = new System.Drawing.Point(18, 227);
            this.btnStoreManagement.Name = "btnStoreManagement";
            this.btnStoreManagement.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStoreManagement.Size = new System.Drawing.Size(202, 66);
            this.btnStoreManagement.TabIndex = 4;
            this.btnStoreManagement.Text = "     Manage Store";
            this.btnStoreManagement.UseVisualStyleBackColor = false;
            this.btnStoreManagement.Click += new System.EventHandler(this.btnStoreManagement_Click);
            this.btnStoreManagement.MouseHover += new System.EventHandler(this.btnCategoriesManagement_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(70, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Options";
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Image = global::GCMS.Properties.Resources.cart_img_32;
            this.btnCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCart.Location = new System.Drawing.Point(18, 120);
            this.btnCart.Name = "btnCart";
            this.btnCart.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCart.Size = new System.Drawing.Size(202, 66);
            this.btnCart.TabIndex = 2;
            this.btnCart.Text = "Cart";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            this.btnCart.MouseHover += new System.EventHandler(this.btnCart_MouseHover);
            // 
            // flpItems
            // 
            this.flpItems.AutoScroll = true;
            this.flpItems.Controls.Add(this.pbStoreImage);
            this.flpItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpItems.Location = new System.Drawing.Point(279, 32);
            this.flpItems.Name = "flpItems";
            this.flpItems.Size = new System.Drawing.Size(1413, 997);
            this.flpItems.TabIndex = 4;
            // 
            // pbStoreImage
            // 
            this.pbStoreImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pbStoreImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStoreImage.Image = global::GCMS.Properties.Resources.Store_img_680;
            this.pbStoreImage.Location = new System.Drawing.Point(3, 3);
            this.pbStoreImage.Name = "pbStoreImage";
            this.pbStoreImage.Size = new System.Drawing.Size(1020, 780);
            this.pbStoreImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStoreImage.TabIndex = 0;
            this.pbStoreImage.TabStop = false;
            this.pbStoreImage.MouseHover += new System.EventHandler(this.pbStoreImage_MouseHover);
            // 
            // ctrlGategoriesList1
            // 
            this.ctrlGategoriesList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ctrlGategoriesList1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlGategoriesList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrlGategoriesList1.Location = new System.Drawing.Point(0, 0);
            this.ctrlGategoriesList1.Name = "ctrlGategoriesList1";
            this.ctrlGategoriesList1.Size = new System.Drawing.Size(279, 1055);
            this.ctrlGategoriesList1.TabIndex = 0;
            this.ctrlGategoriesList1.OnCategoryClickFromTheList += new System.EventHandler<GCMS_Infrastructure.clsStoreCategoryEventArgs>(this.ctrlGategoriesList1_OnCategoryClickFromTheList);
            this.ctrlGategoriesList1.MouseHover += new System.EventHandler(this.ctrlGategoriesList1_MouseHover);
            // 
            // frmStore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.flpItems);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.SST);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctrlGategoriesList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStore";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Store";
            this.Load += new System.EventHandler(this.frmStore_Load);
            this.MouseHover += new System.EventHandler(this.frmStore_MouseHover);
            this.SST.ResumeLayout(false);
            this.SST.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.flpItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStoreImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private User_Control.ctrlGategoriesList ctrlGategoriesList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip SST;
        private System.Windows.Forms.ToolStripStatusLabel SSTLabel;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStoreManagement;
        private System.Windows.Forms.FlowLayoutPanel flpItems;
        private System.Windows.Forms.PictureBox pbStoreImage;
    }
}