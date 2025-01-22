using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces
{
    public partial class CRMForm : Form
    {
        public CRMForm()
        {
            InitializeComponent();
        }

        private void CRMForm_Load(object sender, EventArgs e)
        {
            // Inițializarea componentei la încărcare (dacă este necesar)
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=Arrow;Initial Catalog=StudentInfo;Integrated Security=True;"; // Conexiune la baza de date

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (!string.IsNullOrEmpty(textBoxName.Text) && !string.IsNullOrEmpty(textBoxRegisterNum.Text))
                {
                    // Creare query pentru a adăuga o persoană nouă
                    string query = "INSERT INTO CRM (Name, RegisterNum, Gender, DOB, Address, Email, Mobile) " +
                                   "VALUES (@Name, @RegisterNum, @Gender, @DOB, @Address, @Email, @Mobile)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@RegisterNum", textBoxRegisterNum.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBoxGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DOB", dateTimePickerDOB.Value);
                    cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                    cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@Mobile", textBoxMobile.Text);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery(); // Execută interogarea
                        MessageBox.Show("Persoana a fost adăugată cu succes!");
                        ClearFormFields(); // Curăță câmpurile formularului
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Eroare: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Vă rugăm să completați toate câmpurile necesare.");
                }
            }
        }

        private void ClearFormFields()
        {
            // Curăță câmpurile formularului după adăugarea unui client
            textBoxName.Clear();
            textBoxRegisterNum.Clear();
            comboBoxGender.SelectedIndex = -1;
            dateTimePickerDOB.Value = DateTime.Now;
            textBoxAddress.Clear();
            textBoxEmail.Clear();
            textBoxMobile.Clear();
        }

        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
