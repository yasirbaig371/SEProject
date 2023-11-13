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
    public partial class Form1 : Form
    {
        public Form1()
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
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
             textBox2.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int role = 0;
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please!Fill All the Blanks", "Error Message",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox1.Text == "Admin")
                {
                    role = 7;
                }
                if (comboBox1.Text == "Employee")
                {
                    role = 5;
                }
                if (comboBox1.Text == "Manager")
                {
                    role = 6;
                }
                var con = Configuration.getInstance().getConnection();
                string query = "select * from Credentials where Username = @Username AND Password = @Password AND Role = @Role";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", role);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Login Successfully!", "Information Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        if (role == 5)
                        {
                            Form3 f3 = new Form3();
                            f3.Show();
                        }
                        else if(role == 7)
                        {
                            Form4 f3 = new Form4();
                            f3.Show();
                        }
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
