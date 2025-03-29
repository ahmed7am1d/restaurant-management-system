using System;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ResturantManagmentSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!MainClass.IsValidUser(txtUser.Text, txtPass.Text))
            {
                System.Windows.Forms.MessageBox.Show("Invalid username or password");
                return;
            }
            else
            {
                frmMain main = new frmMain();
                this.Hide();
                main.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
