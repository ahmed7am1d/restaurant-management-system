namespace ResturantManagmentSystem
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.RadioButton();
            this.btnKitchen = new System.Windows.Forms.RadioButton();
            this.btnPOS = new System.Windows.Forms.RadioButton();
            this.btnStaff = new System.Windows.Forms.RadioButton();
            this.btnTable = new System.Windows.Forms.RadioButton();
            this.btnProduct = new System.Windows.Forms.RadioButton();
            this.btnCategories = new System.Windows.Forms.RadioButton();
            this.btnHome = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnKitchen);
            this.panel1.Controls.Add(this.btnPOS);
            this.panel1.Controls.Add(this.btnStaff);
            this.panel1.Controls.Add(this.btnTable);
            this.panel1.Controls.Add(this.btnProduct);
            this.panel1.Controls.Add(this.btnCategories);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 610);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSettings
            // 
            this.btnSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnSettings.AutoSize = true;
            this.btnSettings.BackColor = System.Drawing.Color.Indigo;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSettings.Location = new System.Drawing.Point(79, 487);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(120, 22);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.Text = "      Setting     ";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnKitchen
            // 
            this.btnKitchen.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnKitchen.AutoSize = true;
            this.btnKitchen.BackColor = System.Drawing.Color.Silver;
            this.btnKitchen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnKitchen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnKitchen.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKitchen.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnKitchen.Location = new System.Drawing.Point(77, 443);
            this.btnKitchen.Name = "btnKitchen";
            this.btnKitchen.Size = new System.Drawing.Size(123, 22);
            this.btnKitchen.TabIndex = 8;
            this.btnKitchen.Text = "        Kitchen   ";
            this.btnKitchen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKitchen.UseVisualStyleBackColor = false;
            this.btnKitchen.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // btnPOS
            // 
            this.btnPOS.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnPOS.AutoSize = true;
            this.btnPOS.BackColor = System.Drawing.Color.Silver;
            this.btnPOS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPOS.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnPOS.Location = new System.Drawing.Point(77, 399);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(122, 22);
            this.btnPOS.TabIndex = 7;
            this.btnPOS.Text = "        POS        ";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPOS.UseVisualStyleBackColor = false;
            this.btnPOS.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // btnStaff
            // 
            this.btnStaff.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnStaff.AutoSize = true;
            this.btnStaff.BackColor = System.Drawing.Color.Silver;
            this.btnStaff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStaff.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStaff.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaff.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnStaff.Location = new System.Drawing.Point(77, 355);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(115, 22);
            this.btnStaff.TabIndex = 6;
            this.btnStaff.Text = "       Staff      ";
            this.btnStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStaff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStaff.UseVisualStyleBackColor = false;
            this.btnStaff.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // btnTable
            // 
            this.btnTable.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnTable.AutoSize = true;
            this.btnTable.BackColor = System.Drawing.Color.Silver;
            this.btnTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTable.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTable.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnTable.Location = new System.Drawing.Point(76, 311);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(116, 22);
            this.btnTable.TabIndex = 5;
            this.btnTable.Text = "      Tables     ";
            this.btnTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnTable.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTable.UseVisualStyleBackColor = false;
            // 
            // btnProduct
            // 
            this.btnProduct.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnProduct.AutoSize = true;
            this.btnProduct.BackColor = System.Drawing.Color.Silver;
            this.btnProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnProduct.Location = new System.Drawing.Point(77, 267);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(116, 22);
            this.btnProduct.TabIndex = 4;
            this.btnProduct.Text = "    Products   ";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduct.UseVisualStyleBackColor = false;
            // 
            // btnCategories
            // 
            this.btnCategories.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnCategories.AutoSize = true;
            this.btnCategories.BackColor = System.Drawing.Color.Silver;
            this.btnCategories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCategories.Location = new System.Drawing.Point(76, 223);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(118, 22);
            this.btnCategories.TabIndex = 3;
            this.btnCategories.Text = "   Categories  ";
            this.btnCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.CategoryButton_Clicked);
            // 
            // btnHome
            // 
            this.btnHome.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnHome.AutoSize = true;
            this.btnHome.BackColor = System.Drawing.Color.OrangeRed;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnHome.Location = new System.Drawing.Point(76, 179);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(113, 22);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "      Home     ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.CheckedChanged += new System.EventHandler(this.HomeButton_Clicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(34, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Resturant Managment \r\n              System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Indigo;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(79, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OrangeRed;
            this.panel2.Controls.Add(this.lblUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(275, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 60);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUser.Location = new System.Drawing.Point(6, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(58, 21);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "label2";
            this.lblUser.UseWaitCursor = true;
            // 
            // ControlPanel
            // 
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlPanel.Location = new System.Drawing.Point(275, 60);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(660, 550);
            this.ControlPanel.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 610);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton btnHome;
        private System.Windows.Forms.RadioButton btnKitchen;
        private System.Windows.Forms.RadioButton btnPOS;
        private System.Windows.Forms.RadioButton btnStaff;
        private System.Windows.Forms.RadioButton btnTable;
        private System.Windows.Forms.RadioButton btnProduct;
        private System.Windows.Forms.RadioButton btnCategories;
        private System.Windows.Forms.RadioButton btnSettings;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel ControlPanel;
    }
}