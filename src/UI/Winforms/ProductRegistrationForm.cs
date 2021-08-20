using EntityFrameWork;
using EntityFrameWork.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms
{
    public partial class ProductRegistrationForm : Form
    {
        BillingContext billingContext = new();
        public ProductRegistrationForm(string barCode = "", bool billingCall = false)
        {
            InitializeComponent();
            txtBarCode.Text = barCode;
            BillingCall = billingCall;
        }

        public bool BillingCall { get; }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            BillInventry billInventry = new();
            if(!string.IsNullOrWhiteSpace(txtBarCode.Text))
                billInventry.BarCode = txtBarCode.Text;
            if (!string.IsNullOrWhiteSpace(txtProductName.Text))
                billInventry.ProductName = txtProductName.Text;
            if (!string.IsNullOrWhiteSpace(txtBrandName.Text))
                billInventry.BrandName = txtBrandName.Text;
            if (!string.IsNullOrWhiteSpace(txtCategories.Text))
                billInventry.Categories = txtCategories.Text;
            if (!string.IsNullOrWhiteSpace(txtVendor.Text))
                billInventry.Vendor = txtVendor.Text;
            //if (!string.IsNullOrEmpty(txtProductName.Text))
            //    billInventry.ManufacturedDate = dtpManufacturedDate.Value;
            //if (!string.IsNullOrEmpty(txtProductName.Text))
            //    billInventry.PurchasedDate = dtpPurchasedDate.Value;
            //if (!string.IsNullOrEmpty(txtProductName.Text))
            //    billInventry.ExpiryDate = dtpExpiryDate.Value;
            if (!string.IsNullOrWhiteSpace(txtShelfNo.Text))
                billInventry.ShelfNo = Int16.Parse(txtShelfNo.Text);
            if (!string.IsNullOrWhiteSpace(txtMRP.Text))
                billInventry.MRP = Int16.Parse(txtMRP.Text);
            if (!string.IsNullOrWhiteSpace(txtPurchasePrice.Text))
                billInventry.PurchasePrice = double.Parse(txtPurchasePrice.Text);
            if (!string.IsNullOrWhiteSpace(txtSellingPrice.Text))
                billInventry.SellingPrice = double.Parse(txtSellingPrice.Text);
            if (!string.IsNullOrWhiteSpace(txtQuantity.Text))
                billInventry.Quantity = int.Parse(txtQuantity.Text);
            if (!string.IsNullOrWhiteSpace(txtBatchNo.Text))
                billInventry.BatchNo = int.Parse(txtBatchNo.Text);
            if (!string.IsNullOrWhiteSpace(txtHSNCode.Text))
                billInventry.HSNCode = txtHSNCode.Text;
            if (!string.IsNullOrWhiteSpace(txtDiscount.Text))
                billInventry.Discount = double.Parse(txtDiscount.Text);
            if (!string.IsNullOrWhiteSpace(txtGST.Text))
                billInventry.GST = double.Parse(txtGST.Text);
            billingContext.BillInventry.Add(billInventry);
            billingContext.SaveChanges();
            if (!BillingCall)
            {
                this.Hide();
                Inventry inventry = new();
                inventry.ShowDialog(); 
            }
            else
            {
                this.Hide();
            }
        }

        private void ProductRegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            if(!BillingCall)
            { 
                Inventry inventry = new();
                inventry.ShowDialog();
            }
        }
    }
}
