namespace Assignment210
{
    partial class Form9
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.dgvGymClass = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignup = new System.Windows.Forms.Button();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTName = new System.Windows.Forms.TextBox();
            this.dgvTrainer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGymClass)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(479, 399);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 55);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(479, 65);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 69);
            this.btnModify.TabIndex = 12;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // dgvGymClass
            // 
            this.dgvGymClass.AllowUserToAddRows = false;
            this.dgvGymClass.AllowUserToDeleteRows = false;
            this.dgvGymClass.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGymClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGymClass.Location = new System.Drawing.Point(574, 17);
            this.dgvGymClass.Name = "dgvGymClass";
            this.dgvGymClass.ReadOnly = true;
            this.dgvGymClass.RowHeadersWidth = 51;
            this.dgvGymClass.RowTemplate.Height = 24;
            this.dgvGymClass.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGymClass.Size = new System.Drawing.Size(565, 499);
            this.dgvGymClass.TabIndex = 11;
            this.dgvGymClass.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGymClass_CellContentClick);
            this.dgvGymClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGymClass_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTrainer);
            this.groupBox1.Controls.Add(this.txtTName);
            this.groupBox1.Controls.Add(this.txtCID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblBack);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSignup);
            this.groupBox1.Controls.Add(this.txtFee);
            this.groupBox1.Controls.Add(this.txtCategory);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(23, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 525);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GYM CLASS INFORMATION";
            // 
            // txtCID
            // 
            this.txtCID.Enabled = false;
            this.txtCID.Location = new System.Drawing.Point(185, 34);
            this.txtCID.Name = "txtCID";
            this.txtCID.Size = new System.Drawing.Size(172, 22);
            this.txtCID.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Class ID";
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Location = new System.Drawing.Point(389, 496);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(42, 16);
            this.lblBack.TabIndex = 8;
            this.lblBack.TabStop = true;
            this.lblBack.Text = "BACK";
            this.lblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBack_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Trainer Name";
            // 
            // btnSignup
            // 
            this.btnSignup.Location = new System.Drawing.Point(185, 496);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(121, 23);
            this.btnSignup.TabIndex = 10;
            this.btnSignup.Text = "INSERT";
            this.btnSignup.UseVisualStyleBackColor = true;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(185, 243);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(172, 22);
            this.txtFee.TabIndex = 8;
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(185, 147);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(172, 22);
            this.txtCategory.TabIndex = 7;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(185, 84);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(172, 22);
            this.txtTitle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Title";
            // 
            // txtTName
            // 
            this.txtTName.Location = new System.Drawing.Point(186, 196);
            this.txtTName.Name = "txtTName";
            this.txtTName.Size = new System.Drawing.Size(171, 22);
            this.txtTName.TabIndex = 15;
            // 
            // dgvTrainer
            // 
            this.dgvTrainer.AllowUserToAddRows = false;
            this.dgvTrainer.AllowUserToDeleteRows = false;
            this.dgvTrainer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainer.Location = new System.Drawing.Point(12, 271);
            this.dgvTrainer.Name = "dgvTrainer";
            this.dgvTrainer.ReadOnly = true;
            this.dgvTrainer.RowHeadersWidth = 51;
            this.dgvTrainer.RowTemplate.Height = 24;
            this.dgvTrainer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrainer.Size = new System.Drawing.Size(419, 219);
            this.dgvTrainer.TabIndex = 16;
            this.dgvTrainer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrainer_CellContentClick);
            this.dgvTrainer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrainer_CellContentClick);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(200)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1162, 538);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.dgvGymClass);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form9";
            this.Text = "ADMIN PANEL";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGymClass)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.DataGridView dgvGymClass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lblBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTName;
        private System.Windows.Forms.DataGridView dgvTrainer;
    }
}