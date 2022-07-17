
namespace Winforms
{
    partial class Inventry
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
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SqlInvetry = new System.Windows.Forms.BindingSource(this.components);
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblTotalStockCost = new System.Windows.Forms.Label();
            this.txtTotalStockCost = new System.Windows.Forms.TextBox();
            this.lblTotalSellingCost = new System.Windows.Forms.Label();
            this.txtTotalSellingCost = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SqlInvetry)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductList
            // 
            this.dgvProductList.AllowDrop = true;
            this.dgvProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Location = new System.Drawing.Point(27, 70);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.RowTemplate.Height = 25;
            this.dgvProductList.Size = new System.Drawing.Size(506, 334);
            this.dgvProductList.TabIndex = 0;
            this.dgvProductList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProductList_CellEndEdit);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(60, 19);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(50, 15);
            this.lblBarcode.TabIndex = 1;
            this.lblBarcode.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBarcode.Location = new System.Drawing.Point(157, 18);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(238, 23);
            this.txtBarcode.TabIndex = 2;
            this.txtBarcode.Text = " ";
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Location = new System.Drawing.Point(416, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtProductName.Location = new System.Drawing.Point(157, 44);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(238, 23);
            this.txtProductName.TabIndex = 4;
            this.txtProductName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtProductName_KeyPress);
            // 
            // lblProductName
            // 
            this.lblProductName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(59, 47);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(84, 15);
            this.lblProductName.TabIndex = 5;
            this.lblProductName.Text = "Product Name";
            // 
            // lblTotalStockCost
            // 
            this.lblTotalStockCost.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalStockCost.AutoSize = true;
            this.lblTotalStockCost.Location = new System.Drawing.Point(71, 419);
            this.lblTotalStockCost.Name = "lblTotalStockCost";
            this.lblTotalStockCost.Size = new System.Drawing.Size(91, 15);
            this.lblTotalStockCost.TabIndex = 6;
            this.lblTotalStockCost.Text = "Total Stock Cost";
            // 
            // txtTotalStockCost
            // 
            this.txtTotalStockCost.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalStockCost.Location = new System.Drawing.Point(168, 416);
            this.txtTotalStockCost.Name = "txtTotalStockCost";
            this.txtTotalStockCost.Size = new System.Drawing.Size(100, 23);
            this.txtTotalStockCost.TabIndex = 7;
            // 
            // lblTotalSellingCost
            // 
            this.lblTotalSellingCost.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalSellingCost.AutoSize = true;
            this.lblTotalSellingCost.Location = new System.Drawing.Point(304, 419);
            this.lblTotalSellingCost.Name = "lblTotalSellingCost";
            this.lblTotalSellingCost.Size = new System.Drawing.Size(97, 15);
            this.lblTotalSellingCost.TabIndex = 8;
            this.lblTotalSellingCost.Text = "Total Selling Cost";
            // 
            // txtTotalSellingCost
            // 
            this.txtTotalSellingCost.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalSellingCost.Location = new System.Drawing.Point(416, 416);
            this.txtTotalSellingCost.Name = "txtTotalSellingCost";
            this.txtTotalSellingCost.Size = new System.Drawing.Size(100, 23);
            this.txtTotalSellingCost.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(416, 44);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // Inventry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 449);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtTotalSellingCost);
            this.Controls.Add(this.lblTotalSellingCost);
            this.Controls.Add(this.txtTotalStockCost);
            this.Controls.Add(this.lblTotalStockCost);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.dgvProductList);
            this.Name = "Inventry";
            this.Text = "Inventry";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Inventry_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SqlInvetry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.BindingSource SqlInvetry;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblTotalStockCost;
        private System.Windows.Forms.TextBox txtTotalStockCost;
        private System.Windows.Forms.Label lblTotalSellingCost;
        private System.Windows.Forms.TextBox txtTotalSellingCost;
        private System.Windows.Forms.Button btnAdd;
    }
}