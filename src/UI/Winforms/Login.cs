using EntityFrameWork;
using EntityFrameWork.Domain;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Winforms
{
    public partial class Login : Form
    {
        readonly BillingContext billingContext = new();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //sqlConnection = SqlDBOperations.OpenSQLConnections();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != string.Empty || txtUserName.Text != string.Empty)
            {
                if (billingContext.UserDetails.Where(x => x.UserName == txtUserName.Text).Any())
                {
                    UserDetails userDetails = billingContext.UserDetails.Where(x => x.UserName == txtUserName.Text).First();
                    if (userDetails.Password == txtPassword.Text)
                    {
                        this.Hide();
                        BillingSoftware billingPage = new();
                        billingPage.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("username and password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //cmd = new SqlCommand("select * from LoginDetails where username='" + txtUserName.Text + "' and password='" + txtPassword.Text + "'", sqlConnection);
                //dr = cmd.ExecuteReader();
                //if (dr.Read())
                //{
                //    dr.Close();
                //    this.Hide();
                //    BillingSoftware billingPage = new();
                //    billingPage.ShowDialog();
                //}
                //else
                //{
                //    dr.Close();
                //    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationPage homePage = new();
            homePage.ShowDialog();
        }
    }
}
