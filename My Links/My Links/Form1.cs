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

namespace My_Links
{
   
    public partial class Form1 : Form
    {
        function fn = new function();
        string query;
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection consql = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MyLink.mdf;Integrated Security=True");
        

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txtUser.Text!=""&&txtPass.Text!="")
            {
                consql.Open();
                query = "select * from akun where usern='"+txtUser.Text+"' and pass='"+txtPass.Text+"'";
                SqlCommand cmd = new SqlCommand(query,consql);
                cmd.ExecuteNonQuery();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read()==true)
                {
                    new Main().Show();
                    this.Hide();
                }
                else

                {
                    MessageBox.Show("間違いましたパスワード！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Clear();
                    txtPass.Clear();
                }
                consql.Close();
            }
            else
            {
                MessageBox.Show("パスワードが必要です！","注意",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtUser.Clear();
                txtPass.Clear();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
