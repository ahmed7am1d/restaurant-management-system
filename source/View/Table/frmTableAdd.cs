using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ResturantManagmentSystem.View.Table
{
    public partial class frmTableAdd : SampleAdd
    {
        public event EventHandler TableAdded;
        public int id = 0; // Used to determine if we're adding a new table or editing existing

        public frmTableAdd()
        {
            InitializeComponent();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a hashtable to store parameters
                Hashtable ht = new Hashtable();
                ht.Add("@tableNumber", txtNumber.Text);
                ht.Add("@capacity", int.Parse(txtCapacity.Text));
                ht.Add("@location", txtLocation.Text);
                ht.Add("@status", txtStatus.Text);
                ht.Add("@notes", txtNotes.Text);

                // Define the query based on whether we're adding or updating
                string query;
                if (id == 0)
                {
                    // For new tables - INSERT
                    query = "INSERT INTO tables (tableNumber, capacity, location, status, notes) " +
                            "VALUES (@tableNumber, @capacity, @location, @status, @notes)";
                }
                else
                {
                    // For existing tables - UPDATE
                    ht.Add("@tableID", id);
                    query = "UPDATE tables SET tableNumber = @tableNumber, capacity = @capacity, " +
                            "location = @location, status = @status, notes = @notes WHERE tableID = @tableID";
                }

                // Execute the SQL command
                int result = MainClass.SQL(query, ht);

                if (result > 0)
                {
                    MessageBox.Show("Table saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form fields
                    txtNumber.Clear();
                    txtCapacity.Clear();
                    txtLocation.Clear();
                    txtStatus.Clear();
                    txtNotes.Clear();
                    id = 0;

                    // Set focus back to table number
                    txtNumber.Focus();

                    // Trigger the event to notify that a table was added/updated
                    TableAdded?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving table: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Helper methods
        private void frmTableAdd_Load(object sender, EventArgs e)
        {
            // Focus on the name field when form loads
            txtNumber.Focus();

            // Update the form title based on the operation
            if (id == 0)
            {
                this.Text = "Add Table";
            }
            else
            {
                this.Text = "Edit Table";
            }
        }

        private void SaveTable()
        {

        }
        #endregion
    }
}
