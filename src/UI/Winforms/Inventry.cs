using EntityFrameWork;
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
        SqlConnection sqlConnection;
        SqlDataAdapter adapt;
        DataTable dt;
        BillingContext billingContext = new BillingContext();
        public Inventry()
        {
            InitializeComponent();
            SqlInvetry.DataSource = billingContext.BillInventry.ToList();
            dgvProductList.DataSource = SqlInvetry;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void Inventry_Load(object sender, EventArgs e)
        {
           
        }

        private void TxtBarcode_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void LblBarcode_Click(object sender, EventArgs e)
        {

        }

        private void TxtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barCode = txtBarcode.Text;

                if (billingContext.BillInventry.Where(x => x.BarCode == barCode).Count() > 0)
                {
                    SqlInvetry.DataSource = billingContext.BillInventry.Where(x => x.BarCode == barCode).ToList();
                    dgvProductList.DataSource = SqlInvetry;
                }
                else
                {
                    this.Hide();
                    ProductRegistrationForm productRegistrationForm = new();
                    productRegistrationForm.ShowDialog();
                }
            }
        }
    }
}
