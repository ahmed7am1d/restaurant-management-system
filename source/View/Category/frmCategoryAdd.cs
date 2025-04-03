using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResturantManagmentSystem.View.Category
{
    public partial class frmCategoryAdd: SampleAdd
    {
        public event EventHandler CategoryAdded;
        public int id = 0; // Used to determine if we're adding a new category or editing existing

        public frmCategoryAdd()
        {
            InitializeComponent();
        }

        private void frmCategoryAdd_Load(object sender, EventArgs e)
        {
            // Set the focus on the text box when the form is loaded
            txtName.Focus();
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter category name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            SaveCategory();
        }

        #region Helper Methods
        private void SaveCategory()
        {
            try
            {
                string query;
                if (id == 0)
                {
                    // For new records - INSERT
                    query = "INSERT INTO category (catName) VALUES (@catName)";
                }
                else
                {
                    // For existing records - UPDATE
                    query = "UPDATE category SET catName = @catName WHERE catID = @id";
                }

                // Create a fresh connection each time using the GetConnection method
                using (SqlConnection con = MainClass.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters
                        cmd.Parameters.AddWithValue("@catName", txtName.Text);
                        // Only add id parameter for UPDATE
                        if (id != 0)
                            cmd.Parameters.AddWithValue("@id", id);

                        // Execute the command
                        con.Open();
                        cmd.ExecuteNonQuery();

                        // Reset form
                        MessageBox.Show("Category saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtName.Clear();
                        id = 0;
                        txtName.Focus();

                        // Trigger the event to notify that a category was added 
                        CategoryAdded?.Invoke(this, EventArgs.Empty);
                    }
                    // Connection automatically closed by using block
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
