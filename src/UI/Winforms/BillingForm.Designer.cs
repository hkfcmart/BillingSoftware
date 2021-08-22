
namespace Winforms
{
    partial class BillingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillingForm));
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblOfferAmount = new System.Windows.Forms.Label();
            this.txtOfferAmount = new System.Windows.Forms.TextBox();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.lblPlace = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.bsBillingList = new System.Windows.Forms.BindingSource(this.components);
            this.cbxconflictItem = new System.Windows.Forms.ComboBox();
            this.PBHeader = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.lblBillAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmout = new System.Windows.Forms.Label();
            this.txtSavings = new System.Windows.Forms.TextBox();
            this.lblSavings = new System.Windows.Forms.Label();
            this.btnPrintReciept = new System.Windows.Forms.Button();
            this.dgvProductList = new System.Windows.Forms.DataGridView();
            this.lblNoOfProducts = new System.Windows.Forms.Label();
            this.txtNoOfProducts = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bsBillingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(97, 94);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(94, 15);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(500, 96);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(88, 15);
            this.lblPhoneNumber.TabIndex = 1;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCustomerName.Location = new System.Drawing.Point(213, 91);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(248, 23);
            this.txtCustomerName.TabIndex = 2;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPhoneNumber.Location = new System.Drawing.Point(607, 91);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(166, 23);
            this.txtPhoneNumber.TabIndex = 3;
            // 
            // lblOfferAmount
            // 
            this.lblOfferAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblOfferAmount.AutoSize = true;
            this.lblOfferAmount.Location = new System.Drawing.Point(99, 147);
            this.lblOfferAmount.Name = "lblOfferAmount";
            this.lblOfferAmount.Size = new System.Drawing.Size(81, 15);
            this.lblOfferAmount.TabIndex = 4;
            this.lblOfferAmount.Text = "Offer Amount";
            // 
            // txtOfferAmount
            // 
            this.txtOfferAmount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtOfferAmount.Location = new System.Drawing.Point(213, 144);
            this.txtOfferAmount.Name = "txtOfferAmount";
            this.txtOfferAmount.Size = new System.Drawing.Size(248, 23);
            this.txtOfferAmount.TabIndex = 5;
            // 
            // txtPlace
            // 
            this.txtPlace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPlace.Location = new System.Drawing.Point(607, 139);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(166, 23);
            this.txtPlace.TabIndex = 7;
            // 
            // lblPlace
            // 
            this.lblPlace.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPlace.AutoSize = true;
            this.lblPlace.Location = new System.Drawing.Point(500, 144);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(35, 15);
            this.lblPlace.TabIndex = 6;
            this.lblPlace.Text = "Place";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.Location = new System.Drawing.Point(528, 186);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBarcode.Location = new System.Drawing.Point(213, 186);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(279, 23);
            this.txtBarcode.TabIndex = 10;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBarcode_KeyDown);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(99, 189);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(50, 15);
            this.lblBarcode.TabIndex = 9;
            this.lblBarcode.Text = "Barcode";
            // 
            // cbxconflictItem
            // 
            this.cbxconflictItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxconflictItem.FormattingEnabled = true;
            this.cbxconflictItem.Location = new System.Drawing.Point(99, 215);
            this.cbxconflictItem.Name = "cbxconflictItem";
            this.cbxconflictItem.Size = new System.Drawing.Size(676, 23);
            this.cbxconflictItem.TabIndex = 12;
            // 
            // PBHeader
            // 
            this.PBHeader.BackgroundImage = global::Winforms.Properties.Resources.Header;
            this.PBHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PBHeader.Image = ((System.Drawing.Image)(resources.GetObject("PBHeader.Image")));
            this.PBHeader.Location = new System.Drawing.Point(0, 0);
            this.PBHeader.Name = "PBHeader";
            this.PBHeader.Size = new System.Drawing.Size(895, 85);
            this.PBHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBHeader.TabIndex = 13;
            this.PBHeader.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtBillAmount.Location = new System.Drawing.Point(749, 692);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.Size = new System.Drawing.Size(100, 23);
            this.txtBillAmount.TabIndex = 20;
            // 
            // lblBillAmount
            // 
            this.lblBillAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblBillAmount.AutoSize = true;
            this.lblBillAmount.Location = new System.Drawing.Point(652, 694);
            this.lblBillAmount.Name = "lblBillAmount";
            this.lblBillAmount.Size = new System.Drawing.Size(70, 15);
            this.lblBillAmount.TabIndex = 19;
            this.lblBillAmount.Text = "Bill Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalAmount.Location = new System.Drawing.Point(359, 688);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 23);
            this.txtTotalAmount.TabIndex = 22;
            // 
            // lblTotalAmout
            // 
            this.lblTotalAmout.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalAmout.AutoSize = true;
            this.lblTotalAmout.Location = new System.Drawing.Point(259, 691);
            this.lblTotalAmout.Name = "lblTotalAmout";
            this.lblTotalAmout.Size = new System.Drawing.Size(72, 15);
            this.lblTotalAmout.TabIndex = 21;
            this.lblTotalAmout.Text = "Total Amout";
            // 
            // txtSavings
            // 
            this.txtSavings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtSavings.Location = new System.Drawing.Point(538, 690);
            this.txtSavings.Name = "txtSavings";
            this.txtSavings.Size = new System.Drawing.Size(100, 23);
            this.txtSavings.TabIndex = 24;
            // 
            // lblSavings
            // 
            this.lblSavings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSavings.AutoSize = true;
            this.lblSavings.Location = new System.Drawing.Point(468, 693);
            this.lblSavings.Name = "lblSavings";
            this.lblSavings.Size = new System.Drawing.Size(47, 15);
            this.lblSavings.TabIndex = 23;
            this.lblSavings.Text = "Savings";
            // 
            // btnPrintReciept
            // 
            this.btnPrintReciept.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrintReciept.AutoSize = true;
            this.btnPrintReciept.Location = new System.Drawing.Point(715, 748);
            this.btnPrintReciept.Name = "btnPrintReciept";
            this.btnPrintReciept.Size = new System.Drawing.Size(84, 25);
            this.btnPrintReciept.TabIndex = 25;
            this.btnPrintReciept.Text = "Print Reciept";
            this.btnPrintReciept.UseVisualStyleBackColor = true;
            this.btnPrintReciept.Click += new System.EventHandler(this.BtnPrintReciept_Click);
            // 
            // dgvProductList
            // 
            this.dgvProductList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductList.Location = new System.Drawing.Point(99, 244);
            this.dgvProductList.Name = "dgvProductList";
            this.dgvProductList.RowTemplate.Height = 25;
            this.dgvProductList.Size = new System.Drawing.Size(676, 430);
            this.dgvProductList.TabIndex = 26;
            this.dgvProductList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProductList_CellEndEdit);
            this.dgvProductList.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvProductList_UserDeletedRow);
            // 
            // lblNoOfProducts
            // 
            this.lblNoOfProducts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblNoOfProducts.AutoSize = true;
            this.lblNoOfProducts.Location = new System.Drawing.Point(33, 691);
            this.lblNoOfProducts.Name = "lblNoOfProducts";
            this.lblNoOfProducts.Size = new System.Drawing.Size(89, 15);
            this.lblNoOfProducts.TabIndex = 27;
            this.lblNoOfProducts.Text = "No Of Products";
            // 
            // txtNoOfProducts
            // 
            this.txtNoOfProducts.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtNoOfProducts.Location = new System.Drawing.Point(132, 688);
            this.txtNoOfProducts.Name = "txtNoOfProducts";
            this.txtNoOfProducts.Size = new System.Drawing.Size(100, 23);
            this.txtNoOfProducts.TabIndex = 28;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(652, 185);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(895, 775);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtNoOfProducts);
            this.Controls.Add(this.lblNoOfProducts);
            this.Controls.Add(this.dgvProductList);
            this.Controls.Add(this.btnPrintReciept);
            this.Controls.Add(this.txtSavings);
            this.Controls.Add(this.lblSavings);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.lblTotalAmout);
            this.Controls.Add(this.txtBillAmount);
            this.Controls.Add(this.lblBillAmount);
            this.Controls.Add(this.PBHeader);
            this.Controls.Add(this.cbxconflictItem);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtPlace);
            this.Controls.Add(this.lblPlace);
            this.Controls.Add(this.txtOfferAmount);
            this.Controls.Add(this.lblOfferAmount);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblCustomerName);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "BillingForm";
            this.Text = "BillingForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BillingForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.bsBillingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblOfferAmount;
        private System.Windows.Forms.TextBox txtOfferAmount;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.ComboBox cbxconflictItem;
        private System.Windows.Forms.PictureBox PBHeader;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtBillAmount;
        private System.Windows.Forms.Label lblBillAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblTotalAmout;
        private System.Windows.Forms.TextBox txtSavings;
        private System.Windows.Forms.Label lblSavings;
        private System.Windows.Forms.Button btnPrintReciept;
        public System.Windows.Forms.BindingSource bsBillingList;
        private System.Windows.Forms.DataGridView dgvProductList;
        private System.Windows.Forms.Label lblNoOfProducts;
        private System.Windows.Forms.TextBox txtNoOfProducts;
        private System.Windows.Forms.Button btnAdd;
    }
}