using EntityFrameWork;
using EntityFrameWork.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
                dgvProductList.Rows[index].Cells[5].Value = Decimal.Round(billDisplays[index].SubTotal, 2);
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
            Decimal totalAmount = 0;
            Decimal GST = 0;
            Decimal billAmount = 0;
            Decimal savings = 0;
            Decimal subTotal = 0;
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
            billDisplays[e.RowIndex].SubTotal = int.Parse(dgvProductList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) * billDisplays[e.RowIndex].SellingPrice;
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
            //doc.DefaultPageSettings.PaperSize.Kind = PaperKind.Custom;
            //doc.DefaultPageSettings.PaperSize.Height = 820;
            //doc.DefaultPageSettings.PaperSize.Width = 520;
            doc.PrintPage += new PrintPageEventHandler(ProvideContent);
            //var pd = new PrintDialog();
            //pd.ShowDialog();
            doc.Print();
        }

        public void ProvideContent(object sender, PrintPageEventArgs e)
        {

            
            const int FIRST_COL_PAD = 5;
            const int SECOND_COL_PAD = 7;
            const int THIRD_COL_PAD = 8;


            var sb = new StringBuilder();
            //var business = new Business();
            //replace with item.Branch
            //sb.AppendLine((business.BusinessName));
            //sb.AppendLine(" ");
            sb.AppendLine(("TAX INVOICE").PadLeft(24));
            //sb.AppendLine(" ");
            sb.AppendLine(("HKFC MART").PadLeft(23));
            //sb.AppendLine(("Vat Reg. No.:  "));
            sb.AppendLine(("GST No: 0204355610 & 0204355608 "));
            sb.AppendLine(" ");
            sb.Append(("DATE").PadRight(8));
            sb.AppendLine(": " + DateTime.Now);
            sb.Append(("Customer Name").PadRight(8));
            sb.AppendLine((": " + txtCustomerName.Text));
            sb.AppendLine(" ");
            //sb.AppendLine("=".PadRight(35, '='));
            sb.Append(("Index")); //.PadLeft(15) 
            sb.Append(("ProductName".PadLeft(7)));
            sb.Append(("HSNCode").PadLeft(2));
            sb.Append(("MRP").PadLeft(2));
            sb.Append(("SellingPrice").PadLeft(2));
            sb.Append(("Quantity").PadLeft(2));
            sb.AppendLine(("SubTotal").PadLeft(2));
            sb.AppendLine("-".PadRight(60, '-'));


            foreach (var item in billDisplays)
            {
                string pd = "";
                if (item.ProductName.Length > 15)
                {
                    pd = item.ProductName.Substring(0, 15);
                }
                else
                {
                    pd = item.ProductName;
                }
                sb.Append(item.Index);
                sb.Append(item.ProductName);
                sb.Append(item.HSNCode);
                sb.Append(item.MRP);
                sb.Append(item.SellingPrice);
                sb.Append(item.Quantity);
                sb.AppendLine(item.SubTotal.ToString());
            }
            sb.AppendLine("-".PadRight(60, '-'));
            sb.Append("Sub Total: ".PadLeft(13 + FIRST_COL_PAD + SECOND_COL_PAD));
            sb.AppendLine(string.Format("{0:0.00}", txtSubTotal.Text));
            sb.Append("GST: ".PadLeft(13 + FIRST_COL_PAD + SECOND_COL_PAD));
            sb.AppendLine(txtGST.Text);
            sb.AppendLine("=".PadRight(50, '='));

            sb.Append("Bill Total:".PadLeft(15 + FIRST_COL_PAD + SECOND_COL_PAD));
            sb.AppendLine((txtBillAmount.Text).ToString());
            sb.AppendLine("=".PadRight(50, '='));
            sb.AppendLine("Thank You".PadLeft(23));
            //sb.AppendLine("-".PadRight(50, '-'));
            var printText = new PrintText(sb.ToString(), new Font(System.Drawing.FontFamily.GenericMonospace, 7, System.Drawing.FontStyle.Bold));
            Graphics graphics = e.Graphics;
            int startX = 0;
            int startY = 0;
            int Offset = 0;

            graphics.DrawString(printText.Text, new Font(System.Drawing.FontFamily.GenericMonospace, 7, System.Drawing.FontStyle.Bold),
                                new SolidBrush(System.Drawing.Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
        }
    }
}
