using ResturantManagmentSystem.View.Bill;
using ResturantManagmentSystem.View.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ResturantManagmentSystem.View.POS
{
    public partial class frmPOSView : Form
    {
        // Keep track of the total price for the current order
        private decimal totalOrderPrice = 0;

        public frmPOSView()
        {
            InitializeComponent();
            this.Load += FrmPOSView_Load;
        }

        private void FrmPOSView_Load(object sender, EventArgs e)
        {
            // Initialize the DataGridView
            InitializeDataGridView();

            // Load products from database
            LoadProducts();

            // Initialize total price
            UpdateTotalPrice();
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Make sure we're clicking a button cell
            if (e.RowIndex < 0) return;

            // Handle plus button click
            if (e.ColumnIndex == dgvOrders.Columns["btnPlus"].Index)
            {
                // Get current quantity and price
                int quantity = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["quantity"].Value);
                decimal price = Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells["unitPrice"].Value);

                // Increment quantity
                quantity++;
                dgvOrders.Rows[e.RowIndex].Cells["quantity"].Value = quantity;

                // Update subtotal
                dgvOrders.Rows[e.RowIndex].Cells["subtotal"].Value = price * quantity;

                // Update total price
                UpdateTotalPrice();
            }
            // Handle minus button click
            else if (e.ColumnIndex == dgvOrders.Columns["btnMinus"].Index)
            {
                // Get current quantity and price
                int quantity = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["quantity"].Value);
                decimal price = Convert.ToDecimal(dgvOrders.Rows[e.RowIndex].Cells["unitPrice"].Value);

                // Decrement quantity
                quantity--;

                if (quantity <= 0)
                {
                    // Remove the row if quantity becomes zero
                    dgvOrders.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    // Update quantity and subtotal
                    dgvOrders.Rows[e.RowIndex].Cells["quantity"].Value = quantity;
                    dgvOrders.Rows[e.RowIndex].Cells["subtotal"].Value = price * quantity;
                }

                // Update total price
                UpdateTotalPrice();
            }
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            // Get product information from button's Tag
            Button btn = (Button)sender;
            object[] productInfo = (object[])btn.Tag;

            int productId = (int)productInfo[0];
            string productName = (string)productInfo[1];
            decimal price = (decimal)productInfo[2];

            // Add product to the order grid
            AddProductToOrder(productId, productName, price);
        }

        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            ClearOrder();
        }

        private void btnMakeOrder_Click(object sender, EventArgs e)
        {
            // Check if there are any items in the order
            if (dgvOrders.Rows.Count == 0)
            {
                MessageBox.Show("Please add products to the order first.", "Empty Order",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Open the order details form to select table and waiter
            using (frmOrderDetails orderDetails = new frmOrderDetails())
            {
                if (orderDetails.ShowDialog() == DialogResult.OK)
                {
                    int tableId = orderDetails.SelectedTableId;
                    int waiterId = orderDetails.SelectedWaiterId;

                    // Save the order to the database
                    SaveOrder(tableId, waiterId);
                }
            }
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            // Open the bill list form
            using (frmBillList billList = new frmBillList())
            {
                billList.ShowDialog();
            }
        }

        #region Helper Methods
        private void InitializeDataGridView()
        {
            // Make sure the DataGridView has the proper columns only if it is empty and not already initialized in the designer
            if (dgvOrders.Columns.Count == 0)
            {
                // Add hidden column for product ID
                dgvOrders.Columns.Add("productID", "ID");
                dgvOrders.Columns["productID"].Visible = false;

                // Add visible columns
                dgvOrders.Columns.Add("productName", "Product name");
                dgvOrders.Columns.Add("unitPrice", "Unit Price");
                dgvOrders.Columns.Add("quantity", "Quantity");
                dgvOrders.Columns.Add("subtotal", "Subtotal");

                // Add increment/decrement buttons
                DataGridViewButtonColumn btnPlus = new DataGridViewButtonColumn();
                btnPlus.HeaderText = "+";
                btnPlus.Text = "+";
                btnPlus.DefaultCellStyle.BackColor = Color.LightGreen;
                btnPlus.Name = "btnPlus";
                btnPlus.UseColumnTextForButtonValue = true;
                dgvOrders.Columns.Add(btnPlus);

                DataGridViewButtonColumn btnMinus = new DataGridViewButtonColumn();
                btnMinus.HeaderText = "-";
                btnMinus.Text = "-";
                btnMinus.DefaultCellStyle.BackColor = Color.LightCoral;
                btnMinus.Name = "btnMinus";
                btnMinus.UseColumnTextForButtonValue = true;
                dgvOrders.Columns.Add(btnMinus);

                // Set up the event handler for cell clicks (for +/- buttons)
                dgvOrders.CellClick += DgvOrders_CellClick;
            }
        }

        private void LoadProducts()
        {
            try
            {
                // Clear existing products
                flpProducts.Controls.Clear();

                // Query to get all products
                string query = "SELECT pID, pName, pPrice FROM products ORDER BY pName";

                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int productId = Convert.ToInt32(reader["pID"]);
                                string productName = reader["pName"].ToString();
                                decimal price = Convert.ToDecimal(reader["pPrice"]);

                                // Create a button for each product
                                Button btnProduct = new Button();
                                btnProduct.Text = productName + Environment.NewLine + "$" + price.ToString("0.00");
                                btnProduct.Size = new Size(120, 80);
                                btnProduct.BackColor = Color.LightBlue;
                                btnProduct.Cursor = Cursors.Hand;
                                btnProduct.Tag = new object[] { productId, productName, price };

                                // Add click event to add product to order
                                btnProduct.Click += BtnProduct_Click;

                                // Add button to flow layout panel
                                flpProducts.Controls.Add(btnProduct);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTotalPrice()
        {
            totalOrderPrice = 0;

            // Sum all subtotals
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells["subtotal"].Value != null)
                {
                    totalOrderPrice += Convert.ToDecimal(row.Cells["subtotal"].Value);
                }
            }

            // Update the label
            lblTotalOrderPrice.Text = "$" + totalOrderPrice.ToString("0.00");
        }

        private void AddProductToOrder(int productId, string productName, decimal price)
        {
            // Check if the product is already in the order
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells["productID"].Value != null &&
                    Convert.ToInt32(row.Cells["productID"].Value) == productId)
                {
                    // Product already exists, increment quantity
                    int quantity = Convert.ToInt32(row.Cells["quantity"].Value) + 1;
                    row.Cells["quantity"].Value = quantity;

                    // Update subtotal
                    decimal subtotal = price * quantity;
                    row.Cells["subtotal"].Value = subtotal;

                    // Update total price
                    UpdateTotalPrice();
                    return;
                }
            }

            // Product not in order yet, add new row
            int rowIndex = dgvOrders.Rows.Add();
            DataGridViewRow newRow = dgvOrders.Rows[rowIndex];

            newRow.Cells["productID"].Value = productId;
            newRow.Cells["productName"].Value = productName;
            newRow.Cells["unitPrice"].Value = price;
            newRow.Cells["quantity"].Value = 1;
            newRow.Cells["subtotal"].Value = price;

            // Update total price
            UpdateTotalPrice();
        }

        private void SaveOrder(int tableId, int waiterId)
        {
            try
            {
                using (SqlConnection con = MainClass.GetConnection())
                {
                    con.Open();
                    // Use a transaction to ensure all operations succeed or fail together
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insert the order
                            string orderQuery = @"INSERT INTO orders (tableID, employeeID, orderDate, status, totalAmount)
                                                 VALUES (@tableID, @employeeID, GETDATE(), 'New', @totalAmount);
                                                 SELECT SCOPE_IDENTITY();";

                            int orderId;
                            using (SqlCommand cmd = new SqlCommand(orderQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@tableID", tableId);
                                cmd.Parameters.AddWithValue("@employeeID", waiterId);
                                cmd.Parameters.AddWithValue("@totalAmount", totalOrderPrice);

                                // Get the new order ID
                                orderId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // 2. Insert order items
                            string itemQuery = @"INSERT INTO orderItems (orderID, productID, quantity, unitPrice, subTotal)
                                               VALUES (@orderID, @productID, @quantity, @unitPrice, @subTotal)";

                            foreach (DataGridViewRow row in dgvOrders.Rows)
                            {
                                using (SqlCommand cmd = new SqlCommand(itemQuery, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@orderID", orderId);
                                    cmd.Parameters.AddWithValue("@productID", row.Cells["productID"].Value);
                                    cmd.Parameters.AddWithValue("@quantity", row.Cells["quantity"].Value);
                                    cmd.Parameters.AddWithValue("@unitPrice", row.Cells["unitPrice"].Value);
                                    cmd.Parameters.AddWithValue("@subTotal", row.Cells["subtotal"].Value);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 3. Update table status to Occupied
                            string updateTableQuery = "UPDATE tables SET status = 'Occupied' WHERE tableID = @tableID";
                            using (SqlCommand cmd = new SqlCommand(updateTableQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@tableID", tableId);
                                cmd.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();

                            MessageBox.Show("Order #" + orderId + " has been created successfully!",
                                           "Order Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear the order for a new one
                            ClearOrder();
                        }
                        catch (Exception ex)
                        {
                            // Rollback the transaction if anything failed
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving order: " + ex.Message, "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearOrder()
        {
            // Clear the orders grid
            dgvOrders.Rows.Clear();

            // Reset total price
            totalOrderPrice = 0;
            UpdateTotalPrice();
        }

        #endregion
    }
}
