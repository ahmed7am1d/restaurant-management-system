﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ResturantManagmentSystem.View.Category
{
    public partial class frmCategoryView : SampleView
    {
        public frmCategoryView()
        {
            InitializeComponent();
            this.Load += FrmCategoryView_Load;
        }

        // Method called when the Add button is clicked to open the Add form
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmCategoryAdd frm = new frmCategoryAdd();

            // Subscribe to the event CategoryAdded
            frm.CategoryAdded += (s, args) => GetData();

            frm.ShowDialog();
        }

        // Method called when typing in search bar
        // In frmCategoryView.cs
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

                // Create a query that filters categories by name
                string query = "SELECT catID, catName FROM category WHERE catName LIKE @searchTerm";
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
                MessageBox.Show("Error searching categories: " + ex.Message,
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Method called when clicking on the cell to edit/delete the category
        // Help for you barazan the columns names are as follows: catID, catName, dgvDel, dgvEdit
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the edit column
            if (e.ColumnIndex == dataGridView1.Columns["dgvEdit"].Index && e.RowIndex >= 0)
            {
                // Get the category ID
                int categoryId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["catID"].Value);

                // Open the edit form with the selected category data
                EditCategory(categoryId);
            }

            // Check if the clicked cell is in the delete column
            if (e.ColumnIndex == dataGridView1.Columns["dgvDel"].Index && e.RowIndex >= 0)
            {
                // Get the ID of the row that should be deleted
                int categoryId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["catID"].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this category?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the record
                    DeleteCategory(categoryId);

                    // Refresh the data
                    GetData();
                }
            }

            // Barazan: Implement here for the edit functionality
        }

        #region Helper Methods
        // Method used to get data from the database and display it in the DataGridView
        public void GetData()
        {
            try
            {
                string query = "SELECT catID, catName FROM category";
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

                // Simply set the DataSource
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void DeleteCategory(int categoryId)
        {
            try
            {
                using (SqlConnection con = MainClass.GetConnection())
                {
                    string query = "DELETE FROM category WHERE catID = @catID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@catID", categoryId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category: " + ex.Message,
                    "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditCategory(int categoryId)
        {
            try
            {
                // Create a query to get the category data
                string query = "SELECT * FROM category WHERE catID = @catID";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@catID", categoryId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create and configure the Category Add form
                                frmCategoryAdd frm = new frmCategoryAdd();

                                // Set the ID to indicate we're editing
                                frm.id = categoryId;

                                // Fill the form with the category data
                                frm.txtName.Text = reader["catName"].ToString();

                                // Subscribe to the CategoryAdded event
                                frm.CategoryAdded += (s, args) => GetData();

                                // Show the form
                                frm.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading category details: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Method used to load data when the form is fully loaded
        private void FrmCategoryView_Load(object sender, EventArgs e)
        {
            GetData(); // Call GetData when the form is fully loaded
        }
        #endregion

        // Barazan: Implement here for the edit functionality   
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmCategoryAdd frm = new frmCategoryAdd();
                frm.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.ShowDialog();
                GetData();
            }
            if (dataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DeleteCategory(Convert.ToInt32(dataGridView1.CurrentRow.Cells["dgvid"].Value));
                }
            }





        }
    }
}
