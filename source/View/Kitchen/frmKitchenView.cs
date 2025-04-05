using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ResturantManagmentSystem.View.Kitchen
{
    public partial class frmKitchenView : Form
    {
        private Timer refreshTimer;

        public frmKitchenView()
        {
            InitializeComponent();
            this.Load += FrmKitchenView_Load;
        }

        private void FrmKitchenView_Load(object sender, EventArgs e)
        {
            // Load orders that need to be prepared (status = 'New')
            LoadOrders();

            // Set up a timer to refresh orders automatically every 30 seconds
            refreshTimer = new Timer();
            refreshTimer.Interval = 30000; // 30 seconds
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void FrmKitchenView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the timer when form is closing
            if (refreshTimer != null)
            {
                refreshTimer.Stop();
                refreshTimer.Dispose();
            }
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int orderId = (int)btn.Tag;

            // Ask for confirmation
            DialogResult result = MessageBox.Show(
                $"Mark Order #{orderId} as Completed?",
                "Confirm Order Completion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Update order status to 'Completed'
                    string updateQuery = "UPDATE orders SET status = 'Completed' WHERE orderID = @orderID";

                    using (SqlConnection con = MainClass.GetConnection())
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@orderID", orderId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show(
                                    $"Order #{orderId} has been marked as Completed.",
                                    "Order Status Updated",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                                // Reload orders to remove the completed one
                                LoadOrders();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error updating order status: " + ex.Message,
                        "Database Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            // Reload orders to check for new ones
            LoadOrders();
        }

        #region Helper Methods

        private void LoadOrders()
        {
            try
            {
                // Clear existing order panels
                flpOrders.Controls.Clear();

                // Get all orders with 'New' status
                string orderQuery = @"
                    SELECT o.orderID, t.tableNumber, 
                           CONCAT(s.firstName, ' ', s.lastName) AS waiterName, 
                           o.orderDate, o.totalAmount
                    FROM orders o
                    JOIN tables t ON o.tableID = t.tableID
                    JOIN staff s ON o.employeeID = s.staffID
                    WHERE o.status = 'New'
                    ORDER BY o.orderDate ASC";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(orderQuery, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int orderId = reader.GetInt32(reader.GetOrdinal("orderID"));
                                string tableNumber = reader["tableNumber"].ToString();
                                string waiterName = reader["waiterName"].ToString();
                                DateTime orderDate = reader.GetDateTime(reader.GetOrdinal("orderDate"));
                                decimal totalAmount = reader.GetDecimal(reader.GetOrdinal("totalAmount"));

                                // Get order items for this order
                                List<OrderItem> orderItems = GetOrderItems(orderId);

                                // Create and add order panel to the flow layout
                                CreateOrderPanel(orderId, tableNumber, waiterName, orderDate, totalAmount, orderItems);
                            }
                        }
                    }
                }

                // Show a message if no orders need to be prepared
                if (flpOrders.Controls.Count == 0)
                {
                    Label lblNoOrders = new Label();
                    lblNoOrders.Text = "No new orders to prepare.";
                    lblNoOrders.AutoSize = true;
                    lblNoOrders.Font = new Font(lblNoOrders.Font.FontFamily, 14, FontStyle.Bold);
                    lblNoOrders.Padding = new Padding(20);
                    flpOrders.Controls.Add(lblNoOrders);
                }
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

        private List<OrderItem> GetOrderItems(int orderId)
        {
            List<OrderItem> items = new List<OrderItem>();

            try
            {
                string itemQuery = @"
                    SELECT oi.orderItemID, p.pName, oi.quantity, oi.notes
                    FROM orderItems oi
                    JOIN products p ON oi.productID = p.pID
                    WHERE oi.orderID = @orderID
                    ORDER BY oi.orderItemID";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(itemQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@orderID", orderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderItem item = new OrderItem
                                {
                                    OrderItemId = reader.GetInt32(reader.GetOrdinal("orderItemID")),
                                    ProductName = reader["pName"].ToString(),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
                                    Notes = reader["notes"] != DBNull.Value ? reader["notes"].ToString() : ""
                                };
                                items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading order items: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return items;
        }

        private void CreateOrderPanel(int orderId, string tableNumber, string waiterName, DateTime orderDate, decimal totalAmount, List<OrderItem> items)
        {
            // Create a panel for this order
            Panel orderPanel = new Panel();
            orderPanel.BackColor = Color.White;
            orderPanel.BorderStyle = BorderStyle.FixedSingle;
            orderPanel.Width = 250;
            orderPanel.Height = 350;
            orderPanel.Margin = new Padding(10);
            orderPanel.Tag = orderId;

            // Order header section
            Panel headerPanel = new Panel();
            headerPanel.BackColor = Color.Indigo;
            headerPanel.Height = 120;
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Padding = new Padding(5);

            // Add header labels (unchanged)
            Label lblOrderNumber = new Label();
            lblOrderNumber.Text = $"Bill No : {orderId}";
            lblOrderNumber.ForeColor = Color.White;
            lblOrderNumber.Font = new Font(lblOrderNumber.Font.FontFamily, 10, FontStyle.Bold);
            lblOrderNumber.AutoSize = true;
            lblOrderNumber.Location = new Point(5, 5);

            Label lblTable = new Label();
            lblTable.Text = $"Table : {tableNumber}";
            lblTable.ForeColor = Color.White;
            lblTable.Font = new Font(lblTable.Font.FontFamily, 10, FontStyle.Regular);
            lblTable.AutoSize = true;
            lblTable.Location = new Point(5, 25);

            Label lblWaiter = new Label();
            lblWaiter.Text = $"Waiter : {waiterName}";
            lblWaiter.ForeColor = Color.White;
            lblWaiter.Font = new Font(lblWaiter.Font.FontFamily, 10, FontStyle.Regular);
            lblWaiter.AutoSize = true;
            lblWaiter.Location = new Point(5, 45);

            Label lblTime = new Label();
            lblTime.Text = $"Bill Timing : {orderDate.ToString("hh:mm tt")}";
            lblTime.ForeColor = Color.White;
            lblTime.Font = new Font(lblTime.Font.FontFamily, 10, FontStyle.Regular);
            lblTime.AutoSize = true;
            lblTime.Location = new Point(5, 65);

            Label lblType = new Label();
            lblType.Text = "Bill Type : Dine In";
            lblType.ForeColor = Color.White;
            lblType.Font = new Font(lblType.Font.FontFamily, 10, FontStyle.Regular);
            lblType.AutoSize = true;
            lblType.Location = new Point(5, 85);


            // ... add the other header labels ...

            // Button at the bottom
            Button btnComplete = new Button();
            btnComplete.Text = "Complete";
            btnComplete.BackColor = Color.Green;
            btnComplete.ForeColor = Color.White;
            btnComplete.Height = 40;
            btnComplete.Dock = DockStyle.Bottom;
            btnComplete.FlatStyle = FlatStyle.Flat;
            btnComplete.FlatAppearance.BorderSize = 0;
            btnComplete.Tag = orderId;
            btnComplete.Click += BtnComplete_Click;

            // Add the header panel
            orderPanel.Controls.Add(headerPanel);
            headerPanel.Controls.Add(lblOrderNumber);
            headerPanel.Controls.Add(lblTable);
            headerPanel.Controls.Add(lblWaiter);
            headerPanel.Controls.Add(lblTime);
            headerPanel.Controls.Add(lblType);

            // Add the button
            orderPanel.Controls.Add(btnComplete);

            // Add items directly to the order panel
            int yPos = headerPanel.Height + 10; // Start below the header
            foreach (OrderItem item in items)
            {
                Label lblItem = new Label();
                lblItem.Text = $"{item.ProductName} × {item.Quantity}";
                lblItem.ForeColor = Color.Black;
                lblItem.Font = new Font(lblItem.Font.FontFamily, 9, FontStyle.Regular);
                lblItem.AutoSize = true;
                lblItem.Location = new Point(10, yPos);
                orderPanel.Controls.Add(lblItem);
                yPos += 25;
            }

            // Add the order panel to the flow layout
            flpOrders.Controls.Add(orderPanel);
        }

        #endregion

        #region Helper classes

        // Helper class to store order item details
        private class OrderItem
        {
            public int OrderItemId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public string Notes { get; set; }
        }

        #endregion

    }
}