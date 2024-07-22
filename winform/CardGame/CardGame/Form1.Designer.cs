namespace CardGame
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
            button1 = new Button();
            Submit = new Button();
            cardA = new CheckBox();
            cardB = new CheckBox();
            cardC = new CheckBox();
            cardD = new CheckBox();
            cardE = new CheckBox();
            cardF = new CheckBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(510, 620);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // Submit
            // 
            Submit.Location = new Point(467, 462);
            Submit.Name = "Submit";
            Submit.Size = new Size(295, 29);
            Submit.TabIndex = 2;
            Submit.Text = "Submit";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // cardA
            // 
            cardA.AutoSize = true;
            cardA.Location = new Point(467, 194);
            cardA.Name = "cardA";
            cardA.Size = new Size(70, 24);
            cardA.TabIndex = 3;
            cardA.Text = "cardA";
            cardA.UseVisualStyleBackColor = true;
            // 
            // cardB
            // 
            cardB.AutoSize = true;
            cardB.Location = new Point(467, 258);
            cardB.Name = "cardB";
            cardB.Size = new Size(69, 24);
            cardB.TabIndex = 4;
            cardB.Text = "cardB";
            cardB.UseVisualStyleBackColor = true;
            // 
            // cardC
            // 
            cardC.AutoSize = true;
            cardC.Location = new Point(467, 321);
            cardC.Name = "cardC";
            cardC.Size = new Size(69, 24);
            cardC.TabIndex = 5;
            cardC.Text = "cardC";
            cardC.UseVisualStyleBackColor = true;
            // 
            // cardD
            // 
            cardD.AutoSize = true;
            cardD.Location = new Point(661, 194);
            cardD.Name = "cardD";
            cardD.Size = new Size(71, 24);
            cardD.TabIndex = 6;
            cardD.Text = "cardD";
            cardD.UseVisualStyleBackColor = true;
            // 
            // cardE
            // 
            cardE.AutoSize = true;
            cardE.Location = new Point(661, 258);
            cardE.Name = "cardE";
            cardE.Size = new Size(68, 24);
            cardE.TabIndex = 7;
            cardE.Text = "cardE";
            cardE.UseVisualStyleBackColor = true;
            // 
            // cardF
            // 
            cardF.AutoSize = true;
            cardF.Location = new Point(661, 321);
            cardF.Name = "cardF";
            cardF.Size = new Size(67, 24);
            cardF.TabIndex = 8;
            cardF.Text = "cardF";
            cardF.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.c1;
            pictureBox1.Location = new Point(50, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(378, 554);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.c2;
            pictureBox2.Location = new Point(825, 32);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(380, 554);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 646);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(cardF);
            Controls.Add(cardE);
            Controls.Add(cardD);
            Controls.Add(cardC);
            Controls.Add(cardB);
            Controls.Add(cardA);
            Controls.Add(Submit);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button Submit;
        private CheckBox cardA;
        private CheckBox cardB;
        private CheckBox cardC;
        private CheckBox cardD;
        private CheckBox cardE;
        private CheckBox cardF;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}
