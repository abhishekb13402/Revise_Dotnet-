namespace Calculator
{
    partial class Form1
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
            textBox1 = new TextBox();
            btnequals = new Button();
            btnclear = new Button();
            btnadd = new Button();
            btnsub = new Button();
            btnmul = new Button();
            btndiv = new Button();
            btn9 = new Button();
            btn8 = new Button();
            btn7 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn0 = new Button();
            btndot = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(394, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "0";
            textBox1.TextAlign = HorizontalAlignment.Right;
            // 
            // btnequals
            // 
            btnequals.Location = new Point(217, 282);
            btnequals.Name = "btnequals";
            btnequals.Size = new Size(194, 29);
            btnequals.TabIndex = 2;
            btnequals.Text = "=";
            btnequals.UseVisualStyleBackColor = true;
            btnequals.Click += btnequals_Click;
            // 
            // btnclear
            // 
            btnclear.Location = new Point(17, 282);
            btnclear.Name = "btnclear";
            btnclear.Size = new Size(194, 29);
            btnclear.TabIndex = 3;
            btnclear.Text = "C";
            btnclear.UseVisualStyleBackColor = true;
            btnclear.Click += btnclear_Click;
            // 
            // btnadd
            // 
            btnadd.Location = new Point(317, 230);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(94, 29);
            btnadd.TabIndex = 4;
            btnadd.Text = "+";
            btnadd.UseVisualStyleBackColor = true;
            btnadd.Click += btnadd_Click;
            // 
            // btnsub
            // 
            btnsub.Location = new Point(317, 169);
            btnsub.Name = "btnsub";
            btnsub.Size = new Size(94, 29);
            btnsub.TabIndex = 5;
            btnsub.Text = "-";
            btnsub.UseVisualStyleBackColor = true;
            btnsub.Click += btnsub_Click;
            // 
            // btnmul
            // 
            btnmul.Location = new Point(317, 113);
            btnmul.Name = "btnmul";
            btnmul.Size = new Size(94, 29);
            btnmul.TabIndex = 6;
            btnmul.Text = "*";
            btnmul.UseVisualStyleBackColor = true;
            btnmul.Click += btnmul_Click;
            // 
            // btndiv
            // 
            btndiv.Location = new Point(317, 59);
            btndiv.Name = "btndiv";
            btndiv.Size = new Size(94, 29);
            btndiv.TabIndex = 7;
            btndiv.Text = "/";
            btndiv.UseVisualStyleBackColor = true;
            btndiv.Click += btndiv_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(217, 59);
            btn9.Name = "btn9";
            btn9.Size = new Size(94, 29);
            btn9.TabIndex = 8;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(117, 59);
            btn8.Name = "btn8";
            btn8.Size = new Size(94, 29);
            btn8.TabIndex = 9;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(17, 59);
            btn7.Name = "btn7";
            btn7.Size = new Size(94, 29);
            btn7.TabIndex = 10;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(17, 113);
            btn4.Name = "btn4";
            btn4.Size = new Size(94, 29);
            btn4.TabIndex = 13;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(117, 113);
            btn5.Name = "btn5";
            btn5.Size = new Size(94, 29);
            btn5.TabIndex = 12;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(217, 113);
            btn6.Name = "btn6";
            btn6.Size = new Size(94, 29);
            btn6.TabIndex = 11;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(17, 169);
            btn1.Name = "btn1";
            btn1.Size = new Size(94, 29);
            btn1.TabIndex = 16;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(117, 169);
            btn2.Name = "btn2";
            btn2.Size = new Size(94, 29);
            btn2.TabIndex = 15;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(217, 169);
            btn3.Name = "btn3";
            btn3.Size = new Size(94, 29);
            btn3.TabIndex = 14;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn0
            // 
            btn0.Location = new Point(17, 230);
            btn0.Name = "btn0";
            btn0.Size = new Size(194, 29);
            btn0.TabIndex = 18;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btn0_Click;
            // 
            // btndot
            // 
            btndot.Location = new Point(217, 230);
            btndot.Name = "btndot";
            btndot.Size = new Size(94, 29);
            btndot.TabIndex = 17;
            btndot.Text = ".";
            btndot.UseVisualStyleBackColor = true;
            btndot.Click += btndot_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 336);
            Controls.Add(btn0);
            Controls.Add(btndot);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btn7);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btndiv);
            Controls.Add(btnmul);
            Controls.Add(btnsub);
            Controls.Add(btnadd);
            Controls.Add(btnclear);
            Controls.Add(btnequals);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnequals;
        private Button btnclear;
        private Button btnadd;
        private Button btnsub;
        private Button btnmul;
        private Button btndiv;
        private Button btn9;
        private Button btn8;
        private Button btn7;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn0;
        private Button btndot;
    }
}
