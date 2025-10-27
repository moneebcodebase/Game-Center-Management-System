namespace GCMS.Debts
{
    partial class frmDebts
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.folvUnpaidDebtsList = new BrightIdeasSoftware.FastObjectListView();
            this.tapDebts = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.folvPaidDebtsList = new BrightIdeasSoftware.FastObjectListView();
            this.cmsUnPaidListOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.makePaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folvUnpaidDebtsList)).BeginInit();
            this.tapDebts.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folvPaidDebtsList)).BeginInit();
            this.cmsUnPaidListOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GCMS.Properties.Resources.search_img_32;
            this.pictureBox1.Location = new System.Drawing.Point(16, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 27);
            this.label1.TabIndex = 25;
            this.label1.Text = "Search :";
            // 
            // tbSearch
            // 
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(185, 119);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(245, 30);
            this.tbSearch.TabIndex = 24;
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
            this.button1.Location = new System.Drawing.Point(218, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(442, 95);
            this.button1.TabIndex = 23;
            this.button1.Text = "Debts";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // folvUnpaidDebtsList
            // 
            this.folvUnpaidDebtsList.BackColor = System.Drawing.Color.White;
            this.folvUnpaidDebtsList.CellEditUseWholeCell = false;
            this.folvUnpaidDebtsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folvUnpaidDebtsList.EmptyListMsg = "Did not find any debts !!";
            this.folvUnpaidDebtsList.EmptyListMsgFont = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folvUnpaidDebtsList.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folvUnpaidDebtsList.HideSelection = false;
            this.folvUnpaidDebtsList.Location = new System.Drawing.Point(3, 3);
            this.folvUnpaidDebtsList.MultiSelect = false;
            this.folvUnpaidDebtsList.Name = "folvUnpaidDebtsList";
            this.folvUnpaidDebtsList.ShowGroups = false;
            this.folvUnpaidDebtsList.Size = new System.Drawing.Size(815, 414);
            this.folvUnpaidDebtsList.TabIndex = 22;
            this.folvUnpaidDebtsList.UseCompatibleStateImageBehavior = false;
            this.folvUnpaidDebtsList.UseFiltering = true;
            this.folvUnpaidDebtsList.View = System.Windows.Forms.View.Details;
            this.folvUnpaidDebtsList.VirtualMode = true;
            this.folvUnpaidDebtsList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.folvUnpaidDebtsList_MouseDown);
            // 
            // tapDebts
            // 
            this.tapDebts.Controls.Add(this.tabPage1);
            this.tapDebts.Controls.Add(this.tabPage2);
            this.tapDebts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tapDebts.Location = new System.Drawing.Point(12, 160);
            this.tapDebts.Name = "tapDebts";
            this.tapDebts.SelectedIndex = 0;
            this.tapDebts.Size = new System.Drawing.Size(829, 453);
            this.tapDebts.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.folvUnpaidDebtsList);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(821, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Unpaid";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.folvPaidDebtsList);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(821, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Paid";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // folvPaidDebtsList
            // 
            this.folvPaidDebtsList.BackColor = System.Drawing.Color.White;
            this.folvPaidDebtsList.CellEditUseWholeCell = false;
            this.folvPaidDebtsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folvPaidDebtsList.EmptyListMsg = "Did not find any debts !!";
            this.folvPaidDebtsList.EmptyListMsgFont = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folvPaidDebtsList.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folvPaidDebtsList.HideSelection = false;
            this.folvPaidDebtsList.Location = new System.Drawing.Point(3, 3);
            this.folvPaidDebtsList.MultiSelect = false;
            this.folvPaidDebtsList.Name = "folvPaidDebtsList";
            this.folvPaidDebtsList.ShowGroups = false;
            this.folvPaidDebtsList.Size = new System.Drawing.Size(815, 414);
            this.folvPaidDebtsList.TabIndex = 23;
            this.folvPaidDebtsList.UseCompatibleStateImageBehavior = false;
            this.folvPaidDebtsList.UseFiltering = true;
            this.folvPaidDebtsList.View = System.Windows.Forms.View.Details;
            this.folvPaidDebtsList.VirtualMode = true;
            // 
            // cmsUnPaidListOptions
            // 
            this.cmsUnPaidListOptions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsUnPaidListOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makePaymentToolStripMenuItem,
            this.toolStripMenuItem1});
            this.cmsUnPaidListOptions.Name = "cmsUnPaidListOptions";
            this.cmsUnPaidListOptions.Size = new System.Drawing.Size(211, 62);
            // 
            // makePaymentToolStripMenuItem
            // 
            this.makePaymentToolStripMenuItem.Name = "makePaymentToolStripMenuItem";
            this.makePaymentToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.makePaymentToolStripMenuItem.Text = "Make Payment";
            this.makePaymentToolStripMenuItem.Click += new System.EventHandler(this.makePaymentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(207, 6);
            // 
            // frmDebts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(853, 654);
            this.Controls.Add(this.tapDebts);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDebts";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Debts";
            this.Load += new System.EventHandler(this.Debts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folvUnpaidDebtsList)).EndInit();
            this.tapDebts.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.folvPaidDebtsList)).EndInit();
            this.cmsUnPaidListOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button button1;
        private BrightIdeasSoftware.FastObjectListView folvUnpaidDebtsList;
        private System.Windows.Forms.TabControl tapDebts;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private BrightIdeasSoftware.FastObjectListView folvPaidDebtsList;
        private System.Windows.Forms.ContextMenuStrip cmsUnPaidListOptions;
        private System.Windows.Forms.ToolStripMenuItem makePaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}