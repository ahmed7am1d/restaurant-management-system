using ResturantManagmentSystem.View.Category;
using ResturantManagmentSystem.View.Kitchen;
using ResturantManagmentSystem.View.POS;
using ResturantManagmentSystem.View.Product;
using ResturantManagmentSystem.View.Staff;
using ResturantManagmentSystem.View.Table;
using System.Windows.Forms;

namespace ResturantManagmentSystem
{

    public partial class frmMain : Form
    {
        // Create an instance of views form to be used later and not disposed
        private frmHome homeViewInstance;
        private frmCategoryView categoryViewInstance;
        private frmProductView _frmProductViewInstance;
        private frmTableView _frmTableViewInstance;
        private frmStaffView _frmStaffViewInstance;
        private frmPOSView _frmPOSInstance;
        private frmKitchenView _frmKitchenInstance;

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
            _frmProductViewInstance.GetData(); // Force refresh data
        }

        // When Table button gets clicked
        private void TableButton_Clicked(object sender, System.EventArgs e)
        {
            // Use the instance if it's not null or disposed to avoid creating a new instance every time the button is clicked
            if (_frmTableViewInstance == null || _frmTableViewInstance.IsDisposed)
            {
                _frmTableViewInstance = new frmTableView();
            }

            AddControls(_frmTableViewInstance);
            _frmTableViewInstance.GetData(); // Force refresh data
        }

        // When Staff button gets clicked
        private void StaffButton_Clicked(object sender, System.EventArgs e)
        {
            // Use the instance if it's not null or disposed to avoid creating a new instance every time the button is clicked
            if (_frmStaffViewInstance == null || _frmStaffViewInstance.IsDisposed)
            {
                _frmStaffViewInstance = new frmStaffView();
            }

            AddControls(_frmStaffViewInstance);
            _frmStaffViewInstance.GetData(); // Force refresh data
        }

        // When POS button gets clicked
        private void POSButton_Clicked(object sender, System.EventArgs e)
        {
            // Use the instance if it's not null or disposed to avoid creating a new instance every time the button is clicked
            if (_frmPOSInstance == null || _frmPOSInstance.IsDisposed)
            {
                _frmPOSInstance = new frmPOSView();
            }

            AddControls(_frmPOSInstance);
            // _frmPOSInstance.GetData(); // Force refresh data
        }


        // When Kitchen button gets clicked
        private void KitchenButton_Clicked(object sender, System.EventArgs e)
        {
            // Use the instance if it's not null or disposed to avoid creating a new instance every time the button is clicked
            if (_frmKitchenInstance == null || _frmKitchenInstance.IsDisposed)
            {
                _frmKitchenInstance = new frmKitchenView();
            }

            AddControls(_frmKitchenInstance);
            //_frmPOSInstance.GetData(); // Force refresh data
        }

        // When main form is loaded
        private void frmMain_Load(object sender, System.EventArgs e)
        {
            lblUser.Text = MainClass.USER;

            if (homeViewInstance == null || homeViewInstance.IsDisposed)
            {
                homeViewInstance = new frmHome();
            }


            // Show home as main load
            AddControls(homeViewInstance);
        }

        // When main form is closed
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show confirmation dialog
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // If user clicks No, cancel the closing event
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

            else
            {
                Application.ExitThread();
            }
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
