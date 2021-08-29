using EntityFrameWork;
using EntityFrameWork.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms
{
    public partial class Inventry : Form
    {
        BillingContext billingContext = new();
        public Inventry()
        {
            InitializeComponent();
            //SqlInvetry.DataSource = billingContext.BillInventry.ToList();
            dgvProductList.DataSource = billingContext.BillInventry.ToList();
        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBarCode();
            }
        }

        private void SearchBarCode()
        {
            string barCode = txtBarcode.Text.Trim();

            if (billingContext.BillInventry.Where(x => x.BarCode == barCode).Any())
            {
                //SqlInvetry.DataSource = billingContext.BillInventry.Where(x => x.BarCode == barCode).ToList();
                dgvProductList.DataSource = billingContext.BillInventry.Where(x => x.BarCode == barCode).ToList();
            }
            else
            {
                this.Hide();
                ProductRegistrationForm productRegistrationForm = new(txtBarcode.Text);
                productRegistrationForm.ShowDialog();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchBarCode();
        }

        private void Inventry_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            billingContext.SaveChanges();
            BillingSoftware billingSoftware = new();
            billingSoftware.ShowDialog();            
        }

        private void TxtProductName_KeyPress(object sender, KeyPressEventArgs e)
        {
            string searchTex = "";
            if (e.KeyChar == '\b')
                searchTex = txtProductName.Text.Substring(0, txtProductName.Text.Length - 1);
            else
                searchTex = txtProductName.Text + e.KeyChar;
            List<BillInventry> bills = billingContext.BillInventry.Where(x => x.ProductName.StartsWith(searchTex)).ToList();
            BillInventry billInventry = billingContext.BillInventry.Where(x => x.BarCode == "00001168").First();
            dgvProductList.DataSource = bills;
        }
    }
}
