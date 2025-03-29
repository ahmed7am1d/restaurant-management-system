using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResturantManagmentSystem
{
    internal class MainClass
    {
        // Connection string 
        public static readonly string con_string = "Server=ALDOORI\\SQLEXPRESS;Database=RM;Trusted_Connection=True;";

        // Current logged-in user information
        private static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

        // Method to get a new connection object
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(con_string);
        }

        // Method to validate user login
        public static bool IsValidUser(string username, string password)
        {
            bool isValid = false;

            try
            {
                using (SqlConnection con = GetConnection())
                {
                    string query = "SELECT * FROM users WHERE username = @Username AND upass = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                isValid = true;
                                USER = dt.Rows[0]["uName"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isValid;
        }

        // Method to execute SQL commands with parameters
        public static int SQL(string query, Hashtable parameters)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        // Add all parameters from hashtable
                        foreach (DictionaryEntry item in parameters)
                        {
                            cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                        }

                        con.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing SQL: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        // Method to load data into a DataGridView
        public static void LoadData(string query, DataGridView gridView, ListBox columnList)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Map columns based on the ListBox items
                        for (int i = 0; i < columnList.Items.Count; i++)
                        {
                            string columnName = ((DataGridViewColumn)columnList.Items[i]).Name;
                            gridView.Columns[columnName].DataPropertyName = dt.Columns[i].ToString();
                        }

                        gridView.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
