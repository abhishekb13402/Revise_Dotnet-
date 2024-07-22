namespace CardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Instruction \n First choose a number 0 to 63 \n " +
                "Then check a checkbox if number is avilabe in specific card\n " +
                "Application gives you number which you guess.");
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            int A = 1, B = 16, C = 32, D = 8, E = 2, F = 4;
            int result = 0;
            if (cardA.Checked)
            {
                result += A;
            }
            if (cardB.Checked)
            {
                result += B;
            }
            if (cardC.Checked)
            {
                result += C;
            }
            if (cardD.Checked)
            {
                result += D;
            }
            if (cardE.Checked)
            {
                result += E;
            }
            if (cardF.Checked)
            {
                result += F;
            }
            MessageBox.Show("Your Number is : "+ result.ToString());
        }
    }
}
