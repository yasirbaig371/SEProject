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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm f1 = new MainForm();
            f1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int gender = 0;
            int role = 0;
            if(comboBox1.Text == "Employee")
            {
                role = 16;
            }
            if (comboBox1.Text == "Admin")
            {
                role = 17;
            }
            if (comboBox1.Text == "Manager")
            {
                role = 18;
            }
            if (radioButton1.Checked == true)
            {
                gender = 3;
            }
            else
            {
                gender = 4;
            }
            if (textBox2.Text == "" || textBox1.Text == "" || textBox5.Text == "" || textBox4.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please!Fill All the Blanks", "Error Message",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox1.Text == "Employee")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("insert into Person(FullName,Username,Password,Gender,DateOfBirth,Email,Contact,Role) values (@FullName,@Username,@Password,@Gender,@DateOfBirth,@Email,@Contact,@Role)", con);
                    cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    cmd.Parameters.AddWithValue("@FullName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@DateOfBirth", this.dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("insert into Employee(Status) values(1)", con);
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Employee Registered Successfully", "Information Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (comboBox1.Text == "Admin")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("insert into Person(FullName,Username,Password,Gender,DateOfBirth,Email,Contact,Role) values (@FullName,@Username,@Password,@Gender,@DateOfBirth,@Email,@Contact,@Role)", con);
                    cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    cmd.Parameters.AddWithValue("@FullName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@DateOfBirth", this.dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("insert into Admin values (@CreatedAt)");
                    cmd1.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd"));
                    MessageBox.Show("Registered Successfully", "Information Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (comboBox1.Text == "Manager")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("insert into Person(FullName,Username,Password,Gender,DateOfBirth,Email,Contact,Role) values (@FullName,@Username,@Password,@Gender,@DateOfBirth,@Email,@Contact,@Role)", con);
                    cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    cmd.Parameters.AddWithValue("@FullName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@DateOfBirth", this.dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Contact", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("insert into Manager values (@CreatedAt)");
                    cmd1.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd"));
                    MessageBox.Show("Registered Successfully", "Information Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.Text = "";
            checkBox1.Checked = false;
        }
    }
}
