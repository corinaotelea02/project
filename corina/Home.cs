using System;
using System.Windows.Forms;

namespace CRMApp
{
    public partial class CRMHome : Form
    {
        public CRMHome()
        {
            InitializeComponent();
        }

        private void CRMHome_Load(object sender, EventArgs e)
        {

        }

        private void manageClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClients manageClientsForm = new ManageClients();
            manageClientsForm.ShowDialog();
        }

        private void salesReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReports salesReportsForm = new SalesReports();
            salesReportsForm.ShowDialog();
        }

        private void addNewClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClient addClientForm = new AddClient();
            addClientForm.ShowDialog();
        }

        private void removeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveClient removeClientForm = new RemoveClient();
            removeClientForm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CRMApp - Sistem de Management al Clienților\nVersiunea 1.0\n© 2025 CRM Solutions", "Despre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sigur doriți să vă delogați?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
