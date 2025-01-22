using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CRMApp
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=Arrow;Initial Catalog=CRMDatabase;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                if (ValidateInputs())
                {
                    try
                    {
                        string query = "INSERT INTO Users (Name, Email, Phone, Address) VALUES (@Name, @Email, @Phone, @Address)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Utilizator adăugat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearInputs();
                        }
                        else
                        {
                            MessageBox.Show("Adăugarea utilizatorului a eșuat.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Eroare SQL: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Toate câmpurile sunt obligatorii.", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                con.Close();
            }
        }

        private bool ValidateInputs()
        {
            return !string.IsNullOrWhiteSpace(txtName.Text) &&
                   !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                   !string.IsNullOrWhiteSpace(txtPhone.Text) &&
                   !string.IsNullOrWhiteSpace(txtAddress.Text);
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
