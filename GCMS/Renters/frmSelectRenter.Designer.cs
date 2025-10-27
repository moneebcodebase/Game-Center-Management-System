namespace GCMS.Renters
{
    partial class frmSelectRenter
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
            this.btnClose = new System.Windows.Forms.Button();
            this.folvRentersList = new BrightIdeasSoftware.FastObjectListView();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectRenter = new System.Windows.Forms.Button();
            this.btnAddRenter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.folvRentersList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(791, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // folvRentersList
            // 
            this.folvRentersList.BackColor = System.Drawing.Color.White;
            this.folvRentersList.CellEditUseWholeCell = false;
            this.folvRentersList.EmptyListMsg = "Did not find any renters, click the add renter button to add new renter";
            this.folvRentersList.EmptyListMsgFont = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folvRentersList.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folvRentersList.HideSelection = false;
            this.folvRentersList.Location = new System.Drawing.Point(32, 172);
            this.folvRentersList.MultiSelect = false;
            this.folvRentersList.Name = "folvRentersList";
            this.folvRentersList.ShowGroups = false;
            this.folvRentersList.Size = new System.Drawing.Size(799, 352);
            this.folvRentersList.TabIndex = 6;
            this.folvRentersList.UseCompatibleStateImageBehavior = false;
            this.folvRentersList.UseFiltering = true;
            this.folvRentersList.View = System.Windows.Forms.View.Details;
            this.folvRentersList.VirtualMode = true;
            this.folvRentersList.DoubleClick += new System.EventHandler(this.folvRentersList_DoubleClick);
            // 
            // tbSearch
            // 
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(213, 130);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(245, 30);
            this.tbSearch.TabIndex = 8;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(95, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search :";
            // 
            // btnSelectRenter
            // 
            this.btnSelectRenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectRenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSelectRenter.FlatAppearance.BorderSize = 0;
            this.btnSelectRenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectRenter.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectRenter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelectRenter.Location = new System.Drawing.Point(308, 548);
            this.btnSelectRenter.Name = "btnSelectRenter";
            this.btnSelectRenter.Size = new System.Drawing.Size(234, 32);
            this.btnSelectRenter.TabIndex = 11;
            this.btnSelectRenter.Text = "Select";
            this.btnSelectRenter.UseVisualStyleBackColor = false;
            this.btnSelectRenter.Click += new System.EventHandler(this.btnSelectRenter_Click);
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
            this.btnAddRenter.Location = new System.Drawing.Point(648, 113);
            this.btnAddRenter.Name = "btnAddRenter";
            this.btnAddRenter.Size = new System.Drawing.Size(183, 47);
            this.btnAddRenter.TabIndex = 12;
            this.btnAddRenter.Text = "Add Renter";
            this.btnAddRenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRenter.UseVisualStyleBackColor = false;
            this.btnAddRenter.Click += new System.EventHandler(this.btnAddRenter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GCMS.Properties.Resources.search_img_32;
            this.pictureBox1.Location = new System.Drawing.Point(44, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
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
            this.button1.Location = new System.Drawing.Point(239, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(442, 95);
            this.button1.TabIndex = 7;
            this.button1.Text = "Renters List";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 574);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "© 2025 moneebcodebase.";
            // 
            // frmSelectRenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(859, 603);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddRenter);
            this.Controls.Add(this.btnSelectRenter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.folvRentersList);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectRenter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Renters";
            this.Load += new System.EventHandler(this.frmSelectRenter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.folvRentersList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private BrightIdeasSoftware.FastObjectListView folvRentersList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSelectRenter;
        private System.Windows.Forms.Button btnAddRenter;
        private System.Windows.Forms.Label label2;
    }
}