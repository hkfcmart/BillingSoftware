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
    public partial class Login : Form
    {
        SqlCommand cmd;
        SqlConnection sqlConnection;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            sqlConnection = SqlDBOperations.OpenSQLConnections();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != string.Empty || txtUserName.Text != string.Empty)
            {

                cmd = new SqlCommand("select * from LoginDetails where username='" + txtUserName.Text + "' and password='" + txtPassword.Text + "'", sqlConnection);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    BillingSoftware billingPage = new();
                    billingPage.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationPage homePage = new RegistrationPage();
            homePage.ShowDialog();
        }
    }
}
