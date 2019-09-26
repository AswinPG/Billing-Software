using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace rishi
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }
        db o = new db();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text=="")
            {
                MessageBox.Show("please enter username");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("please enter password");
                txtPassword.Focus();
                return;
            }
            //try
            //{
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from users where Uname='" + txtUserName.Text + "' and Pass='" + txtPassword.Text + "' ", o.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    Home frm = new Home();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("invalid userid and password");
                }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
                
            //}
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
