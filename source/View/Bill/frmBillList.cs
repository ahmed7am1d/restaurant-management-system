using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResturantManagmentSystem.View.Bill
{
    public partial class frmBillList : Form
    {
        public frmBillList()
        {
            InitializeComponent();
            this.Load += FrmBillList_Load;
        }

        private void FrmBillList_Load(object sender, EventArgs e)
        {
            // Set up the DataGridView with a "Mark as Paid" button for completed orders
            SetupDataGridView();

            // Set default selection to "All orders"
            chkAllOrders.Checked = true;

            // Load orders based on initial filter
            LoadOrders();

            // Add event handlers for the checkboxes
            chkCompletedOrders.CheckedChanged += FilterCheckBox_CheckedChanged;
            chkPaidOrders.CheckedChanged += FilterCheckBox_CheckedChanged;
            chkAllOrders.CheckedChanged += FilterCheckBox_CheckedChanged;
        }


        private void DgvBillOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure we're clicking the "Mark as Paid" button and it has a value (is not hidden)
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvBillOrders.Columns["btnMarkAsPaid"].Index)
            {
                // Get the button cell
                DataGridViewButtonCell buttonCell = dgvBillOrders.Rows[e.RowIndex].Cells["btnMarkAsPaid"] as DataGridViewButtonCell;

                // Only proceed if the button has a value (is visible)
                if (buttonCell != null && buttonCell.Value != null && buttonCell.Value.ToString() != "")
                {
                    // Get the order ID and status from the row
                    int orderId = Convert.ToInt32(dgvBillOrders.Rows[e.RowIndex].Cells["orderID"].Value);
                    string status = dgvBillOrders.Rows[e.RowIndex].Cells["status"].Value.ToString();

                    // Only "Completed" orders can be marked as "Paid"
                    if (status == "Completed")
                    {
                        // Ask for confirmation
                        DialogResult result = MessageBox.Show(
                            "Are you sure you want to mark Order #" + orderId + " as Paid?",
                            "Confirm Payment",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            // Update the order status in the database
                            MarkOrderAsPaid(orderId);
                        }
                    }
                }
            }
        }

        private void FilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Synchronize the checkboxes (only one can be checked at a time)
            CheckBox selectedCheckBox = (CheckBox)sender;

            if (selectedCheckBox.Checked)
            {
                // Uncheck other checkboxes
                if (selectedCheckBox == chkCompletedOrders)
                {
                    chkPaidOrders.Checked = false;
                    chkAllOrders.Checked = false;
                }
                else if (selectedCheckBox == chkPaidOrders)
                {
                    chkCompletedOrders.Checked = false;
                    chkAllOrders.Checked = false;
                }
                else if (selectedCheckBox == chkAllOrders)
                {
                    chkCompletedOrders.Checked = false;
                    chkPaidOrders.Checked = false;
                }

                // Load orders based on the selected filter
                LoadOrders();
            }
            else
            {
                // Ensure at least one checkbox is checked
                if (!chkCompletedOrders.Checked && !chkPaidOrders.Checked && !chkAllOrders.Checked)
                {
                    selectedCheckBox.Checked = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        #region Helper Methods
        private void SetupDataGridView()
        {
            // Add a button column for "Mark as Paid" action
            DataGridViewButtonColumn btnPaid = new DataGridViewButtonColumn();
            btnPaid.HeaderText = "Action";
            btnPaid.Text = "Mark as Paid";
            btnPaid.Name = "btnMarkAsPaid";
            btnPaid.UseColumnTextForButtonValue = true;

            // Add the button column to the grid
            dgvBillOrders.Columns.Add(btnPaid);

            // Set event handler for button clicks
            dgvBillOrders.CellClick += DgvBillOrders_CellClick;
        }

        private void MarkOrderAsPaid(int orderId)
        {
            try
            {
                string query = "UPDATE orders SET status = 'Paid' WHERE orderID = @orderID";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@orderID", orderId);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show(
                                "Order #" + orderId + " has been marked as Paid.",
                                "Payment Complete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            // Reload orders to reflect the change
                            LoadOrders();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error marking order as paid: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private string BuildOrderQuery()
        {
            // Base query with joins to get table number and formatted date
            string baseQuery = @"
                SELECT o.orderID, t.tableNumber as tableName, 
                       o.orderDate, o.status, o.totalAmount as total
                FROM orders o
                INNER JOIN tables t ON o.tableID = t.tableID";

            // Add WHERE clause based on the selected filter
            if (chkCompletedOrders.Checked)
            {
                return baseQuery + " WHERE o.status = 'Completed' ORDER BY o.orderDate DESC";
            }
            else if (chkPaidOrders.Checked)
            {
                return baseQuery + " WHERE o.status = 'Paid' ORDER BY o.orderDate DESC";
            }
            else // All orders
            {
                return baseQuery + " ORDER BY o.orderDate DESC";
            }
        }

        private void FormatDataGridView()
        {
            // Format the date column to show only date and time (no seconds)
            dgvBillOrders.Columns["orderDate"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";

            // Format the total column to show as currency
            dgvBillOrders.Columns["total"].DefaultCellStyle.Format = "C2";
            dgvBillOrders.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Handle the "Mark as Paid" button visibility
            foreach (DataGridViewRow row in dgvBillOrders.Rows)
            {
                if (row.Cells["status"].Value.ToString() != "Completed")
                {
                    // For non-completed orders, disable the button and make it invisible
                    DataGridViewButtonCell buttonCell = row.Cells["btnMarkAsPaid"] as DataGridViewButtonCell;
                    if (buttonCell != null)
                    {
                        // This will make the button cell appear empty
                        buttonCell.FlatStyle = FlatStyle.Flat;
                        buttonCell.Value = "";
                        // Make the background match the grid background for proper hiding
                        row.Cells["btnMarkAsPaid"].Style.BackColor = dgvBillOrders.BackgroundColor;
                        row.Cells["btnMarkAsPaid"].Style.ForeColor = dgvBillOrders.BackgroundColor;
                    }
                }
            }
        }

        private void LoadOrders()
        {
            try
            {
                string query = BuildOrderQuery();
                DataTable dt = new DataTable();

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                // If there are results, bind them to the grid
                dgvBillOrders.DataSource = dt;

                // Format the DataGridView for better UI
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading orders: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        #endregion
    }
}

