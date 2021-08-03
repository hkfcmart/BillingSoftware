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
        public Inventry()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            //using(sqlConnection = SqlDBOperations.OpenSQLConnections())
            //{
            //    adapt = new SqlDataAdapter("select * from ProductList where BarCode = '" + txtBarcode.Text + "'", sqlConnection);
            //    dt = new DataTable();
            //    adapt.Fill(dt);
            //    dgvProductList.DataSource = dt;
            //}
        }

        private void Inventry_Load(object sender, EventArgs e)
        {
            //using(sqlConnection = SqlDBOperations.OpenSQLConnections())
            //{
            //    adapt = new SqlDataAdapter("select * from ProductList", sqlConnection);
            //    dt = new DataTable();
            //    adapt.Fill(dt);
            //    dgvProductList.DataSource = dt;
            //}
        }
    }
}
