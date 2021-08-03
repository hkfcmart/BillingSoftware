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
                if (billingContext.UserDetails.Where(x => x.UserName == txtUserName.Text).Count() > 0)
                {
                    MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    UserDetails userDetails = new UserDetails() { UserName = txtUserName.Text, Password = txtPassword.Text };
                    billingContext.UserDetails.Add(userDetails);
                    billingContext.SaveChanges();
                }
                               
                if (txtPassword.Text == txtConfirmPassword.Text)
                {

                    cmd = new SqlCommand("select * from LoginTable where username='" + txtUserName.Text + "'", sqlConnection);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into LoginTable values(@username,@password)", sqlConnection);
                        cmd.Parameters.AddWithValue("username", txtUserName.Text);
                        cmd.Parameters.AddWithValue("password", txtPassword.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            sqlConnection = SqlDBOperations.OpenSQLConnections();
        }
    }
}
