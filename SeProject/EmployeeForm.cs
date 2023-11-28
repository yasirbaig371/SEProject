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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Person set FullName = @full, Username = @user, Email = @email, Password = @password, DateOfBirth = @dob,Contact = @contact where Id = @id", con);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            cmd.Parameters.AddWithValue("@full", textBox3.Text);
            cmd.Parameters.AddWithValue("@dob", this.dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@contact", textBox5.Text);
            cmd.Parameters.AddWithValue("@id", textBox6.Text);
            cmd.ExecuteNonQuery();
            panel2.Visible = false;
            MessageBox.Show("Updated Successfully", "Information Message",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            panel2.Visible = true;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select FullName,Username,Password,Email,Contact, from Person where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox7.Text));
            SqlDataReader re = cmd.ExecuteReader();
            while (re.Read())
            {

                textBox1.Text = re.GetValue(0).ToString();
                textBox2.Text = re.GetValue(1).ToString();
                textBox3.Text = re.GetValue(2).ToString();
                textBox4.Text = re.GetValue(3).ToString();
                textBox5.Text = re.GetValue(4).ToString();
            }
 
        }
    }
}
