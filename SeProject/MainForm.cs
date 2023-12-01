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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm f2 = new RegisterForm();
            f2.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
             textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please!Fill All the Blanks", "Error Message",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox1.Text == "Admin")
                {
                    var con = Configuration.getInstance().getConnection();
                    string query = "select * from Person where Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", textBox2.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count >= 1)
                        {
                            MessageBox.Show("Login Successfully!", "Information Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            AdminForm f3 = new AdminForm();
                            f3.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username/Password/Role!", "Information Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                if (comboBox1.Text == "Employee")
                {
                    Employe e1 = new Employe();
                    var con = Configuration.getInstance().getConnection();
                    string query = "select * from Person where Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        
                        e1.name= textBox1.Text;
                        cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", textBox2.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count >= 1)
                        {
                            MessageBox.Show("Login Successfully!", "Information Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            EmployeeForm f3 = new EmployeeForm();
                            f3.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username/Password/Role!", "Information Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                if (comboBox1.Text == "Manager")
                {
                    var con = Configuration.getInstance().getConnection();
                    string query = "select * from Person where Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", textBox2.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows.Count >= 1)
                        {
                            MessageBox.Show("Login Successfully!", "Information Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            EmployeeForm f3 = new EmployeeForm();
                            f3.Show();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username/Password/Role!", "Information Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
