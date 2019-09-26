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
    public partial class change : Form
    {
        public change()
        {
            InitializeComponent();
        }
        db o = new db();
        private void change_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtcurrent.Text == "")
            {
                MessageBox.Show("please enter Current Password");
                txtcurrent.Focus();
                return;
            }
            if (txtnewuser.Text == "")
            {
                MessageBox.Show("Please enter New Username");
                txtnewuser.Focus();
                return;
            }
            if (txtnewpass.Text == "")
            {
                MessageBox.Show("Please enter New Password");
                txtnewpass.Focus();
                return;
            }
            if (txtreenter.Text == "")
            {
                MessageBox.Show("Please Re Enter Password");
                txtreenter.Focus();
                return;
            }
            try
            {
                string s = "";
                SqlDataAdapter da = new SqlDataAdapter("SELECT * from users where Pass='" + txtcurrent.Text + "' ", o.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (txtnewpass.Text == txtreenter.Text)
                    {
                        s = "update users set Uname='"+txtnewuser.Text+"',Pass='" + txtnewpass.Text + "' where Pass='" + txtcurrent.Text + "'";
                        MessageBox.Show("Update Succesfull");
                    }
                    else
                    {
                        MessageBox.Show("Password Does Not Match,Please Re Enter Password");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtcurrent.Text = "";
            txtnewpass.Text = "";
            txtnewuser.Text = "";
            txtreenter.Text = "";
        }
    }
}
