using System.Windows.Forms;
using System;
using System.Data.SqlClient;
using System.Data;

namespace ResturantManagmentSystem.View.Table
{
    public partial class frmTableView : SampleView
    {
        public frmTableView()
        {
            InitializeComponent();
            this.Load += FrmTableView_Load;
        }

        // Method called when the Add button is clicked to open the Add form
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmTableAdd frm = new frmTableAdd();

            // Subscribe to the event CategoryAdded
            frm.TableAdded+= (s, args) => GetData();

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

                // Create a query that filters tables by table number, location, or status
                string query = "SELECT tableID, tableNumber, capacity, location, status, notes " +
                              "FROM tables " +
                              "WHERE tableNumber LIKE @searchTerm OR location LIKE @searchTerm OR status LIKE @searchTerm";

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
                MessageBox.Show("Error searching tables: " + ex.Message,
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the edit column
            if (e.ColumnIndex == dataGridView1.Columns["dgvEdit"].Index && e.RowIndex >= 0)
            {
                // Get the table ID
                int tableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["tableID"].Value);

                // Open the edit form with the selected table data
                EditTable(tableId);
            }

            // Check if the clicked cell is in the delete column
            if (e.ColumnIndex == dataGridView1.Columns["dgvDel"].Index && e.RowIndex >= 0)
            {
                // Get the table ID
                int tableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["tableID"].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this table?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Delete the table
                    DeleteTable(tableId);
                }
            }
        }


        #region Helper Methods
        // Method used to get data from the database and display it in the DataGridView
        public void GetData()
        {
            try
            {
                string query = "SELECT tableID, tableNumber, capacity, location, status, notes FROM tables";
                DataTable dt = new DataTable();

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteTable(int tableId)
        {
            try
            {
                string query = "DELETE FROM tables WHERE tableID = @tableID";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@tableID", tableId);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Table deleted successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the data
                            GetData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting table: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditTable(int tableId)
        {
            try
            {
                // Create a query to get the table data
                string query = "SELECT * FROM tables WHERE tableID = @tableID";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@tableID", tableId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create and configure the Table Add form
                                frmTableAdd frm = new frmTableAdd();

                                // Set the ID to indicate we're editing
                                frm.id = tableId;

                                // Fill the form with the table data
                                frm.txtNumber.Text = reader["tableNumber"].ToString();
                                frm.txtCapacity.Text = reader["capacity"].ToString();
                                frm.txtLocation.Text = reader["location"].ToString();
                                frm.txtStatus.Text = reader["status"].ToString();
                                frm.txtNotes.Text = reader["notes"].ToString();

                                // Subscribe to the TableAdded event
                                frm.TableAdded += (s, args) => GetData();

                                // Show the form
                                frm.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading table details: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmTableView_Load(object sender, EventArgs e)
        {
            GetData();
        }

        #endregion  
    }
}
