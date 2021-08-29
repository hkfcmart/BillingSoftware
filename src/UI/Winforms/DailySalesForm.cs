using EntityFrameWork;
using EntityFrameWork.Domain;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Winforms
{
    public partial class DailySalesForm : Form
    {
        readonly BillingContext billingContext = new();
        public DailySalesForm()
        {
            InitializeComponent();
            dgvDaliySalesData.DataSource = billingContext.DailyTable.ToList();
            FinalCalculation();
        }
        private void FinalCalculation()
        {
            Double MRP = 0;
            Double Purchased = 0;
            Double Sales = 0;
            Double savings = 0;
            Double Income = 0;
            foreach (DailyTable dailyTable in billingContext.DailyTable.ToList())
            {                
                MRP = MRP + dailyTable.MRP * dailyTable.Quantity;
                Purchased = Purchased + dailyTable.PurchasePrice * dailyTable.Quantity;
                Sales = Sales + dailyTable.SellingPrice * dailyTable.Quantity;
            }
            savings = MRP - Sales;
            Income = MRP - Purchased;
            txtMRP.Text = MRP.ToString();
            txtPurchased.Text = Purchased.ToString();
            txtSales.Text = Sales.ToString();
            txtSaving.Text = savings.ToString();
            txtIncome.Text = Income.ToString();
        }

        private void DailySalesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            BillingSoftware billingSoftware = new();
            billingSoftware.ShowDialog();
        }
    }
}
