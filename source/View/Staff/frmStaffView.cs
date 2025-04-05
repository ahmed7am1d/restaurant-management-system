using ResturantManagmentSystem.View.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ResturantManagmentSystem.View.Staff
{
    public partial class frmStaffView : ResturantManagmentSystem.SampleView
    {
        public frmStaffView()
        {
            InitializeComponent();
        }

        // Method called when the Add button is clicked to open the Add form
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaffAdd frm = new frmStaffAdd();

            // Subscribe to the event CategoryAdded
            frm.StaffAdded += (s, args) => GetData();

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

                // Create a query that filters staff by first name, last name, or position
                string query = "SELECT staffID, firstName, lastName, phone, email, position, salary, hireDate, active " +
                              "FROM staff " +
                              "WHERE firstName LIKE @searchTerm OR lastName LIKE @searchTerm OR position LIKE @searchTerm";

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
                MessageBox.Show("Error searching staff: " + ex.Message,
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the edit column
            if (e.ColumnIndex == dataGridView1.Columns["dgvEdit"].Index && e.RowIndex >= 0)
            {
                // Get the staff ID
                int staffId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["staffID"].Value);

                // Open the edit form with the selected staff data
                EditStaff(staffId);
            }

            // Check if the clicked cell is in the delete column
            if (e.ColumnIndex == dataGridView1.Columns["dgvDel"].Index && e.RowIndex >= 0)
            {
                // Get the staff ID
                int staffId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["staffID"].Value);

                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this staff member?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Delete the staff
                    DeleteStaff(staffId);
                }
            }
        }

        #region Helper Methods
        // Method used to get data from the database and display it in the DataGridView
        public void GetData()
        {
            try
            {
                string query = "SELECT staffID, firstName, lastName, phone, email, position, salary, hireDate, active FROM staff";
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
                MessageBox.Show("Error loading staff data: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteStaff(int staffId)
        {
            try
            {
                string query = "DELETE FROM staff WHERE staffID = @staffID";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@staffID", staffId);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Staff member deleted successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the data
                            GetData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting staff: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditStaff(int staffId)
        {
            try
            {
                // Create a query to get the staff data
                string query = "SELECT * FROM staff WHERE staffID = @staffID";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@staffID", staffId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Create and configure the Staff Add form
                                frmStaffAdd frm = new frmStaffAdd();

                                // Set the ID to indicate we're editing
                                frm.id = staffId;

                                // Fill the form with the staff data
                                frm.txtFirstName.Text = reader["firstName"].ToString();
                                frm.txtLastName.Text = reader["lastName"].ToString();
                                frm.txtPhone.Text = reader["phone"].ToString();
                                frm.txtEmail.Text = reader["email"].ToString();
                                frm.txtPosition.Text = reader["position"].ToString();
                                frm.txtSalary.Text = reader["salary"].ToString();
                                frm.dtpHireDate.Value = Convert.ToDateTime(reader["hireDate"]);
                                frm.chkActive.Checked = Convert.ToBoolean(reader["active"]);

                                // Subscribe to the StaffAdded event
                                frm.StaffAdded += (s, args) => GetData();

                                // Show the form
                                frm.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff details: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmStaffView_Load(object sender, EventArgs e)
        {
            GetData(); // Call GetData when the form is fully loaded
        }

        #endregion  

    }
}
