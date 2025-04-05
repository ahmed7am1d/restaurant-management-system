namespace ResturantManagmentSystem.View.Bill
{
    partial class frmBillList
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
            this.label1 = new System.Windows.Forms.Label();
            this.chkCompletedOrders = new System.Windows.Forms.CheckBox();
            this.chkPaidOrders = new System.Windows.Forms.CheckBox();
            this.chkAllOrders = new System.Windows.Forms.CheckBox();
            this.dgvBillOrders = new System.Windows.Forms.DataGridView();
            this.orderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseDialog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillOrders)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bill management";
            // 
            // chkCompletedOrders
            // 
            this.chkCompletedOrders.AutoSize = true;
            this.chkCompletedOrders.Location = new System.Drawing.Point(17, 78);
            this.chkCompletedOrders.Name = "chkCompletedOrders";
            this.chkCompletedOrders.Size = new System.Drawing.Size(108, 17);
            this.chkCompletedOrders.TabIndex = 1;
            this.chkCompletedOrders.Text = "Completed orders";
            this.chkCompletedOrders.UseVisualStyleBackColor = true;
            // 
            // chkPaidOrders
            // 
            this.chkPaidOrders.AutoSize = true;
            this.chkPaidOrders.Location = new System.Drawing.Point(160, 78);
            this.chkPaidOrders.Name = "chkPaidOrders";
            this.chkPaidOrders.Size = new System.Drawing.Size(79, 17);
            this.chkPaidOrders.TabIndex = 2;
            this.chkPaidOrders.Text = "Paid orders";
            this.chkPaidOrders.UseVisualStyleBackColor = true;
            // 
            // chkAllOrders
            // 
            this.chkAllOrders.AutoSize = true;
            this.chkAllOrders.Location = new System.Drawing.Point(285, 78);
            this.chkAllOrders.Name = "chkAllOrders";
            this.chkAllOrders.Size = new System.Drawing.Size(69, 17);
            this.chkAllOrders.TabIndex = 3;
            this.chkAllOrders.Text = "All orders";
            this.chkAllOrders.UseVisualStyleBackColor = true;
            // 
            // dgvBillOrders
            // 
            this.dgvBillOrders.AllowUserToAddRows = false;
            this.dgvBillOrders.AllowUserToDeleteRows = false;
            this.dgvBillOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvBillOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderID,
            this.tableName,
            this.orderDate,
            this.status,
            this.totalAmount});
            this.dgvBillOrders.Location = new System.Drawing.Point(17, 117);
            this.dgvBillOrders.Name = "dgvBillOrders";
            this.dgvBillOrders.ReadOnly = true;
            this.dgvBillOrders.Size = new System.Drawing.Size(734, 237);
            this.dgvBillOrders.TabIndex = 4;
            this.dgvBillOrders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBillOrders_CellClick);
            // 
            // orderID
            // 
            this.orderID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.orderID.DataPropertyName = "orderID";
            this.orderID.HeaderText = "ID";
            this.orderID.Name = "orderID";
            this.orderID.ReadOnly = true;
            this.orderID.Width = 43;
            // 
            // tableName
            // 
            this.tableName.DataPropertyName = "tableName";
            this.tableName.HeaderText = "Table";
            this.tableName.Name = "tableName";
            this.tableName.ReadOnly = true;
            // 
            // orderDate
            // 
            this.orderDate.HeaderText = "Date";
            this.orderDate.Name = "orderDate";
            this.orderDate.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // totalAmount
            // 
            this.totalAmount.HeaderText = "Total";
            this.totalAmount.Name = "totalAmount";
            this.totalAmount.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.btnCloseDialog);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 64);
            this.panel1.TabIndex = 6;
            // 
            // btnCloseDialog
            // 
            this.btnCloseDialog.BackColor = System.Drawing.Color.White;
            this.btnCloseDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDialog.ForeColor = System.Drawing.Color.Red;
            this.btnCloseDialog.Location = new System.Drawing.Point(755, 3);
            this.btnCloseDialog.Name = "btnCloseDialog";
            this.btnCloseDialog.Size = new System.Drawing.Size(47, 34);
            this.btnCloseDialog.TabIndex = 0;
            this.btnCloseDialog.Text = "X";
            this.btnCloseDialog.UseVisualStyleBackColor = false;
            this.btnCloseDialog.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmBillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvBillOrders);
            this.Controls.Add(this.chkAllOrders);
            this.Controls.Add(this.chkPaidOrders);
            this.Controls.Add(this.chkCompletedOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBillList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmBillList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillOrders)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCompletedOrders;
        private System.Windows.Forms.CheckBox chkPaidOrders;
        private System.Windows.Forms.CheckBox chkAllOrders;
        private System.Windows.Forms.DataGridView dgvBillOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCloseDialog;
    }
}