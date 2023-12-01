using Microsoft.SqlServer.Server;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SeProject
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeForm f5 = new EmployeeForm();
            f5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete d = new Delete();
            d.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlDataAdapter sql = new SqlDataAdapter("select p.Id,p.FullName,p.DateOfBirth,p.Gender,p.Email,p.Contact, e.Degree,e.Designation,e.Skill,e.Salary,e.CreatedAt,e.UpdatedAt,e.Status from Person as p join Employee as e on p.Id = e.EId where e.Status = 1 ", con);
            DataTable db = new DataTable();
            sql.Fill(db);
            dataGridView1.DataSource=db;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlDataAdapter sql = new SqlDataAdapter("select p.Id,p.FullName,p.DateOfBirth,p.Gender,p.Email,p.Contact, e.Degree,e.Designation,e.Skill,e.Salary,e.CreatedAt,e.UpdatedAt,e.Status from Person as p join Employee as e on p.Id = e.EId where e.Status = 2", con);
            DataTable db = new DataTable();
            sql.Fill(db);
            dataGridView1.DataSource = db;
        }
    }
}
