using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResturantManagmentSystem.View.Product
{
    public partial class frmProductAdd : SampleAdd
    {
        public event EventHandler ProductAdded;
        public int id = 0; // Used to determine if we're adding a new product or editing existing


        public frmProductAdd()
        {
            InitializeComponent();
            this.Load += frmProductAdd_Load;
        }


        public override void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter menu item name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (cmbCategory.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a category", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCategory.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }

            // Save the product
            SaveProduct();
        }


        #region Helper methods
        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            // Focus on the name field when form loads
            txtName.Focus();

            // Load categories into the combo box
            LoadCategories();
        }

        private void LoadCategories()
        {
            try
            {
                // Create the query to get all categories
                string query = "SELECT catID, catName FROM category ORDER BY catName";

                // Create a DataTable to hold the categories
                DataTable dt = new DataTable();

                // Execute the query and fill the DataTable
                using (SqlConnection con = MainClass.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }

                // Add a default selection item
                DataRow dr = dt.NewRow();
                dr["catID"] = 0;
                dr["catName"] = "-- Select Category --";
                dt.Rows.InsertAt(dr, 0);

                // Bind the DataTable to the ComboBox
                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "catName";
                cmbCategory.ValueMember = "catID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveProduct()
        {
            try
            {
                // Create a hashtable to store parameters
                Hashtable ht = new Hashtable();
                ht.Add("@pName", txtName.Text);
                ht.Add("@pPrice", decimal.Parse(txtPrice.Text));
                ht.Add("@pDescription", txtDescription.Text);
                ht.Add("@catID", cmbCategory.SelectedValue);

                // Define the query based on whether we're adding or updating
                string query;
                if (id == 0)
                {
                    // For new menu items - INSERT
                    query = "INSERT INTO products (pName, pPrice, pDescription, catID) " +
                            "VALUES (@pName, @pPrice, @pDescription, @catID)";
                }
                else
                {
                    // For existing menu items - UPDATE
                    ht.Add("@pID", id);
                    query = "UPDATE products SET pName = @pName, pPrice = @pPrice, " +
                            "pDescription = @pDescription, catID = @catID WHERE pID = @pID";
                }

                // Execute the SQL command
                int result = MainClass.SQL(query, ht);

                if (result > 0)
                {
                    MessageBox.Show("Menu item saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form fields
                    txtName.Clear();
                    txtPrice.Clear();
                    txtDescription.Clear();
                    cmbCategory.SelectedIndex = 0;
                    id = 0;

                    // Set focus back to name
                    txtName.Focus();

                    // Trigger the event to notify that a product was added/updated
                    ProductAdded?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving menu item: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion
}

