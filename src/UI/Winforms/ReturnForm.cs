using EntityFrameWork;
using EntityFrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Winforms
{
    public partial class ReturnForm : Form
    {
        BillingContext billingContext = new();
        List<BillInventry> productList = new();
        List<BillDisplayReturn> billDisplayReturns = new();
        List<BillInventry> billInventries = new();
        //public bool Saved { get; set; }
        public bool NewProduct { get; set; }
        int itemCount = 1;
        public ReturnForm()
        {
            InitializeComponent();
        }
        
        private void SetColumnEdtingTOFalse()
        {
            if (dgvProductList.Columns["index"] != null)
            {
                dgvProductList.Columns["Index"].ReadOnly = true;
                dgvProductList.Columns["DateTime"].ReadOnly = true;
                dgvProductList.Columns["ProductName"].ReadOnly = true;
                dgvProductList.Columns["HSNCode"].ReadOnly = true;
                dgvProductList.Columns["MRP"].ReadOnly = true;
                dgvProductList.Columns["SellingPrice"].ReadOnly = true;
                dgvProductList.Columns["SubTotal"].ReadOnly = true;
            }
        }
        private void BillCalculation()
        {
            Double totalAmount = 0;
            Double GST = 0;
            Double billAmount = 0;
            Double savings = 0;
            Double subTotal = 0;
            foreach (BillDisplayReturn billDisplayReturn in billDisplayReturns)
            {
                totalAmount = totalAmount + billDisplayReturn.MRP * billDisplayReturn.Quantity * 1.0;
                GST = GST + billDisplayReturn.SellingPrice * 12 / 100;
                billAmount = billAmount + billDisplayReturn.SellingPrice * billDisplayReturn.Quantity * 1.0;
                savings = totalAmount - billAmount;
            }
            subTotal = billAmount - GST;
            txtTotalAmount.Text = totalAmount.ToString();
            txtSavings.Text = savings.ToString();
            //txtSubTotal.Text = subTotal.ToString();
            //txtGST.Text = GST.ToString();
            txtBillAmount.Text = billAmount.ToString();
            txtNoOfProducts.Text = billDisplayReturns.Count.ToString();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            productList = new();
            List<BillData> bills = billingContext.BillData.Where(x => x.BillNo == int.Parse(txtBillNo.Text)).ToList();
            foreach (BillData bill in bills)
            {
                BillInventry Product = new BillInventry
                {
                    BarCode = bill.BarCode,
                    BatchNo = bill.BatchNo,
                    BrandName = bill.BrandName,
                    Categories = bill.Categories,
                    Discount = bill.Discount,
                    GST = bill.GST,
                    HSNCode = bill.HSNCode,
                    Id = bill.Id,
                    Vendor = bill.Vendor,
                    ManufacturingDate = bill.ManufacturingDate,
                    PurchasingDate = bill.PurchasingDate,
                    ExpiryDate = bill.ExpiryDate,
                    MRP = bill.MRP,
                    ProductName = bill.ProductName,
                    PurchasePrice = bill.PurchasePrice,
                    Quantity = bill.Quantity,
                    SellingPrice = bill.SellingPrice,
                    ShelfNo = bill.ShelfNo
                };
                productList.Add(Product);
            }
            foreach (BillInventry product in productList)
                cmbPartialSearch.Items.Add(product.ProductName + " -- " + product.ManufacturingDate + " -- " + product.MRP + " -- " + product.BarCode);
            cmbPartialSearch.DroppedDown = true;
        }

        private void cmbPartialSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectProduct(sender);
            cmbPartialSearch.SelectedText = "";
            cmbPartialSearch.SelectedItem = -1;
        }

        private void SelectProduct(object sender)
        {
            string ProductName = ((System.Windows.Forms.ComboBox)sender).SelectedItem.ToString().Split("--")[0].Trim();
            string MDate = ((System.Windows.Forms.ComboBox)sender).SelectedItem.ToString().Split("--")[1].Trim();
            string MRP = ((System.Windows.Forms.ComboBox)sender).SelectedItem.ToString().Split("--")[2].Trim();
            string barcode = ((System.Windows.Forms.ComboBox)sender).SelectedItem.ToString().Split("--").Last().Trim();
            BillInventry product = productList.Where(x =>
                (string.IsNullOrEmpty(x.BarCode) ? "" : x.BarCode) == barcode && (string.IsNullOrEmpty(x.ManufacturingDate) ? "" : x.ManufacturingDate) == MDate
                && x.MRP == Convert.ToDouble(MRP.Trim()) && (string.IsNullOrEmpty(x.ProductName) ? "" : x.ProductName.Trim()) == ProductName).ToList().FirstOrDefault();
            AddProductToBillDisplayReturnsAndInventries(product, DateTime.Now);
            bsBillingListReturn.DataSource = new();
            bsBillingListReturn.DataSource = billDisplayReturns;
            dgvProductList.DataSource = bsBillingListReturn;
            BillCalculation();
        }

        private void AddProductToBillDisplayReturnsAndInventries(BillInventry product, DateTime dateTime)
        {
            if(billInventries.Count > 0 &&  billInventries.Where(x =>
                (string.IsNullOrEmpty(x. BarCode) ? "" : x.BarCode) == product.BarCode &&
                (string.IsNullOrEmpty(x.ManufacturingDate) ? null : x.ManufacturingDate) == product.ManufacturingDate
                && x.MRP == product.MRP && (string.IsNullOrEmpty(x.ProductName) ? "" : x.ProductName.Trim()) == product.ProductName.Trim()).Any())
            {
                billInventries.Where(x =>
                (string.IsNullOrEmpty(x.BarCode) ? "" : x.BarCode) == product.BarCode &&
                (string.IsNullOrEmpty(x.ManufacturingDate) ? null : x.ManufacturingDate) == product.ManufacturingDate
                && x.MRP == product.MRP && (string.IsNullOrEmpty(x.ProductName) ? "" : x.ProductName.Trim()) == product.ProductName.Trim()).FirstOrDefault().Quantity += 1;
                billDisplayReturns.Where(x =>
                (string.IsNullOrEmpty(x.BarCode) ? "" : x.BarCode) == product.BarCode &&
                (string.IsNullOrEmpty(x.ManufacturingDate) ? null : x.ManufacturingDate) == product.ManufacturingDate
                && x.MRP == product.MRP && (string.IsNullOrEmpty(x.ProductName) ? "" : x.ProductName.Trim()) == product.ProductName.Trim()).FirstOrDefault().Quantity += 1;
            }
            else
            {
                billInventries.Add(product);
                billDisplayReturns.Add(new BillDisplayReturn
                {
                    Index = itemCount++,
                    BarCode = product.BarCode,
                    ManufacturingDate = product.ManufacturingDate,
                    ReturnDate = dateTime,
                    HSNCode = product.HSNCode,
                    ProductName = product.ProductName,
                    MRP = product.MRP,
                    SellingPrice = product.SellingPrice,
                    Quantity = 1,
                    SubTotal = product.SellingPrice
                });
            }            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            if(!string.IsNullOrWhiteSpace(txtBillNo.Text) && billDisplayReturns.Count > 0)
            {
                SaveReturn();
                string message = "Products Returned Succefully";
                string title = "Success Message";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
            }
            else
            {
                string message = "Please Enter the Bill No and select item to return";
                string title = "reutrn Window";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons);
            }
        }

        private void SaveReturn()
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            List<ReturnBillData> returnBillDatas = billingContext.ReturnBillData.Where(x => x.BillNo == int.Parse(txtBillNo.Text)).ToList();
            DateTime date = billingContext.BillData.Where(x => x.BillNo == int.Parse(txtBillNo.Text)).FirstOrDefault().BillDate;
            foreach (BillInventry billInventry in billInventries)
            {
                BillInventry billInventry1 = billingContext.BillInventry.Where(x =>
                (string.IsNullOrEmpty(x.BarCode) ? "" : x.BarCode) == billInventry.BarCode &&
                (string.IsNullOrEmpty(x.ManufacturingDate) ? null : x.ManufacturingDate) == billInventry.ManufacturingDate
                && x.MRP == billInventry.MRP && (string.IsNullOrEmpty(x.ProductName) ? "" : x.ProductName.Trim()) == billInventry.ProductName.Trim()).FirstOrDefault();
                MontlyTable montlyTable = billingContext.MontlyTable.Where(x => 
                    DbF.DateDiffYear(x.Date, date) == 0 && DbF.DateDiffMonth(x.Date, date) == 0 &&
                    (string.IsNullOrEmpty(x.BarCode) ? "" : x.BarCode) == billInventry.BarCode &&
                    (string.IsNullOrEmpty(x.ManufacturingDate) ? null : x.ManufacturingDate) == billInventry.ManufacturingDate
                    && x.MRP == billInventry.MRP && (string.IsNullOrEmpty(x.ProductName) ? "" : x.ProductName.Trim()) == billInventry.ProductName.Trim()).FirstOrDefault();
                if (returnBillDatas.Count > 0)
                {
                    if(returnBillDatas.Where(x =>
                (string.IsNullOrEmpty(x.BarCode) ? "" : x.BarCode) == billInventry.BarCode && 
                (string.IsNullOrEmpty(x.ManufacturingDate) ? "" : x.ManufacturingDate) == billInventry.ManufacturingDate
                && x.MRP == billInventry.MRP && (string.IsNullOrEmpty(x.ProductName) ? "" : x.ProductName.Trim()) == billInventry.ProductName).ToList().Any())
                    {
                        ReturnBillData returnBillData = returnBillDatas.Where(x =>
                (string.IsNullOrEmpty(x.BarCode) ? "" : x.BarCode) == billInventry.BarCode &&
                (string.IsNullOrEmpty(x.ManufacturingDate) ? "" : x.ManufacturingDate) == billInventry.ManufacturingDate
                && x.MRP == billInventry.MRP && (string.IsNullOrEmpty(x.ProductName) ? "" : x.ProductName.Trim()) == billInventry.ProductName).ToList().FirstOrDefault();
                        if(returnBillData.Quantity != billInventry.Quantity)
                        {
                            double diff = returnBillData.Quantity - billInventry.Quantity;                            
                            billInventry1.Quantity += diff;                            
                            montlyTable.Quantity -= diff;
                            returnBillData.Quantity = billInventry.Quantity;
                            billingContext.SaveChanges();
                        }                        
                    }
                    else
                    {
                        ReturnBillData returnBillData = CreateReturnBillData(billInventry);
                        billInventry1.Quantity += billInventry.Quantity;
                        montlyTable.Quantity -= billInventry.Quantity;
                        billingContext.ReturnBillData.Add(returnBillData);
                        billingContext.SaveChanges();

                    }
                }
                else
                {
                    ReturnBillData returnBillData = CreateReturnBillData(billInventry);
                    billInventry1.Quantity += billInventry.Quantity;
                    montlyTable.Quantity -= billInventry.Quantity;
                    billingContext.ReturnBillData.Add(returnBillData);
                    billingContext.SaveChanges();
                }
                //if()
            }
        }

        private ReturnBillData CreateReturnBillData(BillInventry billInventry)
        {
            return new()
            {
                ReturnDate = DateTime.Now,
                BarCode = billInventry.BarCode,
                BatchNo = billInventry.BatchNo,
                BillNo = int.Parse(txtBillNo.Text),
                BrandName = billInventry.BrandName,
                Categories = billInventry.Categories,
                Discount = billInventry.Discount,
                ExpiryDate = billInventry.ExpiryDate,
                GST = billInventry.GST,
                HSNCode = billInventry.HSNCode,
                ManufacturingDate = billInventry.ManufacturingDate,
                MRP = billInventry.MRP,
                ProductName = billInventry.ProductName,
                PurchasePrice = billInventry.PurchasePrice,
                SellingPrice = billInventry.SellingPrice,
                PurchasingDate = billInventry.PurchasingDate,
                Quantity = billInventry.Quantity,
                ShelfNo = billInventry.ShelfNo,
                Vendor = billInventry.Vendor
            };
        }

        private void dgvProductList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (billInventries.Count > e.RowIndex)
                {
                    double quantity = double.Parse(dgvProductList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    BillData billData = billingContext.BillData.Where(x =>
                (string.IsNullOrEmpty(x.BarCode) ? "" : x.BarCode) == billInventries[e.RowIndex].BarCode &&
                (string.IsNullOrEmpty(x.ManufacturingDate) ? "" : x.ManufacturingDate) == billInventries[e.RowIndex].ManufacturingDate
                && x.MRP == billInventries[e.RowIndex].MRP && (string.IsNullOrEmpty(x.ProductName) ? "" : x.ProductName.Trim()) == billInventries[e.RowIndex].ProductName).FirstOrDefault();
                    if (quantity <= billData.Quantity)
                    {
                        billInventries[e.RowIndex].Quantity = quantity;
                        billDisplayReturns[e.RowIndex].Quantity = quantity;
                        billDisplayReturns[e.RowIndex].SubTotal = quantity * 1.0 * billDisplayReturns[e.RowIndex].SellingPrice;
                        BillCalculation();
                    }
                    else
                    {
                        billDisplayReturns[e.RowIndex].Quantity = billInventries[e.RowIndex].Quantity;
                        dgvProductList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = billInventries[e.RowIndex].Quantity;
                        MessageBox.Show("Cannot Enter More Than 100");
                    }
                }
                else
                {
                    bsBillingListReturn.DataSource = new();
                    //dgvProductList.DataSource = new();
                    bsBillingListReturn.DataSource = billDisplayReturns;
                    dgvProductList.Rows.RemoveAt(e.RowIndex);
                    dgvProductList.DataSource = bsBillingListReturn;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
