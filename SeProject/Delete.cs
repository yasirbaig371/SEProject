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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm a =   new AdminForm();
            a.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("update Employee set Status = 2 where EId = @id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully", "Information Message",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
