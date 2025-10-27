namespace GCMS.User_Control
{
    partial class ctrlStoreItem
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
            this.gbItemName = new System.Windows.Forms.GroupBox();
            this.lblNoItemsLeft = new System.Windows.Forms.Label();
            this.pbItemImage = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.lblItemQuantity = new System.Windows.Forms.Label();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.nudSelectedAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbItemName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectedAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // gbItemName
            // 
            this.gbItemName.Controls.Add(this.lblNoItemsLeft);
            this.gbItemName.Controls.Add(this.pbItemImage);
            this.gbItemName.Controls.Add(this.label5);
            this.gbItemName.Controls.Add(this.lblItemPrice);
            this.gbItemName.Controls.Add(this.lblItemQuantity);
            this.gbItemName.Controls.Add(this.btnAddToCart);
            this.gbItemName.Controls.Add(this.nudSelectedAmount);
            this.gbItemName.Controls.Add(this.label2);
            this.gbItemName.Controls.Add(this.label1);
            this.gbItemName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbItemName.ForeColor = System.Drawing.Color.White;
            this.gbItemName.Location = new System.Drawing.Point(18, 3);
            this.gbItemName.Name = "gbItemName";
            this.gbItemName.Size = new System.Drawing.Size(452, 223);
            this.gbItemName.TabIndex = 0;
            this.gbItemName.TabStop = false;
            this.gbItemName.Text = "Item Name";
            // 
            // lblNoItemsLeft
            // 
            this.lblNoItemsLeft.AutoSize = true;
            this.lblNoItemsLeft.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoItemsLeft.ForeColor = System.Drawing.Color.Red;
            this.lblNoItemsLeft.Location = new System.Drawing.Point(217, 152);
            this.lblNoItemsLeft.Name = "lblNoItemsLeft";
            this.lblNoItemsLeft.Size = new System.Drawing.Size(213, 19);
            this.lblNoItemsLeft.TabIndex = 8;
            this.lblNoItemsLeft.Text = "no more items available!";
            this.lblNoItemsLeft.Visible = false;
            // 
            // pbItemImage
            // 
            this.pbItemImage.Image = global::GCMS.Properties.Resources.StoreItme_256;
            this.pbItemImage.Location = new System.Drawing.Point(17, 27);
            this.pbItemImage.Name = "pbItemImage";
            this.pbItemImage.Size = new System.Drawing.Size(194, 179);
            this.pbItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbItemImage.TabIndex = 7;
            this.pbItemImage.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(227, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Amount :";
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemPrice.ForeColor = System.Drawing.Color.LawnGreen;
            this.lblItemPrice.Location = new System.Drawing.Point(368, 24);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(59, 19);
            this.lblItemPrice.TabIndex = 5;
            this.lblItemPrice.Text = "10000";
            // 
            // lblItemQuantity
            // 
            this.lblItemQuantity.AutoSize = true;
            this.lblItemQuantity.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemQuantity.Location = new System.Drawing.Point(341, 70);
            this.lblItemQuantity.Name = "lblItemQuantity";
            this.lblItemQuantity.Size = new System.Drawing.Size(40, 21);
            this.lblItemQuantity.TabIndex = 4;
            this.lblItemQuantity.Text = "???";
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddToCart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToCart.ForeColor = System.Drawing.Color.Black;
            this.btnAddToCart.Location = new System.Drawing.Point(306, 183);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(140, 34);
            this.btnAddToCart.TabIndex = 3;
            this.btnAddToCart.Text = "Add to cart";
            this.btnAddToCart.UseVisualStyleBackColor = false;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // nudSelectedAmount
            // 
            this.nudSelectedAmount.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSelectedAmount.Location = new System.Drawing.Point(345, 113);
            this.nudSelectedAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSelectedAmount.Name = "nudSelectedAmount";
            this.nudSelectedAmount.Size = new System.Drawing.Size(82, 26);
            this.nudSelectedAmount.TabIndex = 2;
            this.nudSelectedAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "In Stock :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Price Per Unit :";
            // 
            // ctrlStoreItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.gbItemName);
            this.Name = "ctrlStoreItem";
            this.Size = new System.Drawing.Size(485, 238);
            this.Load += new System.EventHandler(this.ctrlStoreItem_Load);
            this.gbItemName.ResumeLayout(false);
            this.gbItemName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSelectedAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.NumericUpDown nudSelectedAmount;
        private System.Windows.Forms.Label lblItemQuantity;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbItemImage;
        private System.Windows.Forms.Label lblNoItemsLeft;
    }
}
