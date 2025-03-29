using ResturantManagmentSystem.View;
using System.Windows.Forms;

namespace ResturantManagmentSystem
{

    public partial class frmMain : Form
    {
        // Create an instance of views form to be used later and not disposed
        private frmCategoryView categoryViewInstance;
        private frmHome homeViewInstance;

        public frmMain()
        {
            InitializeComponent();
        }

        // When Home button gets clicked
        private void HomeButton_Clicked(object sender, System.EventArgs e)
        {
            // Use the instance if it's not null or disposed to avoid creating a new instance every time the button is clicked
            if (homeViewInstance == null || homeViewInstance.IsDisposed)
            {
                homeViewInstance = new frmHome();
            }

            AddControls(homeViewInstance);
        }

        // When Category button gets clicked
        private void CategoryButton_Clicked(object sender, System.EventArgs e)
        {
            // Use the instance if it's not null or disposed to avoid creating a new instance every time the button is clicked
            if (categoryViewInstance == null || categoryViewInstance.IsDisposed)
            {
                categoryViewInstance = new frmCategoryView();
            }

            AddControls(categoryViewInstance);
            categoryViewInstance.GetData(); // Force refresh data
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }

        private void button1_Click(object sender, System.EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, System.EventArgs e)
        {

        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            lblUser.Text = MainClass.USER;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Helper Methods
        // A method used to open forms inside current panel
        public void AddControls(Form f)
        {
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;

            // Make sure the form adapts to the container
            f.AutoScroll = true;
            f.AutoSize = false;

            ControlPanel.Controls.Clear();
            ControlPanel.Controls.Add(f);

            // Ensure the form is properly sized
            f.Size = ControlPanel.ClientSize;

            f.Show();
        }

        #endregion
    }
}
