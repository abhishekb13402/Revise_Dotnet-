using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformCRUD
{
    public partial class DepartmentForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-7LJ1QEL\\SQLEXPRESS;Initial Catalog=WinformDemo;Integrated Security=True;Encrypt=False");
        public DepartmentForm()
        {
            InitializeComponent();
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            BindDridView();
        }

        private void BindDridView()
        {
            try
            {
                string query = "select * from Department";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeptinsert_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                var query = "Insert into Department values(@DeptName)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DeptName", tbdeptname.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                BindDridView();
                MessageBox.Show("Department Add");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CountOfDept_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                var query = "Select count(*) from Department";
                SqlCommand cmd = new SqlCommand(query,con);
                var result = cmd.ExecuteScalar();
                con.Close();
                MessageBox.Show("Count of Department is = "+result);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
