using EntityFrameWork;
using EntityFrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Winforms
{
    public partial class BillingSoftware : Form
    {
        readonly BillingContext billingContext = new();
        public BillingSoftware()
        {
            InitializeComponent();
            List<BillInventry> bills = billingContext.BillInventry.Where(x => x.BarCode.Length == 8).ToList(); // && x.BarCode.StartsWith("0000")
            List<string> ourBarcode = billingContext.BillInventry.Where(x => x.BarCode.Length == 8 && x.BarCode.StartsWith("0000")).OrderBy(x => x.BarCode).Select(x => x.BarCode).ToList();
            foreach (string barcode in ourBarcode)
                cmbOurBarCode.Items.Add(barcode);
        }

        private void BtnInventry_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventry inventry = new Inventry();
            inventry.ShowDialog();
        }

        private void BillingSoftware_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login login = new();
            login.ShowDialog();
        }

        private void BtnGenerateBill_Click(object sender, EventArgs e)
        {
            this.Hide();
            BillingForm billingForm = new();
            billingForm.ShowDialog();
        }

        private void btnDailySalesReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            DailySalesForm dailySalesForm = new();
            dailySalesForm.ShowDialog();
        }
    }
}
