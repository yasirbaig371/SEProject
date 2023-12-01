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
            cmd.Parameters.AddWithValue("@id", textBox7.Text);
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
            Employe E = new Employe();
            
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("select FullName,Username,Password,Email,Contact,DateOfBirth from Person where Id = id", con);
            cmd.Parameters.AddWithValue("@id",textBox7.Text);
            SqlDataReader re;
            re = cmd.ExecuteReader();
            if (re.Read())
            {

                textBox3.Text = re["FullName"].ToString();
                textBox1.Text = re["Username"].ToString();
                textBox2.Text = re["Password"].ToString();
                textBox4.Text = re["Email"].ToString();
                textBox5.Text = re["Contact"].ToString();
                dateTimePicker1.Text = re["DateOfBirth"].ToString();
            }
 
        }
    }
}
