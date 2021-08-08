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
    public partial class BillingSoftware : Form
    {
        public BillingSoftware()
        {
            InitializeComponent();
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
    }
}
