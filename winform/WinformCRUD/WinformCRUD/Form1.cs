using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace WinformCRUD
{
    public partial class CRUD_Employee : Form
    {
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-7LJ1QEL\\SQLEXPRESS;Initial Catalog=WinformDemo;Integrated Security=True;Encrypt=False");
        public CRUD_Employee()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetDepartmentData();
            BindDridView();
        }
        private void BindDridView()
        {
            try
            {
                string query = "select * from Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetDepartmentData()
        {
            try
            {
                cnn.Open();
                var query = "select DeptName from Department";
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("DeptName", typeof(string));
                dataTable.Load(reader);
                comboBoxDepartment.ValueMember = "DeptName";
                comboBoxDepartment.DataSource = dataTable;
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to get Dept data");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                var query = "Insert into Employees values(@FirstName, @LastName, @Email, @Department)";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@FirstName", tbfname.Text);
                cmd.Parameters.AddWithValue("@LastName", tblname.Text);
                cmd.Parameters.AddWithValue("@Email", tbemail.Text);
                cmd.Parameters.AddWithValue("@Department", comboBoxDepartment.Text);

                cmd.ExecuteNonQuery();
                cnn.Close();

                BindDridView();
                MessageBox.Show("Data Add");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                var query = "update Employees set Firstname = @FirstName, LastName = @LastName, Email = @Email, Department = @Department where EmployeeId = @EmployeeId";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@EmployeeId", tbempid.Text);
                cmd.Parameters.AddWithValue("@FirstName", tbfname.Text);
                cmd.Parameters.AddWithValue("@LastName", tblname.Text);
                cmd.Parameters.AddWithValue("@Email", tbemail.Text);
                cmd.Parameters.AddWithValue("@Department", comboBoxDepartment.Text);

                cmd.ExecuteNonQuery();
                cnn.Close();

                BindDridView();
                MessageBox.Show("Data Update");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                var query = "delete from Employees where EmployeeId = @EmployeeId";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@EmployeeId", tbempid.Text);
           
                cmd.ExecuteNonQuery();
                cnn.Close();

                BindDridView();
                resetControlls();

                MessageBox.Show("Data Delete");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gotodept_Click(object sender, EventArgs e)
        {
            try
            {
                //this.Hide();
                DepartmentForm form = new DepartmentForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                tbempid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                tbfname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                tblname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                tbemail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                comboBoxDepartment.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetControlls();
        }

        private void resetControlls()
        {
            tbempid.Text = "";
            tbfname.Text = "";
            tblname.Text = "";
            tbemail.Text = "";
            comboBoxDepartment.Text = "";
        }
    }
}
