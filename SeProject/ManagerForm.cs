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

namespace SeProject
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlDataAdapter sql = new SqlDataAdapter("select p.Id,p.FullName,p.DateOfBirth,p.Gender,p.Email,p.Contact, e.Degree,e.Designation,e.Skill,e.Salary,e.CreatedAt,e.UpdatedAt,e.Status from Person as p join Employee as e on p.Id = e.EId ", con);
            DataTable db = new DataTable();
            sql.Fill(db);
            dataGridView1.DataSource = db;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeInfo f5 = new EmployeeInfo();
            f5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm f1 = new MainForm();
            f1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm f1 = new MainForm();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete d = new Delete();
            d.Show();
        }
    }
}
