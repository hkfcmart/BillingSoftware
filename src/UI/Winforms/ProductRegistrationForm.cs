﻿using EntityFrameWork;
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
        public ProductRegistrationForm(string barCode = "")
        {
            InitializeComponent();
            txtBarCode.Text = barCode;
        }

        private void ProductRegistrationForm_Leave(object sender, EventArgs e)
        {
            Inventry inventry = new();
            inventry.ShowDialog();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            BillInventry billInventry = new()
            {
                BarCode = txtBarCode.Text,
                ProductName = txtProductName.Text,
                BrandName = txtBrandName.Text,
                Categories = txtCategories.Text,
                Vendor = txtVendor.Text,
                ManufacturedDate = dtpManufacturedDate.Value,
                PurchasedDate = dtpPurchasedDate.Value,
                ExpiryDate = dtpExpiryDate.Value,
                ShelfNo = Int16.Parse(txtShelfNo.Text),
                MRP = Int16.Parse(txtMRP.Text),
                PurchasePrice = double.Parse(txtPurchasePrice.Text),
                SellingPrice = double.Parse(txtSellingPrice.Text),
                Quantity = int.Parse(txtQuantity.Text),
                BatchNo = int.Parse(txtBatchNo.Text),
                HSNCode = int.Parse(txtHSNCode.Text),
                Discount = double.Parse(txtDiscount.Text),
                GST = double.Parse(txtGST.Text)
            };
            billingContext.BillInventry.Add(billInventry);
            billingContext.SaveChanges();
            Inventry inventry = new();
            inventry.ShowDialog();
        }
    }
}
