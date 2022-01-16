using EntityFrameWork;
using EntityFrameWork.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            dgvDaliySalesData.DataSource = billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, DateTime.Today) == 0 && DbF.DateDiffMonth(x.Date, DateTime.Today) == 0 && DbF.DateDiffDay(x.Date, DateTime.Today) == 0).ToList();
            List<String> dates = billingContext.MontlyTable.Select(x => x.Date.ToShortDateString()).ToList().Distinct().ToList();
            foreach (string dateTime in dates)
            {
                cmbDate.Items.Add(dateTime);
            }
            FinalCalculation(DateTime.Today);
        }
        private void FinalCalculation(DateTime dateTime)
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            Double MRP = 0;
            Double Purchased = 0;
            Double Sales = 0;
            Double savings = 0;
            Double Income = 0;
            Double GST0 = 0;
            Double GST5 = 0;
            Double GST12 = 0;
            Double GST18 = 0;
            Double GST28 = 0;
            Double GST40 = 0;
            Double TotalGST = 0;

            foreach (MontlyTable montlyTable in billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, dateTime) == 0 && DbF.DateDiffMonth(x.Date, dateTime) == 0 && DbF.DateDiffDay(x.Date, dateTime) == 0).ToList())
            {
                MRP += montlyTable.MRP * montlyTable.Quantity;
                Purchased += montlyTable.PurchasePrice * montlyTable.Quantity;
                Sales += montlyTable.SellingPrice * montlyTable.Quantity;
                if (montlyTable.GST == 0.40)
                {
                    GST40 += montlyTable.PurchasePrice * montlyTable.Quantity;
                    TotalGST += montlyTable.PurchasePrice * montlyTable.Quantity * .4;
                }
                else if (montlyTable.GST == 0.28)
                {
                    GST28 += montlyTable.PurchasePrice * montlyTable.Quantity;
                    TotalGST += montlyTable.PurchasePrice * montlyTable.Quantity * .18;
                }
                else if (montlyTable.GST == 0.18)
                {
                    GST18 += montlyTable.PurchasePrice * montlyTable.Quantity;
                    TotalGST += montlyTable.PurchasePrice * montlyTable.Quantity * .18;
                }
                else if (montlyTable.GST == 0.12)
                {
                    GST12 += montlyTable.PurchasePrice * montlyTable.Quantity;
                    TotalGST += montlyTable.PurchasePrice * montlyTable.Quantity * .12;
                }
                else if (montlyTable.GST == 0.05)
                {
                    GST5 += montlyTable.PurchasePrice * montlyTable.Quantity;
                    TotalGST += montlyTable.PurchasePrice * montlyTable.Quantity * .05;
                }
                else
                {
                    GST0 += montlyTable.PurchasePrice * montlyTable.Quantity;
                }
                savings = MRP - Sales;
                Income = MRP - Purchased;
            }            
            txtMRP.Text = MRP.ToString();
            txtPurchased.Text = Purchased.ToString();
            txtSales.Text = Sales.ToString();
            txtSaving.Text = savings.ToString();
            txtIncome.Text = Income.ToString();
            txtGST0.Text = GST0.ToString();
            txtGST5.Text = GST5.ToString();
            txtGST12.Text = GST12.ToString();
            txtGST18.Text = GST18.ToString();
            txtGST28.Text = GST28.ToString();
            txtGST40.Text = GST40.ToString();
            txtWithOutGST.Text = (Sales - TotalGST).ToString();
            txtGST.Text = TotalGST.ToString();
            txtTotalGST.Text = TotalGST.ToString();
            txtTotalSales.Text = Sales.ToString();

        }

        private void DailySalesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            BillingSoftware billingSoftware = new();
            billingSoftware.ShowDialog();
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            DateTime date = Convert.ToDateTime(((System.Windows.Forms.ComboBox)sender).SelectedItem.ToString().Trim());
            dgvDaliySalesData.DataSource = new();
            dgvDaliySalesData.DataSource = billingContext.MontlyTable.Where(x => DbF.DateDiffYear(x.Date, date) == 0 && DbF.DateDiffMonth(x.Date, date) == 0 && DbF.DateDiffDay(x.Date, date) == 0).ToList();
            FinalCalculation(date);
        }
    }
}
