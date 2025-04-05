using System;
using System.Collections;
using System.Windows.Forms;


namespace ResturantManagmentSystem.View.Staff
{
    public partial class frmStaffAdd : SampleAdd
    {
        public event EventHandler StaffAdded;
        public int id = 0; // Used to determine if we're adding a new staff or editing existing

        public frmStaffAdd()
        {
            InitializeComponent();
            this.Load += frmStaffAdd_Load;
        }

        public override void btnSave_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("Please enter first name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Please enter last name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPosition.Text))
            {
                MessageBox.Show("Please enter position", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPosition.Focus();
                return;
            }

            decimal salary;
            if (!string.IsNullOrEmpty(txtSalary.Text) && !decimal.TryParse(txtSalary.Text, out salary))
            {
                MessageBox.Show("Please enter a valid salary", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSalary.Focus();
                return;
            }

            // Save the staff member
            SaveStaff();
        }


        #region Helper methods
        private void frmStaffAdd_Load(object sender, EventArgs e)
        {
            // Focus on the first name field when form loads
            txtFirstName.Focus();

            // Set default values for new entries
            if (id == 0)
            {
                // Set today's date for hire date
                dtpHireDate.Value = DateTime.Today;

                // Default to active
                chkActive.Checked = true;
            }

            // Update form title based on the operation
            if (id == 0)
            {
                this.label1.Text = "Add Staff Member";
            }
            else
            {
                this.label1.Text = "Edit Staff Member";
            }
        }

        private void SaveStaff()
        {
            try
            {
                // Create a hashtable to store parameters
                Hashtable ht = new Hashtable();
                ht.Add("@firstName", txtFirstName.Text);
                ht.Add("@lastName", txtLastName.Text);
                ht.Add("@phone", txtPhone.Text);
                ht.Add("@email", txtEmail.Text);
                ht.Add("@position", txtPosition.Text);
                ht.Add("@salary", string.IsNullOrEmpty(txtSalary.Text) ? DBNull.Value : (object)decimal.Parse(txtSalary.Text));
                ht.Add("@hireDate", dtpHireDate.Value.Date);
                ht.Add("@active", chkActive.Checked ? 1 : 0);

                // Define the query based on whether we're adding or updating
                string query;
                if (id == 0)
                {
                    // For new staff members - INSERT
                    query = "INSERT INTO staff (firstName, lastName, phone, email, position, salary, hireDate, active) " +
                            "VALUES (@firstName, @lastName, @phone, @email, @position, @salary, @hireDate, @active)";
                }
                else
                {
                    // For existing staff members - UPDATE
                    ht.Add("@staffID", id);
                    query = "UPDATE staff SET firstName = @firstName, lastName = @lastName, " +
                            "phone = @phone, email = @email, position = @position, " +
                            "salary = @salary, hireDate = @hireDate, active = @active " +
                            "WHERE staffID = @staffID";
                }

                // Execute the SQL command
                int result = MainClass.SQL(query, ht);

                if (result > 0)
                {
                    MessageBox.Show("Staff member saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form fields
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtPhone.Clear();
                    txtEmail.Clear();
                    txtPosition.Clear();
                    txtSalary.Clear();
                    dtpHireDate.Value = DateTime.Today;
                    chkActive.Checked = true;
                    id = 0;

                    // Set focus back to first name
                    txtFirstName.Focus();

                    // Trigger the event to notify that a staff member was added/updated
                    StaffAdded?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving staff member: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion
}
