namespace Winforms
{
    partial class ReturnForm
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
            this.lblBillNo = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.btnReturn = new System.Windows.Forms.Button();
            this.cmbPartialSearch = new System.Windows.Forms.ComboBox();
            this.bsBillingListReturn = new System.Windows.Forms.BindingSource(this.components);
            this.txtNoOfProducts = new System.Windows.Forms.TextBox();
            this.lblNoOfProducts = new System.Windows.Forms.Label();
            this.txtSavings = new System.Windows.Forms.TextBox();
            this.lblSavings = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmout = new System.Windows.Forms.Label();
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.lblBillAmount = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBillingListReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBillNo
            // 
            this.lblBillNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Location = new System.Drawing.Point(451, 17);
            this.lblBillNo.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(42, 15);
            this.lblBillNo.TabIndex = 0;
            this.lblBillNo.Text = "Bill No";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBillNo.Location = new System.Drawing.Point(314, 14);
            this.txtBillNo.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(202, 23);
            this.txtBillNo.TabIndex = 1;
            // 
            // dgvProductList
            // 
            this.dgvProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Location = new System.Drawing.Point(42, 80);
            this.dgvProductList.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.RowHeadersWidth = 123;
            this.dgvProductList.RowTemplate.Height = 57;
            this.dgvProductList.Size = new System.Drawing.Size(962, 475);
            this.dgvProductList.TabIndex = 2;
            this.dgvProductList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductList_CellEndEdit);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Location = new System.Drawing.Point(909, 564);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(79, 23);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // cmbPartialSearch
            // 
            this.cmbPartialSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbPartialSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPartialSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPartialSearch.FormattingEnabled = true;
            this.cmbPartialSearch.Location = new System.Drawing.Point(126, 41);
            this.cmbPartialSearch.Name = "cmbPartialSearch";
            this.cmbPartialSearch.Size = new System.Drawing.Size(715, 23);
            this.cmbPartialSearch.TabIndex = 31;
            this.cmbPartialSearch.SelectedIndexChanged += new System.EventHandler(this.cmbPartialSearch_SelectedIndexChanged);
            // 
            // txtNoOfProducts
            // 
            this.txtNoOfProducts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtNoOfProducts.Location = new System.Drawing.Point(155, 559);
            this.txtNoOfProducts.Name = "txtNoOfProducts";
            this.txtNoOfProducts.Size = new System.Drawing.Size(100, 23);
            this.txtNoOfProducts.TabIndex = 44;
            // 
            // lblNoOfProducts
            // 
            this.lblNoOfProducts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblNoOfProducts.AutoSize = true;
            this.lblNoOfProducts.Location = new System.Drawing.Point(56, 563);
            this.lblNoOfProducts.Name = "lblNoOfProducts";
            this.lblNoOfProducts.Size = new System.Drawing.Size(89, 15);
            this.lblNoOfProducts.TabIndex = 43;
            this.lblNoOfProducts.Text = "No Of Products";
            // 
            // txtSavings
            // 
            this.txtSavings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSavings.Location = new System.Drawing.Point(561, 562);
            this.txtSavings.Name = "txtSavings";
            this.txtSavings.Size = new System.Drawing.Size(100, 23);
            this.txtSavings.TabIndex = 42;
            // 
            // lblSavings
            // 
            this.lblSavings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSavings.AutoSize = true;
            this.lblSavings.Location = new System.Drawing.Point(491, 564);
            this.lblSavings.Name = "lblSavings";
            this.lblSavings.Size = new System.Drawing.Size(47, 15);
            this.lblSavings.TabIndex = 41;
            this.lblSavings.Text = "Savings";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalAmount.Location = new System.Drawing.Point(383, 563);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 23);
            this.txtTotalAmount.TabIndex = 40;
            // 
            // lblTotalAmout
            // 
            this.lblTotalAmout.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalAmout.AutoSize = true;
            this.lblTotalAmout.Location = new System.Drawing.Point(282, 563);
            this.lblTotalAmout.Name = "lblTotalAmout";
            this.lblTotalAmout.Size = new System.Drawing.Size(72, 15);
            this.lblTotalAmout.TabIndex = 39;
            this.lblTotalAmout.Text = "Total Amout";
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtBillAmount.Location = new System.Drawing.Point(772, 563);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.Size = new System.Drawing.Size(100, 23);
            this.txtBillAmount.TabIndex = 38;
            // 
            // lblBillAmount
            // 
            this.lblBillAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblBillAmount.AutoSize = true;
            this.lblBillAmount.Location = new System.Drawing.Point(675, 566);
            this.lblBillAmount.Name = "lblBillAmount";
            this.lblBillAmount.Size = new System.Drawing.Size(70, 15);
            this.lblBillAmount.TabIndex = 37;
            this.lblBillAmount.Text = "Bill Amount";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoad.Location = new System.Drawing.Point(541, 14);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(79, 24);
            this.btnLoad.TabIndex = 45;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 597);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtNoOfProducts);
            this.Controls.Add(this.lblNoOfProducts);
            this.Controls.Add(this.txtSavings);
            this.Controls.Add(this.lblSavings);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmout);
            this.Controls.Add(this.txtBillAmount);
            this.Controls.Add(this.lblBillAmount);
            this.Controls.Add(this.cmbPartialSearch);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.dgvProductList);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.lblBillNo);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "ReturnForm";
            this.Text = "ReturnForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBillingListReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.ComboBox cmbPartialSearch;
        public System.Windows.Forms.BindingSource bsBillingListReturn;
        private System.Windows.Forms.TextBox txtNoOfProducts;
        private System.Windows.Forms.Label lblNoOfProducts;
        private System.Windows.Forms.TextBox txtSavings;
        private System.Windows.Forms.Label lblSavings;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTotalAmout;
        private System.Windows.Forms.TextBox txtBillAmount;
        private System.Windows.Forms.Label lblBillAmount;
        public System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnLoad;
    }
}