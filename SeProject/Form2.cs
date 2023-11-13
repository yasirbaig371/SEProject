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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
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
            int role = 0;
            if (textBox2.Text == "" || textBox1.Text == "" || comboBox1.Text == "")
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
                SqlCommand cmd = new SqlCommand("insert into Credentials values (@Username,@Password,@Role)", con);
                cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registered Successfully", "Information Message",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
        }
    }
}
