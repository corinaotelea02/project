using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRMApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=Arrow;Initial Catalog=CRMDatabase;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {
                    this.Visible = false;
                    CRMHome homeForm = new CRMHome();
                    homeForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nume de utilizator sau parolă incorectă.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
