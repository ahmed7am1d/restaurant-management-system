namespace ResturantManagmentSystem.View.Product
{
    partial class frmProductView
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
            this.pID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDel = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(46, 40);
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.Text = "Product list";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pID,
            this.pName,
            this.pDescription,
            this.pPrice,
            this.catName,
            this.dgvEdit,
            this.dgvDel});
            this.dataGridView1.Location = new System.Drawing.Point(49, 136);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(976, 295);
            this.dataGridView1.TabIndex = 5;
            // 
            // pID
            // 
            this.pID.DataPropertyName = "pID";
            this.pID.HeaderText = "ID";
            this.pID.Name = "pID";
            this.pID.ReadOnly = true;
            // 
            // pName
            // 
            this.pName.DataPropertyName = "pName";
            this.pName.HeaderText = "Name";
            this.pName.Name = "pName";
            this.pName.ReadOnly = true;
            // 
            // pDescription
            // 
            this.pDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pDescription.DataPropertyName = "pDescription";
            this.pDescription.HeaderText = "Description";
            this.pDescription.Name = "pDescription";
            this.pDescription.ReadOnly = true;
            this.pDescription.Width = 99;
            // 
            // pPrice
            // 
            this.pPrice.DataPropertyName = "pPrice";
            this.pPrice.HeaderText = "Price";
            this.pPrice.Name = "pPrice";
            this.pPrice.ReadOnly = true;
            // 
            // catName
            // 
            this.catName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.catName.DataPropertyName = "catName";
            this.catName.HeaderText = "Category";
            this.catName.Name = "catName";
            this.catName.ReadOnly = true;
            // 
            // dgvEdit
            // 
            this.dgvEdit.HeaderText = "Edit Action";
            this.dgvEdit.Image = global::ResturantManagmentSystem.Properties.Resources.edit_icon;
            this.dgvEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            // 
            // dgvDel
            // 
            this.dgvDel.HeaderText = "Delete Action";
            this.dgvDel.Image = global::ResturantManagmentSystem.Properties.Resources.delete_icon;
            this.dgvDel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvDel.Name = "dgvDel";
            this.dgvDel.ReadOnly = true;
            // 
            // frmProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.ClientSize = new System.Drawing.Size(1113, 560);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmProductView";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn pID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn pPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn catName;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
        private System.Windows.Forms.DataGridViewImageColumn dgvDel;
    }
}
