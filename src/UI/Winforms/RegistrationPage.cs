using EntityFrameWork;
using EntityFrameWork.Domain;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Winforms
{
    public partial class RegistrationPage : Form
    {
        SqlCommand cmd;
        SqlConnection sqlConnection;
        SqlDataReader dr;
        BillingContext billingContext = new BillingContext();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != string.Empty || txtPassword.Text != string.Empty || txtUserName.Text != string.Empty)
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    if (billingContext.UserDetails.Where(x => x.UserName == txtUserName.Text).Count() > 0)
                    {
                        MessageBox.Show("Username Already exist please Login ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Hide();
                        Login login = new Login();
                        login.ShowDialog();
                    }
                    else
                    {
                        UserDetails userDetails = new UserDetails() { UserName = txtUserName.Text, Password = txtPassword.Text };
                        billingContext.UserDetails.Add(userDetails);
                        billingContext.SaveChanges();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Login login = new Login();
                        login.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void HomePage_Load(object sender, EventArgs e)
        //{
        //    sqlConnection = SqlDBOperations.OpenSQLConnections();
        //}

        private void RegistrationPage_Load(object sender, EventArgs e)
        {
            //sqlConnection = SqlDBOperations.OpenSQLConnections();
        }
    }
}
