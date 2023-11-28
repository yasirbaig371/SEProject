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
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo()
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
            AdminForm f4 = new AdminForm();
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int des = 0;
            int skill = 0;

            if (comboBox2.Text == "Mobile Developer")
            {
                skill = 10;
            }
            if (comboBox2.Text == "Software Developer")
            {
                skill = 11;
            }
            else if (comboBox2.Text == "Web Developer")
            {
                skill = 13;
            }
            else if (comboBox2.Text == "Designer")
            {
                skill = 12;
            }
            else if (comboBox2.Text == "Full Stack Developer")
            {
                skill = 14;
            }
            else if (comboBox2.Text == "Analyst")
            {
                skill = 15;
            }
            //Designation
            if (comboBox3.Text == "Junior Developer")
            {
                des = 5;
            }
            else if (comboBox3.Text == "Senior Developer")
            {
                des = 6;
            }
            else if (comboBox3.Text == "Tester")
            {
                des = 7;
            }
            else if (comboBox3.Text == "Team Leader")
            {
                des = 9;
            }
            else if (comboBox3.Text == "Project Manager")
            {
                des = 8;
            }
   
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("insert into Employee (EId,Designation,Salary,CreatedAt,Status,Degree,Skill) values(@Id,@Desig,@Salary,@CreatedAt,@Status,@Degree,@Skill) ", con);
            cmd.Parameters.AddWithValue("@Id",textBox1.Text);
            cmd.Parameters.AddWithValue("@Skill", skill);
            cmd.Parameters.AddWithValue("@Desig", des);
            cmd.Parameters.AddWithValue("@Salary", textBox8.Text);
            cmd.Parameters.AddWithValue("@Degree", textBox2.Text);
            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Status", 1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Add Successfully", "Information Message",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox8.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
                
        }
    }
}
