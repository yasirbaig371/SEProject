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
    public partial class Form5 : Form
    {
        public Form5()
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
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int gender=0,dId=0,des = 0,skill = 0;
            if (radioButton1.Checked)
            {
                gender = 3;
            }
            else if (radioButton1.Checked)
            {
                gender = 4;
            }
            //Departments
            if(comboBox1.Text == "Marketing")
            {
                dId = 1;
            }
            else if (comboBox1.Text == "IT")
            {
                dId = 2;
            }
            else if (comboBox1.Text == "Accounting")
            {
                dId = 3;
            }
            else if (comboBox1.Text == "Product Management")
            {
                dId = 4;
            }
            //Skills
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
            if (comboBox3.Text == "Employee")
            {
                des = 5;
            }
            else if (comboBox3.Text == "Admin")
            {
                des = 7;
            }
            else if (comboBox3.Text == "Deparmental Manager")
            {
                des = 6;
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
            SqlCommand cmd = new SqlCommand("insert into Person values (@Id,@FirstName,@LastName,@Gender,@DateOfBirth,@Email,@Contact)", con);
            cmd.Parameters.AddWithValue("@Id", textBox1.Text);
            cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd.Parameters.AddWithValue("@LastName", textBox4.Text);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@DateOfBirth", this.dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Email", textBox3.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox6.Text);
            cmd.ExecuteNonQuery();
            //SqlCommand cmd1 = new SqlCommand("Insert into Employee values (@EId,@Designation,@DepartmentId,@Salary,@Skill,@CreatedAt,@Status)", con);
            //cmd1.Parameters.AddWithValue("@EId", textBox2.Text);
            //cmd1.Parameters.AddWithValue("@Designation", des);
            //cmd1.Parameters.AddWithValue("@DepartmentId",dId);
            //cmd1.Parameters.AddWithValue("@Salary", textBox8.Text);
            //cmd1.Parameters.AddWithValue("@Skill",skill);
            //cmd1.Parameters.AddWithValue("@CreatedAt", System.DateTime.Today);
            //cmd1.Parameters.AddWithValue("@Status", 1);
            //cmd1.ExecuteNonQuery();
            //MessageBox.Show("Registered Successfully", "Information Message",
            //MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.Hide();
            //Form1 f1 = new Form1();
            //f1.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
