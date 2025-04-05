using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResturantManagmentSystem.View.Order
{
    public partial class frmOrderDetails : Form
    {
        public int SelectedTableId { get; private set; }
        public int SelectedWaiterId { get; private set; }

        public frmOrderDetails()
        {
            InitializeComponent();
            this.Load += FrmOrderDetails_Load;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FrmOrderDetails_Load(object sender, EventArgs e)
        {
            // Load available tables
            LoadAvailableTables();

            // Load waiters
            LoadWaiters();

            // Disable confirm button until selections are made
            btnConfirm.Enabled = false;

            // Add event handlers for combo box selections
            cmbTables.SelectedIndexChanged += SelectionChanged;
            cmbWaiters.SelectedIndexChanged += SelectionChanged;
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            // Check if both a table and waiter are selected
            if (cmbTables.SelectedIndex > 0 && cmbWaiters.SelectedIndex > 0)
            {
                btnConfirm.Enabled = true;
            }
            else
            {
                btnConfirm.Enabled = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Validate selections again
            if (cmbTables.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a table.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbWaiters.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a waiter.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Store selected IDs
            SelectedTableId = Convert.ToInt32(cmbTables.SelectedValue);
            SelectedWaiterId = Convert.ToInt32(cmbWaiters.SelectedValue);

            // Close with OK result
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Close with Cancel result
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Helper Methods

        private void LoadAvailableTables()
        {
            try
            {
                string query = "SELECT tableID, tableNumber, capacity FROM tables WHERE status = 'Available' ORDER BY tableNumber";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    DataTable dt = new DataTable();
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }

                    // Add an initial empty selection item
                    DataRow dr = dt.NewRow();
                    dr["tableID"] = 0;
                    dr["tableNumber"] = "-- Select Table --";
                    dr["capacity"] = 0;
                    dt.Rows.InsertAt(dr, 0);

                    // Bind to combo box
                    cmbTables.DisplayMember = "displayText";
                    cmbTables.ValueMember = "tableID";

                    // Create a new datatable with a display text column
                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("tableID", typeof(int));
                    displayTable.Columns.Add("displayText", typeof(string));

                    // Add the empty selection
                    displayTable.Rows.Add(0, "-- Select Table --");

                    // Add each table with formatted display text
                    foreach (DataRow row in dt.Rows)
                    {
                        if (Convert.ToInt32(row["tableID"]) != 0)
                        {
                            string displayText = $"Table {row["tableNumber"]} ({row["capacity"]} seats)";
                            displayTable.Rows.Add(row["tableID"], displayText);
                        }
                    }

                    cmbTables.DataSource = displayTable;
                    cmbTables.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tables: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWaiters()
        {
            try
            {
                string query = "SELECT staffID, firstName + ' ' + lastName AS fullName FROM staff WHERE position = 'Waiter' AND active = 1 ORDER BY fullName";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    DataTable dt = new DataTable();
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }

                    // Add an initial empty selection item
                    DataRow dr = dt.NewRow();
                    dr["staffID"] = 0;
                    dr["fullName"] = "-- Select Waiter --";
                    dt.Rows.InsertAt(dr, 0);

                    // Bind to combo box
                    cmbWaiters.DataSource = dt;
                    cmbWaiters.DisplayMember = "fullName";
                    cmbWaiters.ValueMember = "staffID";
                    cmbWaiters.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading waiters: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}