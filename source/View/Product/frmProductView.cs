using System;
using System.Data;
using System.Data.SqlClient;

namespace ResturantManagmentSystem.View.Product
{
    public partial class frmProductView : ResturantManagmentSystem.SampleView
    {
        public frmProductView()
        {
            InitializeComponent();
            this.Load += FrmProductView_Load;
        }


        #region Helper Methods
        // Method used to get data from the database and display it in the DataGridView
        public void GetData()
        {
            try
            {
                string query = "SELECT pID, pName, pPrice, pDescription, c.catName FROM products p INNER JOIN category c ON p.catID = c.catID";
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

        private void FrmProductView_Load(object sender, EventArgs e)
        {
            GetData(); // Call GetData when the form is fully loaded
        }

        #endregion  
    }
}
