namespace WinformCRUD
{
    partial class CRUD_Employee
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblEmployeeID = new Label();
            lblFirstname = new Label();
            lblLastName = new Label();
            lblEmail = new Label();
            tbempid = new TextBox();
            tbfname = new TextBox();
            tblname = new TextBox();
            tbemail = new TextBox();
            btnInsert = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dataGridView1 = new DataGridView();
            lblDepartment = new Label();
            comboBoxDepartment = new ComboBox();
            gotodept = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblEmployeeID
            // 
            lblEmployeeID.AutoSize = true;
            lblEmployeeID.Location = new Point(28, 101);
            lblEmployeeID.Name = "lblEmployeeID";
            lblEmployeeID.Size = new Size(90, 20);
            lblEmployeeID.TabIndex = 0;
            lblEmployeeID.Text = "EmployeeID";
            // 
            // lblFirstname
            // 
            lblFirstname.AutoSize = true;
            lblFirstname.Location = new Point(28, 151);
            lblFirstname.Name = "lblFirstname";
            lblFirstname.Size = new Size(80, 20);
            lblFirstname.TabIndex = 1;
            lblFirstname.Text = "First Name";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(28, 201);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(79, 20);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(28, 255);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email";
            // 
            // tbempid
            // 
            tbempid.Location = new Point(168, 94);
            tbempid.Name = "tbempid";
            tbempid.ReadOnly = true;
            tbempid.Size = new Size(216, 27);
            tbempid.TabIndex = 4;
            // 
            // tbfname
            // 
            tbfname.Location = new Point(168, 148);
            tbfname.Name = "tbfname";
            tbfname.Size = new Size(216, 27);
            tbfname.TabIndex = 5;
            // 
            // tblname
            // 
            tblname.Location = new Point(168, 201);
            tblname.Name = "tblname";
            tblname.Size = new Size(216, 27);
            tblname.TabIndex = 6;
            // 
            // tbemail
            // 
            tbemail.Location = new Point(168, 255);
            tbemail.Name = "tbemail";
            tbemail.Size = new Size(216, 27);
            tbemail.TabIndex = 7;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(28, 356);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(142, 36);
            btnInsert.TabIndex = 8;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(245, 356);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(139, 36);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(28, 398);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(142, 40);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(245, 398);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(139, 40);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(419, 38);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(695, 400);
            dataGridView1.TabIndex = 12;
            dataGridView1.MouseDoubleClick += dataGridView1_MouseDoubleClick;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(28, 314);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(89, 20);
            lblDepartment.TabIndex = 13;
            lblDepartment.Text = "Department";
            // 
            // comboBoxDepartment
            // 
            comboBoxDepartment.FormattingEnabled = true;
            comboBoxDepartment.Location = new Point(168, 311);
            comboBoxDepartment.Name = "comboBoxDepartment";
            comboBoxDepartment.Size = new Size(216, 28);
            comboBoxDepartment.TabIndex = 14;
            // 
            // gotodept
            // 
            gotodept.Location = new Point(28, 38);
            gotodept.Name = "gotodept";
            gotodept.Size = new Size(356, 36);
            gotodept.TabIndex = 15;
            gotodept.Text = "Manage Department";
            gotodept.UseVisualStyleBackColor = true;
            gotodept.Click += gotodept_Click;
            // 
            // CRUD_Employee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1126, 450);
            Controls.Add(gotodept);
            Controls.Add(comboBoxDepartment);
            Controls.Add(lblDepartment);
            Controls.Add(dataGridView1);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnInsert);
            Controls.Add(tbemail);
            Controls.Add(tblname);
            Controls.Add(tbfname);
            Controls.Add(tbempid);
            Controls.Add(lblEmail);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstname);
            Controls.Add(lblEmployeeID);
            Name = "CRUD_Employee";
            Text = "CRUD Employee";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmployeeID;
        private Label lblFirstname;
        private Label lblLastName;
        private Label lblEmail;
        private TextBox tbempid;
        private TextBox tbfname;
        private TextBox tblname;
        private TextBox tbemail;
        private Button btnInsert;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dataGridView1;
        private Label lblDepartment;
        private ComboBox comboBoxDepartment;
        private Button gotodept;
    }
}
