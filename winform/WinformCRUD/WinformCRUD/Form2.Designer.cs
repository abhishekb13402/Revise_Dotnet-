namespace WinformCRUD
{
    partial class DepartmentForm
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
            lbldeptname = new Label();
            tbdeptname = new TextBox();
            btndeptinsert = new Button();
            dataGridView1 = new DataGridView();
            CountOfDept = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbldeptname
            // 
            lbldeptname.AutoSize = true;
            lbldeptname.Location = new Point(18, 87);
            lbldeptname.Name = "lbldeptname";
            lbldeptname.Size = new Size(133, 20);
            lbldeptname.TabIndex = 1;
            lbldeptname.Text = "Department Name";
            // 
            // tbdeptname
            // 
            tbdeptname.Location = new Point(182, 80);
            tbdeptname.Name = "tbdeptname";
            tbdeptname.Size = new Size(196, 27);
            tbdeptname.TabIndex = 3;
            // 
            // btndeptinsert
            // 
            btndeptinsert.Location = new Point(18, 170);
            btndeptinsert.Name = "btndeptinsert";
            btndeptinsert.Size = new Size(360, 49);
            btndeptinsert.TabIndex = 4;
            btndeptinsert.Text = "Insert";
            btndeptinsert.UseVisualStyleBackColor = true;
            btndeptinsert.Click += btndeptinsert_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(406, 23);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(372, 415);
            dataGridView1.TabIndex = 5;
            // 
            // CountOfDept
            // 
            CountOfDept.Location = new Point(18, 247);
            CountOfDept.Name = "CountOfDept";
            CountOfDept.Size = new Size(203, 29);
            CountOfDept.TabIndex = 6;
            CountOfDept.Text = "Count Of Department";
            CountOfDept.UseVisualStyleBackColor = true;
            CountOfDept.Click += CountOfDept_Click;
            // 
            // DepartmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CountOfDept);
            Controls.Add(dataGridView1);
            Controls.Add(btndeptinsert);
            Controls.Add(tbdeptname);
            Controls.Add(lbldeptname);
            Name = "DepartmentForm";
            Text = "CRUD Department";
            Load += DepartmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbldeptname;
        private TextBox tbdeptname;
        private Button btndeptinsert;
        private DataGridView dataGridView1;
        private Button CountOfDept;
    }
}