using EntityFrameWork;
using EntityFrameWork.Domain;
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
        public BillingForm()
        {
            InitializeComponent();
            dgvProductList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgvProductList.Columns["Index"].ReadOnly = true;
            //dgvProductList.Columns["ProductName"].ReadOnly = true;
            //dgvProductList.Columns["HSNCode"].ReadOnly = true;
            //dgvProductList.Columns["MRP"].ReadOnly = true;
            //dgvProductList.Columns["SellingPrice"].ReadOnly = true;
            //dgvProductList.Columns["SubTotal"].ReadOnly = true;
        }
        public bool NewProduct { get; set; }
        readonly BillingContext billingContext = new();
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
                //dgvProductList.Rows[index].Cells[5].Value = billDisplays[index].Quantity++;
                //dgvProductList.Rows[index].Cells[6].Value = billDisplays[index].SubTotal;
                
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
            Print();
            UpdatePurchase();
        }

        private void UpdatePurchase()
        {
            DailyUpdates();
            //MontlyUpdates();
        }

        private void MontlyUpdates()
        {
            foreach (var billInventry in billInventries)
            {
                if (string.IsNullOrWhiteSpace(billInventry.BarCode))
                {
                    if (billingContext.MontlyTable.Where(x => x.Date.ToShortDateString() == DateTime.Today.ToShortDateString() && x.ProductName == billInventry.ProductName).Any())
                    {
                        var row = billingContext.DailyTable.Where(x => x.ProductName == billInventry.ProductName).First();
                        row.Quantity = row.Quantity + billInventry.Quantity;
                        billingContext.SaveChanges();
                    }
                    else
                    {
                        MontlyTable row = CreateMonthlyTableRow(billInventry);
                        billingContext.MontlyTable.Add(row);
                    }
                }
                else
                {
                    if (billingContext.MontlyTable.Where(x => x.BarCode == billInventry.BarCode && x.ProductName == billInventry.ProductName).Any())
                    {
                        var row = billingContext.MontlyTable.Where(x => x.ProductName == billInventry.ProductName).First();
                        row.Quantity = row.Quantity + billInventry.Quantity;
                        billingContext.SaveChanges();
                    }
                    else
                    {
                        MontlyTable row = CreateMonthlyTableRow(billInventry);
                        billingContext.MontlyTable.Add(row);
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
                    if (billingContext.DailyTable.Where(x => x.ProductName == billInventry.ProductName).Any())
                    {
                        var row = billingContext.DailyTable.Where(x => x.ProductName == billInventry.ProductName).First();
                        row.Quantity = row.Quantity + billInventry.Quantity;
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
            var paperSize = new PaperSize("Custom", 520, 2000);
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
            graphics.DrawString("Cash Receipts", font, new SolidBrush(System.Drawing.Color.Black), rect, format);
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
            graphics.DrawString("GST No: 29AANFH919FIZR", font, new SolidBrush(System.Drawing.Color.Black), rect, format);
            startY = startY + (int)(font.GetHeight() + 5);
            rect = new Rectangle(startX, startY, 283, (int)(font.GetHeight() + 5));
            graphics.DrawString("Customer Name: " + txtCustomerName.Text , font, new SolidBrush(System.Drawing.Color.Black), rect, format);
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

        private void cmbPartialSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            List<DailyTable> dailyTables = new List<DailyTable> { new DailyTable { ProductName = "sugar 1kg" }, new DailyTable { ProductName = "sugar 2kg" }, new DailyTable { ProductName = "sugar 5kg" } };
            cmbPartialSearch.Items.Clear();

        }
    }
}
