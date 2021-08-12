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
        }
        readonly BillingContext billingContext = new();
        List<BillInventry> billInventries = new();
        List<BillDisplay> billDisplays = new();
        int itemCount = 1;
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchBarCode();
        }
        private void SearchBarCode()
        {
            string barCode = txtBarcode.Text;
            if (billInventries.Count > 0 && billInventries.Where(x => x.BarCode == barCode).Any())
            {
                int index = billInventries.FindIndex(x => x.BarCode == barCode);
                billDisplays[index].Quantity++;
                billDisplays[index].SubTotal = billDisplays[index].SellingPrice * billDisplays[index].Quantity;
                dgvProductList.Rows[index].Cells[4].Value = billDisplays[index].Quantity++;
                dgvProductList.Rows[index].Cells[5].Value = Math.Round(billDisplays[index].SubTotal, 2);
            }
            else if (billingContext.BillInventry.Where(x => x.BarCode == barCode).Any())
            {
                List<BillInventry> inventries = billingContext.BillInventry.Where(x => x.BarCode == barCode).ToList();
                if (inventries.Count() > 1)
                {
                    cbxconflictItem.Items.Clear();
                    foreach (BillInventry inventry in inventries)
                        cbxconflictItem.Items.Add(inventry);
                }
                else
                {
                    BillInventry billInventry = billingContext.BillInventry.Where(x => x.BarCode == barCode).ToList().First();
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
            }
            else
            {
                MessageBox.Show("No Product with Barcode Found", "NO Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Hide();
                //ProductRegistrationForm productRegistrationForm = new(txtBarcode.Text);
                //productRegistrationForm.ShowDialog();
            }
            bsBillingList.DataSource = billDisplays;
            dgvProductList.DataSource = bsBillingList;
            txtBarcode.Text = "";
            BillCalculation();
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
            txtSubTotal.Text = subTotal.ToString();
            txtGST.Text = GST.ToString();
            txtBillAmount.Text = billAmount.ToString();
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBarCode();
            }
        }

        private void DgvProductList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            billDisplays[e.RowIndex].SubTotal = int.Parse(dgvProductList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())* billDisplays[e.RowIndex].SellingPrice;
            BillCalculation();
        }

        private void BtnPrintReciept_Click(object sender, EventArgs e)
        {
            Print();
        }
        public void Print()
        {
            var doc = new PrintDocument();
            var paperSize = new PaperSize("Custom", 520, 820);
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
            graphics.DrawString("TAX INVOICE", font, new SolidBrush(System.Drawing.Color.Black), rect, format);
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
            startY = startY + (int)(font.GetHeight() + 5);
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 10, System.Drawing.FontStyle.Bold);
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
            font = new Font(System.Drawing.FontFamily.GenericSansSerif, 8, System.Drawing.FontStyle.Regular);
            foreach (var item in billDisplays)
            {
                startX = 0;                
                format.Alignment = StringAlignment.Near;
                int NoOfLines = 1;                
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
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-".PadRight(80, '-'));
            sb.Append("Sub Total: ".PadLeft(13 + 5 + 6));
            sb.AppendLine(string.Format("{0:0.00}", txtSubTotal.Text));
            sb.Append("GST: ".PadLeft(13 + 5 + 6));
            sb.AppendLine(txtGST.Text);
            sb.AppendLine("=".PadRight(50, '='));

            sb.Append("Bill Total:".PadLeft(15 + 5 + 6));
            sb.AppendLine((txtBillAmount.Text).ToString());
            sb.AppendLine("=".PadRight(50, '='));
            sb.AppendLine("Thank You".PadLeft(23));
            //sb.AppendLine("-".PadRight(50, '-'));
            var printText = new PrintText(sb.ToString(), new Font(System.Drawing.FontFamily.GenericSansSerif, 8, System.Drawing.FontStyle.Regular));
            startX = 0;

            graphics.DrawString(printText.Text, new Font(System.Drawing.FontFamily.GenericSansSerif, 8, System.Drawing.FontStyle.Regular),
                                new SolidBrush(System.Drawing.Color.Black), startX, startY);
        }
    }
}
