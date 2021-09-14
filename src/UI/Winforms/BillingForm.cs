using EntityFrameWork;
using EntityFrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms
{
    public partial class BillingForm : Form
    {
        public int BillNo { get; set; }
        public bool Saved { get; set; }
        public BillingForm()
        {
            InitializeComponent();
            dgvProductList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            productList = billingContext.BillInventry.ToList();
            foreach (BillInventry product in productList)
                cmbPartialSearch.Items.Add(product.ProductName + " - " + product.BarCode);
            Saved = false;
        }
        List<BillInventry> productList = new();
        public bool NewProduct { get; set; }
        BillingContext billingContext = new();
        List<BillInventry> billInventries = new();
        List<BillDisplay> billDisplays = new();
        int itemCount = 1;
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtBarcode.Text) || txtBarcode.Text.Length < 7)
            {
                MessageBox.Show("Please Enter Valid Barcode");
            }
            else
            {
                SearchBarCode();
                if (NewProduct)
                {
                    SearchBarCode();
                    NewProduct = false;
                }
            }            
        }
        private void SearchBarCode()
        {
            string barCode = txtBarcode.Text;
            if (billInventries.Count > 0 && billInventries.Where(x => x.BarCode == barCode).Any())
            {
                int index = billInventries.FindIndex(x => x.BarCode == barCode);
                billDisplays[index].Quantity++;
                billInventries[index].Quantity++;
                billDisplays[index].SubTotal = Math.Round(billDisplays[index].SellingPrice * billDisplays[index].Quantity, 2);
                bsBillingList.DataSource = new();
                bsBillingList.DataSource = billDisplays;
                dgvProductList.DataSource = bsBillingList;
                txtBarcode.Text = "";
                BillCalculation();
            }
            else if (billingContext.BillInventry.Where(x => x.BarCode == barCode).Any())
            {
                List<BillInventry> inventries = billingContext.BillInventry.Where(x => x.BarCode == barCode).ToList();
                if (inventries.Count() > 1)
                {
                    cmbPartialSearch.Items.Clear();
                    foreach (BillInventry inventry in inventries)
                        cmbPartialSearch.Items.Add(inventry);
                }
                else
                {
                    BillInventry billInventry = billingContext.BillInventry.Where(x => x.BarCode == barCode).ToList().First();
                    billInventry.Quantity = 1;
                    billInventries.Add(billInventry);
                    billDisplays.Add(new BillDisplay
                    {
                        Index = itemCount++,
                        HSNCode = billInventry.HSNCode,
                        ProductName = billInventry.ProductName,
                        MRP = billInventry.MRP,
                        SellingPrice = billInventry.SellingPrice,
                        Quantity = 1,
                        SubTotal = billInventry.SellingPrice
                    });
                }
                bsBillingList.DataSource = new();
                bsBillingList.DataSource = billDisplays;
                dgvProductList.DataSource = bsBillingList;
                txtBarcode.Text = "";
                BillCalculation();
            }
            else
            {
                MessageBox.Show("No Product with Barcode Found", "NO Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Hide();
                ProductRegistrationForm productRegistrationForm = new(txtBarcode.Text, true);
                productRegistrationForm.ShowDialog();
                NewProduct = true;
            }
            SetColumnEdtingTOFalse();
        }

        private void SetColumnEdtingTOFalse()
        {
            if (dgvProductList.Columns["index"] != null)
            {
                dgvProductList.Columns["Index"].ReadOnly = true;
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
            foreach (BillDisplay billDisplay in billDisplays)
            {
                totalAmount = totalAmount + billDisplay.MRP * billDisplay.Quantity;
                GST = GST + billDisplay.SellingPrice * 12 / 100;
                billAmount = billAmount + billDisplay.SellingPrice * billDisplay.Quantity;
                savings = totalAmount - billAmount;
            }
            subTotal = billAmount - GST;
            txtTotalAmount.Text = totalAmount.ToString();
            txtSavings.Text = savings.ToString();
            //txtSubTotal.Text = subTotal.ToString();
            //txtGST.Text = GST.ToString();
            txtBillAmount.Text = billAmount.ToString();
            txtNoOfProducts.Text = billDisplays.Count.ToString();
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBarCode();
                if (NewProduct)
                {
                    SearchBarCode();
                    NewProduct = false;
                    txtBarcode.Text = "";
                }
            }
        }
        private void BtnPrintReciept_Click(object sender, EventArgs e)
        {
            if (!Saved)
                SaveBillData();
            Print();            
        }

        private void UpdatePurchase()
        {
            DailyUpdates();
            UpdateInventry();
            MontlyUpdates();
        }

        private void UpdateInventry()
        {
            foreach (var item in billInventries)
            {
                if (string.IsNullOrWhiteSpace(item.BarCode))
                {
                }
                else
                {
                    if (billingContext.BillInventry.Where(x => x.BarCode == item.BarCode && x.ProductName == item.ProductName).Any())
                    {
                        //List<BillInventry> listvalues = billingContext.BillInventry.ToList();
                        //var row = listvalues.Where(x => x.ProductName == billInventry.ProductName).First();
                        var rowBI = billingContext.BillInventry.Where(x => x.BarCode == item.BarCode).First();
                        int quantity = item.Quantity;
                        rowBI.Quantity -= quantity;
                        billingContext.SaveChanges();
                    }
                    //else
                    //{
                    //    DailyTable row = CreateDailyTableRow(billInventry);
                    //    billingContext.DailyTable.Add(row);
                    //}
                }
            }
        }

        private void MontlyUpdates()
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            foreach (var billInventry in billInventries)
            {
                if (string.IsNullOrWhiteSpace(billInventry.BarCode))
                {
                    if (billingContext.MontlyTable.Where(x =>  DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).Any())
                    {
                        var row = billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).First();
                        row.Quantity += billInventry.Quantity;
                        billingContext.SaveChanges();
                    }
                    else
                    {
                        MontlyTable row = CreateMonthlyTableRow(billInventry);
                        billingContext.MontlyTable.Add(row);
                        billingContext.SaveChanges();
                    }
                }
                else
                {
                    if (billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && x.BarCode == billInventry.BarCode && x.ProductName == billInventry.ProductName).Any())
                    {
                        var row = billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && x.BarCode == billInventry.BarCode && x.ProductName == billInventry.ProductName).First();
                        row.Quantity += billInventry.Quantity;
                        billingContext.SaveChanges();
                    }
                    else
                    {
                        MontlyTable row = CreateMonthlyTableRow(billInventry);
                        billingContext.MontlyTable.Add(row);
                        billingContext.SaveChanges();
                    }
                }
            }
            billingContext.SaveChanges();
        }

        private MontlyTable CreateMonthlyTableRow(BillInventry billInventry)
        {
            MontlyTable row = new();
            row.Date = DateTime.Now;
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

        private void DailyUpdates()
        {
            foreach (var billInventry in billInventries)
            {
                if (string.IsNullOrWhiteSpace(billInventry.BarCode))
                {
                    if (billingContext.DailyTable.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).Any())
                    {
                        var row = billingContext.DailyTable.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).First();
                        row.Quantity += billInventry.Quantity;
                        billingContext.SaveChanges();
                    }
                    else
                    {
                        DailyTable row = CreateDailyTableRow(billInventry);
                        billingContext.DailyTable.Add(row);
                    }
                }
                else
                {
                    if (billingContext.DailyTable.Where(x => x.BarCode == billInventry.BarCode && x.ProductName == billInventry.ProductName).Any())
                    {
                        var row = billingContext.DailyTable.Where(x => x.ProductName == billInventry.ProductName).First();
                        row.Quantity = row.Quantity + billInventry.Quantity;
                        billingContext.SaveChanges();
                    }
                    else
                    {
                        DailyTable row = CreateDailyTableRow(billInventry);
                        billingContext.DailyTable.Add(row);
                        billingContext.SaveChanges();
                    }
                }
            }
            billingContext.SaveChanges();
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

        public void Print()
        {
            var doc = new PrintDocument();
            var paperSize = new PaperSize("Custom", 520, 4000);
            doc.DefaultPageSettings.PaperSize = paperSize;
            doc.PrintPage += new PrintPageEventHandler(ProvideContent);
            doc.Print();
        }

        public void ProvideContent(object sender, PrintPageEventArgs e)
        {
            int startX = 0;
            int startY = 0;
            int offset = 0;
            //startY = 10;
            Graphics graphics = e.Graphics;
            Font font = new Font(System.Drawing.FontFamily.GenericSansSerif, 20, System.Drawing.FontStyle.Bold);
            Rectangle rect = new Rectangle(0, startY + offset, 283, (int)(font.GetHeight() + 2));
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            graphics.DrawString("Bill Estimate", font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            offset = offset + (int)font.GetHeight() + 10;
            startY = startY + offset;
            var image = Image.FromFile("Header.jpg");
            graphics.DrawImage(image, 0, startY, 283, 100);
            startY = startY + 100;
            rect = new Rectangle(0, startY, 283, (int)(font.GetHeight() + 20));
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 10, System.Drawing.FontStyle.Bold); 
            format.Alignment = StringAlignment.Center;
            format.FormatFlags = StringFormatFlags.LineLimit;
            format.Trimming = StringTrimming.Word;
            graphics.DrawString("NO. 10C, Old No. 18/4282, Old BM Road, Opp Railways Station, Ramanagaram, Karanataka-562159", font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight()* 3 + 5);
            format.Alignment = StringAlignment.Near;
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 10, System.Drawing.FontStyle.Regular);
            rect = new Rectangle(0, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("Data: " + DateTime.Now, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            rect = new Rectangle(0, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("GST No: 29AANFH9192F1ZR", font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("Bill No: " + txtBillNo.Text , font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 10, System.Drawing.FontStyle.Bold);
            startY = startY + (int)(font.GetHeight() + 5);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("-".PadRight(100, '-'), font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            rect = new Rectangle(startX, startY, 100, (int)(font.GetHeight() + 5));
            graphics.DrawString("Product", font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startX = startX + 100;
            rect = new Rectangle(startX, startY, 40, (int)(font.GetHeight() + 5));
            graphics.DrawString("MRP" + txtCustomerName.Text, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startX = startX + 40;
            rect = new Rectangle(startX, startY, 40, (int)(font.GetHeight() + 5));
            graphics.DrawString("QTY" + txtCustomerName.Text, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startX = startX + 40;
            rect = new Rectangle(startX, startY, 50, (int)(font.GetHeight() + 5));
            graphics.DrawString("PRICE" + txtCustomerName.Text, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startX = startX + 50;
            rect = new Rectangle(startX, startY, 60, (int)(font.GetHeight() + 5));
            graphics.DrawString("Amount" + txtCustomerName.Text, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            startX = 0;
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("-".PadRight(80, '-'), font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 8, System.Drawing.FontStyle.Regular);
            int NoOfLines = 1;
            foreach (var item in billDisplays)
            {                                
                format.Alignment = StringAlignment.Near;
                NoOfLines = 1;                
                if (item.ProductName.Length > 15)
                {
                    format.FormatFlags = StringFormatFlags.LineLimit;
                    format.Trimming = StringTrimming.Word;
                    NoOfLines = (int)Math.Ceiling((decimal)(item.ProductName.Length * 1.0 / 15));
                }
                rect = new Rectangle(startX, startY, 100, (int)(font.GetHeight() * NoOfLines + 5));
                graphics.DrawString(item.ProductName, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
                startX = startX + 100;
                rect = new Rectangle(startX, startY, 40, (int)(font.GetHeight() + 5));
                format.Alignment = StringAlignment.Center;
                graphics.DrawString(item.MRP.ToString(), font, new SolidBrush(System.Drawing.Color.Black), rect, format);
                startX = startX + 40;
                rect = new Rectangle(startX, startY, 40, (int)(font.GetHeight() + 5));
                graphics.DrawString(item.Quantity.ToString(), font, new SolidBrush(System.Drawing.Color.Black), rect, format);
                startX = startX + 40;
                rect = new Rectangle(startX, startY, 50, (int)(font.GetHeight() + 5));
                graphics.DrawString(item.SellingPrice.ToString(), font, new SolidBrush(System.Drawing.Color.Black), rect, format);
                startX = startX + 50;
                rect = new Rectangle(startX, startY, 60, (int)(font.GetHeight() + 5));
                graphics.DrawString(item.SubTotal.ToString(), font, new SolidBrush(System.Drawing.Color.Black), rect, format);
                startY = startY + (int)(font.GetHeight() * NoOfLines + 5);
                startX = 0;
            }
            startY = startY + (int)(font.GetHeight() * NoOfLines + 5);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 10, System.Drawing.FontStyle.Bold);
            format.Alignment = StringAlignment.Center;
            graphics.DrawString("-".PadRight(80, '-'), font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 8, System.Drawing.FontStyle.Regular);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            format.Alignment = StringAlignment.Near;
            graphics.DrawString("No Of Proucts: " + txtNoOfProducts.Text, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            format.Alignment = StringAlignment.Far;
            graphics.DrawString("Total Amount: " + txtTotalAmount.Text, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("Savings: " + txtSavings.Text, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("=".PadRight(50, '=') + txtSavings.Text, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 10, System.Drawing.FontStyle.Bold);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("Bill Total:" + txtBillAmount.Text, font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 8, System.Drawing.FontStyle.Regular);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("=".PadRight(50, '='), font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 8, System.Drawing.FontStyle.Bold);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            format.Alignment = StringAlignment.Center;
            graphics.DrawString("Thank You", font, new SolidBrush(System.Drawing.Color.Black), rect, format);
        }

        private void DgvProductList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(billInventries.Count > e.RowIndex)
                {
                    int quantity = int.Parse(dgvProductList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    if(quantity < 100)
                    {
                        billInventries[e.RowIndex].Quantity = quantity;
                        billDisplays[e.RowIndex].Quantity = quantity;
                        billDisplays[e.RowIndex].SubTotal = quantity * billDisplays[e.RowIndex].SellingPrice;
                        BillCalculation();
                    }             
                    else
                    {
                        billDisplays[e.RowIndex].Quantity = billInventries[e.RowIndex].Quantity;
                        dgvProductList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = billInventries[e.RowIndex].Quantity;
                        MessageBox.Show("Cannot Enter More Than 100");
                    }
                }                
                else
                {
                    bsBillingList.DataSource = new();
                    //dgvProductList.DataSource = new();
                    bsBillingList.DataSource = billDisplays;
                    dgvProductList.Rows.RemoveAt(e.RowIndex);
                    dgvProductList.DataSource = bsBillingList;
                }
            }
            catch (Exception)
            {
            }
        }

        private void BillingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (!Saved)
                SaveBillData();
           
            this.Hide();
            BillingSoftware billingSoftware = new();
            billingSoftware.ShowDialog();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ProductRegistrationForm productRegistrationForm = new(txtBarcode.Text, true);
            productRegistrationForm.ShowDialog();
            string productName = productRegistrationForm.ProductName;
            if (billingContext.DailyTable.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == productName).Any())
            {
                DailyTable dailyTable = billingContext.DailyTable.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == productName).First();
                BillInventry billInventry = new()
                {
                    ProductName = dailyTable.ProductName,
                    MRP = dailyTable.MRP,
                    SellingPrice = dailyTable.SellingPrice,
                    Quantity = 1
                };
                billInventries.Add(billInventry);
                billDisplays.Add(new BillDisplay
                {
                    Index = itemCount++,
                    HSNCode = billInventry.HSNCode,
                    ProductName = billInventry.ProductName,
                    MRP = billInventry.MRP,
                    SellingPrice = billInventry.SellingPrice,
                    Quantity = 1,
                    SubTotal = billInventry.SellingPrice
                });
                bsBillingList.DataSource = new();
                bsBillingList.DataSource = billDisplays;
                dgvProductList.DataSource = bsBillingList;
                txtBarcode.Text = "";
                BillCalculation();
            }
        }

        private void DgvProductList_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //dgvProductList.Remove(e.Row);
            bsBillingList.Remove(e.Row);
            for (int i = 0; i < billInventries.Count; i++)
            {
                if (!billDisplays.Where(x => x.ProductName == billInventries[i].ProductName).Any())
                {
                    billInventries.RemoveAt(i);
                    i--;
                }                
            }
            BillCalculation();
        }

        private void btnSearchByProductName_Click(object sender, EventArgs e)
        {

        }

        private void CmbPartialSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string barcode = ((System.Windows.Forms.ComboBox)sender).SelectedItem.ToString().Split("-").Last().Trim();
            BillInventry billInventry = productList.Where(x => x.BarCode == barcode).ToList().First();
            //billInventry.Quantity = 1;
            if (billInventries.Count > 0 && billInventries.Where(x => x.BarCode == billInventry.BarCode).Any())
            {
                //billInventries.Where(x => x.BarCode == billInventry.BarCode).First().Quantity++;
                for(int i=0; i<billInventries.Count; i++)
                {
                    if(billInventries[i].BarCode == billInventry.BarCode)
                    {
                        billInventries[i].Quantity++;
                        billDisplays[i].Quantity++;
                        billDisplays[i].SubTotal = Math.Round(billDisplays[i].SellingPrice * billDisplays[i].Quantity, 2);
                    }
                }
            }
            else
            {
                billInventries.Add(new BillInventry
                {
                    Quantity = 1,
                    BarCode = billInventry.BarCode,
                    BatchNo = billInventry.BatchNo,
                    BrandName = billInventry.BrandName,
                    Categories = billInventry.Categories,
                    Discount = billInventry.Discount,
                    GST = billInventry.Discount,
                    HSNCode = billInventry.HSNCode,
                    Id = billInventry.Id,
                    MRP = billInventry.MRP,
                    ProductName = billInventry.ProductName,
                    PurchasePrice = billInventry.PurchasePrice,
                    SellingPrice = billInventry.SellingPrice,
                    ShelfNo = billInventry.ShelfNo,
                    Vendor = billInventry.Vendor
                });
                billDisplays.Add(new BillDisplay
                {
                    Index = itemCount++,
                    HSNCode = billInventry.HSNCode,
                    ProductName = billInventry.ProductName,
                    MRP = billInventry.MRP,
                    SellingPrice = billInventry.SellingPrice,
                    Quantity = 1,
                    SubTotal = billInventry.SellingPrice
                });
            }
            
            bsBillingList.DataSource = new();
            bsBillingList.DataSource = billDisplays;
            dgvProductList.DataSource = bsBillingList;
            BillCalculation();
            cmbPartialSearch.Text = "";
        }

        private void BtnSaveBill_Click(object sender, EventArgs e)
        {
            SaveBillData();
        }

        private void SaveBillData()
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            if (billingContext.BillData.Count() > 0)
            {
                if(!string.IsNullOrWhiteSpace(txtBillNo.Text) && billingContext.BillData.Where(x => x.BillNo == int.Parse(txtBillNo.Text)).Any())
                {
                    BillNo = billingContext.BillData.Where(x => x.BillNo == int.Parse(txtBillNo.Text)).FirstOrDefault().BillNo;
                }
                else
                {
                    BillNo = billingContext.BillData.OrderByDescending(x => x.BillNo).FirstOrDefault().BillNo + 1;
                }
                
            }
            else
            {
                BillNo = 1;
            }
            
            if (!string.IsNullOrWhiteSpace(txtBillNo.Text) &&  BillNo == int.Parse(txtBillNo.Text))
            {
                List<BillData> bills = billingContext.BillData.Where(x => x.BillNo == int.Parse(txtBillNo.Text)).ToList();
                foreach(var billInventry in billInventries)
                {
                    if (string.IsNullOrWhiteSpace(billInventry.BarCode))
                    {
                        if(bills.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).Any())
                        {
                            var brow = bills.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).First();
                            int diff = billInventry.Quantity - brow.Quantity;
                            if (diff != 0)
                            {
                                if (billingContext.DailyTable.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).Any())
                                {
                                    var drow = billingContext.DailyTable.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).First();
                                    drow.Quantity += diff;
                                }
                                else
                                {
                                    DailyTable row = CreateDailyTableRow(billInventry);
                                    billingContext.DailyTable.Add(row);
                                    billingContext.SaveChanges();
                                }
                                if (billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).Any())
                                {
                                    var mrow = billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).First();
                                    mrow.Quantity += diff;
                                }
                                else
                                {
                                    MontlyTable row = CreateMonthlyTableRow(billInventry);
                                    billingContext.MontlyTable.Add(row);
                                    billingContext.SaveChanges();
                                }
                                brow.Quantity = billInventry.Quantity;
                                billingContext.SaveChanges(); 
                            }
                        }
                        else
                        {
                            BillData billData = CreateBillDataRow(billInventry, BillNo);
                            billingContext.BillData.Add(billData);
                            if (billingContext.DailyTable.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).Any())
                            {
                                var drow = billingContext.DailyTable.Where(x => string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).First();
                                drow.Quantity += billInventry.Quantity;
                            }
                            else
                            {
                                DailyTable row = CreateDailyTableRow(billInventry);
                                billingContext.DailyTable.Add(row);
                                billingContext.SaveChanges();
                            }
                            if (billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).Any())
                            {
                                var mrow = billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && string.IsNullOrWhiteSpace(x.BarCode) && x.ProductName == billInventry.ProductName).First();
                                mrow.Quantity += billInventry.Quantity;
                            }
                            else
                            {
                                MontlyTable row = CreateMonthlyTableRow(billInventry);
                                billingContext.MontlyTable.Add(row);
                                billingContext.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        if(bills.Where(x => x.BarCode == billInventry.BarCode).Any())
                        {
                            var brow = bills.Where(x => x.BarCode == billInventry.BarCode).First();
                            int diff = billInventry.Quantity - brow.Quantity;
                            if (diff != 0)
                            {
                                if (billingContext.BillInventry.Where(x => x.BarCode == billInventry.BarCode && x.ProductName == billInventry.ProductName).Any())
                                {
                                    var birow = billingContext.BillInventry.Where(x => x.BarCode == billInventry.BarCode && x.ProductName == billInventry.ProductName).First();
                                    birow.Quantity -= diff;
                                }
                                if (billingContext.DailyTable.Where(x => x.BarCode == billInventry.BarCode).Any())
                                {
                                    var drow = billingContext.DailyTable.Where(x => x.BarCode == billInventry.BarCode).First();
                                    drow.Quantity += diff;
                                }
                                else
                                {
                                    DailyTable row = CreateDailyTableRow(billInventry);
                                    billingContext.DailyTable.Add(row);
                                    billingContext.SaveChanges();
                                }
                                if (billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && x.BarCode == billInventry.BarCode).Any())
                                {
                                    var mrow = billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && x.BarCode == billInventry.BarCode).First();
                                    mrow.Quantity += diff;
                                }
                                else
                                {
                                    MontlyTable row = CreateMonthlyTableRow(billInventry);
                                    billingContext.MontlyTable.Add(row);
                                    billingContext.SaveChanges();
                                }
                                brow.Quantity = billInventry.Quantity;
                                billingContext.SaveChanges(); 
                            }
                        }
                        else
                        {
                            BillData billData = CreateBillDataRow(billInventry, BillNo);
                            billingContext.BillData.Add(billData);
                            if (billingContext.BillInventry.Where(x => x.BarCode == billInventry.BarCode && x.ProductName == billInventry.ProductName).Any())
                            {
                                var birow = billingContext.BillInventry.Where(x => x.BarCode == billInventry.BarCode && x.ProductName == billInventry.ProductName).First();
                                birow.Quantity -= billInventry.Quantity;
                            }
                            if (billingContext.DailyTable.Where(x => x.BarCode == billInventry.BarCode).Any())
                            {
                                var drow = billingContext.DailyTable.Where(x => x.BarCode == billInventry.BarCode).First();
                                drow.Quantity += billInventry.Quantity;
                            }
                            else
                            {
                                DailyTable row = CreateDailyTableRow(billInventry);
                                billingContext.DailyTable.Add(row);
                                billingContext.SaveChanges();
                            }
                            if (billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && x.BarCode == billInventry.BarCode).Any())
                            {
                                var mrow = billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0 && x.BarCode == billInventry.BarCode).First();
                                mrow.Quantity += billInventry.Quantity;
                            }
                            else
                            {
                                MontlyTable row = CreateMonthlyTableRow(billInventry);
                                billingContext.MontlyTable.Add(row);
                                billingContext.SaveChanges();
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var billInventry in billInventries)
                {
                    BillData billData = CreateBillDataRow(billInventry, BillNo);
                    billingContext.BillData.Add(billData);

                }

                txtBillNo.Text = BillNo.ToString();
                billingContext.SaveChanges();
                string message = "Do you want to Save Info To DB?";
                string title = "Save Window";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    UpdatePurchase();
                }
            }
            Saved = true;
        }

        private BillData CreateBillDataRow(BillInventry billInventry, int billNo)
        {
            return new BillData
            {
                BarCode = billInventry.BarCode,
                BillNo = billNo,
                BatchNo = billInventry.BatchNo,
                BrandName = billInventry.BrandName,
                Categories = billInventry.Categories,
                Discount = billInventry.Discount,
                GST = billInventry.GST,
                HSNCode = billInventry.HSNCode,
                MRP = billInventry.MRP,
                ProductName = billInventry.ProductName,
                PurchasePrice = billInventry.PurchasePrice,
                SellingPrice = billInventry.SellingPrice,
                ShelfNo = billInventry.ShelfNo,
                Vendor = billInventry.Vendor,
                Quantity = billInventry.Quantity
            };
        }

        private void BtnLoadBill_Click(object sender, EventArgs e)
        {
            billInventries = new();
            List<BillData> bills = billingContext.BillData.Where(x => x.BillNo == int.Parse(txtBillNo.Text)).ToList();
            foreach(BillData bill in bills)
            {
                BillInventry billInventry = new BillInventry
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
                    MRP = bill.MRP,
                    ProductName = bill.ProductName,
                    PurchasePrice = bill.PurchasePrice,
                    Quantity = bill.Quantity,
                    SellingPrice = bill.SellingPrice,
                    ShelfNo = bill.ShelfNo
                };
                billInventries.Add(billInventry);
            }
            billDisplays = new();
            itemCount = 1;
            foreach (BillInventry billInventry in billInventries)
            {
                BillDisplay bill = new BillDisplay
                {
                    Index = itemCount++,
                    HSNCode = billInventry.HSNCode,
                    MRP = billInventry.MRP,
                    ProductName = billInventry.ProductName,
                    Quantity = billInventry.Quantity,
                    SellingPrice = billInventry.SellingPrice,
                    SubTotal = billInventry.SellingPrice * billInventry.Quantity,
                };
                billDisplays.Add(bill);
            }
            bsBillingList.DataSource = new();
            bsBillingList.DataSource = billDisplays;
            dgvProductList.DataSource = bsBillingList;
            BillCalculation();
        }
    }
}
