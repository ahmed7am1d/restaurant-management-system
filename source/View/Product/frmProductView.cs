using ResturantManagmentSystem.View.Category;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResturantManagmentSystem.View.Product
{
    public partial class frmProductView : SampleView
    {
        public frmProductView()
        {
            InitializeComponent();
            this.Load += FrmProductView_Load;
        }

        // Method called when the Add button is clicked to open the Add form
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductAdd frm = new frmProductAdd();

            // Subscribe to the event CategoryAdded
            frm.ProductAdded += (s, args) => GetData();

            frm.ShowDialog();
        }

        public override void searchBox_TextChanged(object sender, EventArgs e)
        {
            // Get the search term from the text box
            string searchTerm = txtSearch.Text.ToLower().Trim();

            try
            {
                // If the search term is empty, get all data
                if (string.IsNullOrEmpty(searchTerm))
                {
                    GetData();
                    return;
                }

                // Create a query that filters products by name or description
                string query = "SELECT p.pID, p.pName, p.pDescription, p.pPrice, c.catName " +
                       "FROM products p " +
                       "INNER JOIN category c ON p.catID = c.catID " +
                       "WHERE p.pName LIKE @searchTerm OR p.pDescription LIKE @searchTerm";

                DataTable dt = new DataTable();

                // Create a connection and execute the query
                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Use % wildcards for partial matching
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                // Update the DataGridView with the filtered results
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching products: " + ex.Message,
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the delete column
            if (e.ColumnIndex == dataGridView1.Columns["dgvDel"].Index && e.RowIndex >= 0)
            {
                // Get the product ID
                int productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["pID"].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this menu item?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Delete the product
                    DeleteProduct(productId);
                }
            }

            // Check if the clicked cell is in the edit column
            if (e.ColumnIndex == dataGridView1.Columns["dgvEdit"].Index && e.RowIndex >= 0)
            {
                // Get the product ID
                int productId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["pID"].Value);

                // Open the edit form with the selected product data
                EditProduct(productId);
            }
        }


        #region Helper Methods
        // Method used to get data from the database and display it in the DataGridView
        public void GetData()
        {
            try
            {
                // Using aliases for all columns and ordering them as needed
                string query = "SELECT p.pID, p.pName, p.pDescription, p.pPrice, c.catName " +
                               "FROM products p INNER JOIN category c ON p.catID = c.catID";
                DataTable dt = new DataTable();

                // Create a fresh connection each time using the GetConnection method
                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                // Set the DataSource
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message,
                              "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteProduct(int productId)
        {
            try
            {
                string query = "DELETE FROM products WHERE pID = @pID";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pID", productId);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Menu item deleted successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the data
                            GetData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting product: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditProduct(int productId)
        {
            try
            {
                // Create a query to get the product data
                string query = "SELECT * FROM products WHERE pID = @pID";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@pID", productId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Store the categoryId value
                                int categoryId = Convert.ToInt32(reader["catID"]);

                                // Create and configure the Product Add form
                                frmProductAdd frm = new frmProductAdd();

                                // Set the ID to indicate we're editing
                                frm.id = productId;

                                // Fill the form with the product data
                                frm.txtName.Text = reader["pName"].ToString();
                                frm.txtPrice.Text = reader["pPrice"].ToString();
                                frm.txtDescription.Text = reader["pDescription"].ToString();

                                // Subscribe to the ProductAdded event
                                frm.ProductAdded += (s, args) => GetData();

                                // Handle the Load event to set the category after categories are loaded
                                frm.Load += (s, args) => {
                                    // Set the selected category after the form has loaded its data
                                    frm.cmbCategory.SelectedValue = categoryId;
                                };

                                // Show the form
                                frm.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product details: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmProductView_Load(object sender, EventArgs e)
        {
            GetData(); // Call GetData when the form is fully loaded
        }

        #endregion  
    }
}
