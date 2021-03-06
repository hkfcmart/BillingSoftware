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
            if (!billingCall)
                EnableTextEditing();
            txtBarCode.Text = barCode.Trim();
            BillingCall = billingCall;
            txtProductName.Focus();
        }

        private void EnableTextEditing()
        {
            this.txtBrandName.ReadOnly = false;
            this.txtCategories.ReadOnly = false;
            this.txtVendor.ReadOnly = false;
            this.txtShelfNo.ReadOnly = false;
            this.txtQuantity.ReadOnly = false;
            this.txtBatchNo.ReadOnly = false;
            this.txtHSNCode.ReadOnly = false;
            this.txtDiscount.ReadOnly = false;
            this.txtGST.ReadOnly = false;
        }

        public bool BillingCall { get; }
        public string ProductName { get; set; }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            ProductName = txtProductName.Text;
            BillInventry billInventry = new();
            if (!string.IsNullOrWhiteSpace(txtBarCode.Text.Trim()))
                billInventry.BarCode = txtBarCode.Text.Trim();
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
            {
                try
                {
                    billInventry.MRP = double.Parse(txtMRP.Text);
                }
                catch
                {
                    MessageBox.Show("Enter Correct Output");
                    return;
                }
            }
            if (!string.IsNullOrWhiteSpace(txtPurchasePrice.Text))
            {
                try
                {
                    billInventry.PurchasePrice = double.Parse(txtPurchasePrice.Text);
                }
                catch
                {
                    MessageBox.Show("Enter Correct Output");
                    return;
                }

            }

            if (!string.IsNullOrWhiteSpace(txtSellingPrice.Text))
            {
                try
                {
                    billInventry.SellingPrice = double.Parse(txtSellingPrice.Text);
                }
                catch
                {
                    MessageBox.Show("Enter Correct Output");
                    return;
                }                
            }
                
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
            if(string.IsNullOrWhiteSpace(billInventry.BarCode))
            {
                if(!billingContext.DailyTable.Where(x => x.ProductName == billInventry.ProductName).Any())
                {
                    DailyTable dailyTable = CreateDailyTableRow(billInventry);
                    billingContext.DailyTable.Add(dailyTable);
                    billingContext.SaveChanges();
                }                    
            }
            else
            {
                billingContext.BillInventry.Add(billInventry);
                billingContext.SaveChanges();
            }            
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
        private static DailyTable CreateDailyTableRow(BillInventry billInventry)
        {
            DailyTable row = new();
            if (!string.IsNullOrWhiteSpace(billInventry.BarCode))
                row.BarCode = billInventry.BarCode;
            if (!string.IsNullOrWhiteSpace(billInventry.ProductName))
                row.ProductName = billInventry.ProductName;
            if (!string.IsNullOrWhiteSpace(billInventry.BrandName))
                row.BrandName = billInventry.BrandName;
            if (!string.IsNullOrWhiteSpace(billInventry.Categories))
                row.Categories = billInventry.Categories;
            if (!string.IsNullOrWhiteSpace(billInventry.Vendor))
                row.Vendor = billInventry.Vendor;
            row.ShelfNo = billInventry.ShelfNo;
            row.MRP = billInventry.MRP;
            row.PurchasePrice = billInventry.PurchasePrice;
            row.SellingPrice = billInventry.SellingPrice;
            row.BatchNo = billInventry.BatchNo;
            row.Quantity = billInventry.Quantity;
            if (!string.IsNullOrWhiteSpace(billInventry.HSNCode))
                row.HSNCode = billInventry.HSNCode;
            row.Discount = billInventry.Discount;
            row.GST = billInventry.GST;
            return row;
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
