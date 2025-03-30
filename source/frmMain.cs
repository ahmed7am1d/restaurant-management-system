using ResturantManagmentSystem.View.Category;
using ResturantManagmentSystem.View.Product;
using System.Windows.Forms;

namespace ResturantManagmentSystem
{

    public partial class frmMain : Form
    {
        // Create an instance of views form to be used later and not disposed
        private frmHome homeViewInstance;
        private frmCategoryView categoryViewInstance;
        private frmProductView _frmProductViewInstance;
        
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

        
        // When Product button gets clicked
        private void ProductButton_Clicked(object sender, System.EventArgs e)
        {
            // Use the instance if it's not null or disposed to avoid creating a new instance every time the button is clicked
            if (_frmProductViewInstance == null || _frmProductViewInstance.IsDisposed)
            {
                _frmProductViewInstance = new frmProductView();
            }

            AddControls(_frmProductViewInstance);
            //_frmProductViewInstance.GetData(); // Force refresh data
        }


        // When main form is loaded
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            lblUser.Text = MainClass.USER;
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
