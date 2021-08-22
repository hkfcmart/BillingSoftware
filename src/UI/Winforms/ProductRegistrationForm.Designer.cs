
namespace Winforms
{
    partial class ProductRegistrationForm
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
            this.lblBarCode = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtBrandName = new System.Windows.Forms.TextBox();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.txtCategories = new System.Windows.Forms.TextBox();
            this.lblCategories = new System.Windows.Forms.Label();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.txtSellingPrice = new System.Windows.Forms.TextBox();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.txtShelfNo = new System.Windows.Forms.TextBox();
            this.lblShelfNo = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtGST = new System.Windows.Forms.TextBox();
            this.lblGST = new System.Windows.Forms.Label();
            this.lblMRP = new System.Windows.Forms.Label();
            this.txtMRP = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblHSNCode = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblBatchNo = new System.Windows.Forms.Label();
            this.txtHSNCode = new System.Windows.Forms.TextBox();
            this.lblProductRegistrationForm = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBarCode
            // 
            this.lblBarCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Location = new System.Drawing.Point(69, 43);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(52, 15);
            this.lblBarCode.TabIndex = 0;
            this.lblBarCode.Text = "BarCode";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBarCode.Location = new System.Drawing.Point(194, 40);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.ReadOnly = true;
            this.txtBarCode.Size = new System.Drawing.Size(270, 23);
            this.txtBarCode.TabIndex = 1;
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtProductName.Location = new System.Drawing.Point(194, 69);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(270, 23);
            this.txtProductName.TabIndex = 3;
            // 
            // lblProductName
            // 
            this.lblProductName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(68, 72);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(81, 15);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "ProductName";
            // 
            // txtBrandName
            // 
            this.txtBrandName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBrandName.Location = new System.Drawing.Point(194, 98);
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.ReadOnly = true;
            this.txtBrandName.Size = new System.Drawing.Size(270, 23);
            this.txtBrandName.TabIndex = 5;
            // 
            // lblBrandName
            // 
            this.lblBrandName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Location = new System.Drawing.Point(68, 101);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(70, 15);
            this.lblBrandName.TabIndex = 4;
            this.lblBrandName.Text = "BrandName";
            // 
            // txtCategories
            // 
            this.txtCategories.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCategories.Location = new System.Drawing.Point(194, 127);
            this.txtCategories.Name = "txtCategories";
            this.txtCategories.ReadOnly = true;
            this.txtCategories.Size = new System.Drawing.Size(270, 23);
            this.txtCategories.TabIndex = 7;
            // 
            // lblCategories
            // 
            this.lblCategories.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCategories.AutoSize = true;
            this.lblCategories.Location = new System.Drawing.Point(68, 130);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(63, 15);
            this.lblCategories.TabIndex = 6;
            this.lblCategories.Text = "Categories";
            // 
            // txtVendor
            // 
            this.txtVendor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtVendor.Location = new System.Drawing.Point(194, 156);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.ReadOnly = true;
            this.txtVendor.Size = new System.Drawing.Size(270, 23);
            this.txtVendor.TabIndex = 9;
            // 
            // lblVendor
            // 
            this.lblVendor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(70, 159);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(44, 15);
            this.lblVendor.TabIndex = 8;
            this.lblVendor.Text = "Vendor";
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPurchasePrice.Location = new System.Drawing.Point(194, 253);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.ReadOnly = true;
            this.txtPurchasePrice.Size = new System.Drawing.Size(270, 23);
            this.txtPurchasePrice.TabIndex = 17;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(67, 259);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(81, 15);
            this.lblPurchasePrice.TabIndex = 16;
            this.lblPurchasePrice.Text = "PurchasePrice";
            // 
            // txtSellingPrice
            // 
            this.txtSellingPrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSellingPrice.Location = new System.Drawing.Point(194, 284);
            this.txtSellingPrice.Name = "txtSellingPrice";
            this.txtSellingPrice.Size = new System.Drawing.Size(270, 23);
            this.txtSellingPrice.TabIndex = 19;
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSellingPrice.AutoSize = true;
            this.lblSellingPrice.Location = new System.Drawing.Point(68, 289);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(68, 15);
            this.lblSellingPrice.TabIndex = 18;
            this.lblSellingPrice.Text = "SellingPrice";
            // 
            // txtShelfNo
            // 
            this.txtShelfNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtShelfNo.Location = new System.Drawing.Point(194, 189);
            this.txtShelfNo.Name = "txtShelfNo";
            this.txtShelfNo.ReadOnly = true;
            this.txtShelfNo.Size = new System.Drawing.Size(270, 23);
            this.txtShelfNo.TabIndex = 21;
            // 
            // lblShelfNo
            // 
            this.lblShelfNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblShelfNo.AutoSize = true;
            this.lblShelfNo.Location = new System.Drawing.Point(68, 195);
            this.lblShelfNo.Name = "lblShelfNo";
            this.lblShelfNo.Size = new System.Drawing.Size(49, 15);
            this.lblShelfNo.TabIndex = 20;
            this.lblShelfNo.Text = "ShelfNo";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBatchNo.Location = new System.Drawing.Point(194, 344);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.ReadOnly = true;
            this.txtBatchNo.Size = new System.Drawing.Size(270, 23);
            this.txtBatchNo.TabIndex = 23;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(68, 318);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(53, 15);
            this.lblQuantity.TabIndex = 22;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(69, 409);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(54, 15);
            this.lblDiscount.TabIndex = 22;
            this.lblDiscount.Text = "Discount";
            // 
            // txtGST
            // 
            this.txtGST.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGST.Location = new System.Drawing.Point(194, 433);
            this.txtGST.Name = "txtGST";
            this.txtGST.ReadOnly = true;
            this.txtGST.Size = new System.Drawing.Size(270, 23);
            this.txtGST.TabIndex = 23;
            // 
            // lblGST
            // 
            this.lblGST.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGST.AutoSize = true;
            this.lblGST.Location = new System.Drawing.Point(69, 440);
            this.lblGST.Name = "lblGST";
            this.lblGST.Size = new System.Drawing.Size(27, 15);
            this.lblGST.TabIndex = 22;
            this.lblGST.Text = "GST";
            // 
            // lblMRP
            // 
            this.lblMRP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMRP.AutoSize = true;
            this.lblMRP.Location = new System.Drawing.Point(70, 225);
            this.lblMRP.Name = "lblMRP";
            this.lblMRP.Size = new System.Drawing.Size(32, 15);
            this.lblMRP.TabIndex = 20;
            this.lblMRP.Text = "MRP";
            // 
            // txtMRP
            // 
            this.txtMRP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMRP.Location = new System.Drawing.Point(194, 221);
            this.txtMRP.Name = "txtMRP";
            this.txtMRP.Size = new System.Drawing.Size(270, 23);
            this.txtMRP.TabIndex = 21;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtQuantity.Location = new System.Drawing.Point(194, 314);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(270, 23);
            this.txtQuantity.TabIndex = 23;
            // 
            // lblHSNCode
            // 
            this.lblHSNCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblHSNCode.AutoSize = true;
            this.lblHSNCode.Location = new System.Drawing.Point(67, 377);
            this.lblHSNCode.Name = "lblHSNCode";
            this.lblHSNCode.Size = new System.Drawing.Size(59, 15);
            this.lblHSNCode.TabIndex = 22;
            this.lblHSNCode.Text = "HSNCode";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDiscount.Location = new System.Drawing.Point(194, 404);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(270, 23);
            this.txtDiscount.TabIndex = 23;
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBatchNo.AutoSize = true;
            this.lblBatchNo.Location = new System.Drawing.Point(68, 348);
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(53, 15);
            this.lblBatchNo.TabIndex = 22;
            this.lblBatchNo.Text = "BatchNo";
            // 
            // txtHSNCode
            // 
            this.txtHSNCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtHSNCode.Location = new System.Drawing.Point(194, 373);
            this.txtHSNCode.Name = "txtHSNCode";
            this.txtHSNCode.ReadOnly = true;
            this.txtHSNCode.Size = new System.Drawing.Size(270, 23);
            this.txtHSNCode.TabIndex = 23;
            // 
            // lblProductRegistrationForm
            // 
            this.lblProductRegistrationForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProductRegistrationForm.AutoSize = true;
            this.lblProductRegistrationForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductRegistrationForm.Location = new System.Drawing.Point(137, 9);
            this.lblProductRegistrationForm.Name = "lblProductRegistrationForm";
            this.lblProductRegistrationForm.Size = new System.Drawing.Size(193, 21);
            this.lblProductRegistrationForm.TabIndex = 24;
            this.lblProductRegistrationForm.Text = "Product Registration Form";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(284, 464);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 25;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // ProductRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 495);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblProductRegistrationForm);
            this.Controls.Add(this.txtHSNCode);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtGST);
            this.Controls.Add(this.lblBatchNo);
            this.Controls.Add(this.lblGST);
            this.Controls.Add(this.lblHSNCode);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtMRP);
            this.Controls.Add(this.lblMRP);
            this.Controls.Add(this.txtShelfNo);
            this.Controls.Add(this.lblShelfNo);
            this.Controls.Add(this.txtSellingPrice);
            this.Controls.Add(this.lblSellingPrice);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.txtVendor);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.txtCategories);
            this.Controls.Add(this.lblCategories);
            this.Controls.Add(this.txtBrandName);
            this.Controls.Add(this.lblBrandName);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.lblBarCode);
            this.Name = "ProductRegistrationForm";
            this.Text = "ProductRegistrationForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductRegistrationForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtBrandName;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.TextBox txtCategories;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.TextBox txtSellingPrice;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.TextBox txtShelfNo;
        private System.Windows.Forms.Label lblShelfNo;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtGST;
        private System.Windows.Forms.Label lblGST;
        private System.Windows.Forms.Label lblMRP;
        private System.Windows.Forms.TextBox txtMRP;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblHSNCode;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblBatchNo;
        private System.Windows.Forms.TextBox txtHSNCode;
        private System.Windows.Forms.Label lblProductRegistrationForm;
        private System.Windows.Forms.Button btnRegister;
    }
}