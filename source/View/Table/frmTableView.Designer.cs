namespace ResturantManagmentSystem.View.Table
{
    partial class frmTableView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDel = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5);
            // 
            // label2
            // 
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Size = new System.Drawing.Size(102, 28);
            this.label2.Text = "Table list";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableID,
            this.tableNumber,
            this.capacity,
            this.location,
            this.status,
            this.notes,
            this.dgvEdit,
            this.dgvDel});
            this.dataGridView1.Location = new System.Drawing.Point(77, 237);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1901, 422);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tableID
            // 
            this.tableID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.tableID.DataPropertyName = "tableID";
            this.tableID.Frozen = true;
            this.tableID.HeaderText = "ID";
            this.tableID.MinimumWidth = 8;
            this.tableID.Name = "tableID";
            this.tableID.ReadOnly = true;
            this.tableID.Width = 67;
            // 
            // tableNumber
            // 
            this.tableNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.tableNumber.DataPropertyName = "tableNumber";
            this.tableNumber.Frozen = true;
            this.tableNumber.HeaderText = "Number";
            this.tableNumber.MinimumWidth = 8;
            this.tableNumber.Name = "tableNumber";
            this.tableNumber.ReadOnly = true;
            this.tableNumber.Width = 120;
            // 
            // capacity
            // 
            this.capacity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.capacity.DataPropertyName = "capacity";
            this.capacity.Frozen = true;
            this.capacity.HeaderText = "Capacity";
            this.capacity.MinimumWidth = 8;
            this.capacity.Name = "capacity";
            this.capacity.ReadOnly = true;
            this.capacity.Width = 123;
            // 
            // location
            // 
            this.location.DataPropertyName = "location";
            this.location.Frozen = true;
            this.location.HeaderText = "Location";
            this.location.MinimumWidth = 8;
            this.location.Name = "location";
            this.location.ReadOnly = true;
            this.location.Width = 150;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.Frozen = true;
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 8;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 150;
            // 
            // notes
            // 
            this.notes.DataPropertyName = "notes";
            this.notes.Frozen = true;
            this.notes.HeaderText = "Notes";
            this.notes.MinimumWidth = 170;
            this.notes.Name = "notes";
            this.notes.ReadOnly = true;
            this.notes.Width = 170;
            // 
            // dgvEdit
            // 
            this.dgvEdit.Frozen = true;
            this.dgvEdit.HeaderText = "Edit action";
            this.dgvEdit.Image = global::ResturantManagmentSystem.Properties.Resources.edit_icon;
            this.dgvEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvEdit.MinimumWidth = 8;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            this.dgvEdit.Width = 150;
            // 
            // dgvDel
            // 
            this.dgvDel.HeaderText = "Delete action";
            this.dgvDel.Image = global::ResturantManagmentSystem.Properties.Resources.delete_icon;
            this.dgvDel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvDel.MinimumWidth = 8;
            this.dgvDel.Name = "dgvDel";
            this.dgvDel.ReadOnly = true;
            this.dgvDel.Width = 150;
            // 
            // frmTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.ClientSize = new System.Drawing.Size(1992, 741);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmTableView";
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
        private System.Windows.Forms.DataGridViewImageColumn dgvDel;
    }
}
