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
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("please enter name");
                txtname.Focus();
                return;
            }
            if (txtaddress.Text == "")
            {
                MessageBox.Show("please enter address");
                txtaddress.Focus();
                return;
            }
            if (txtcity.Text == "")
            {
                MessageBox.Show("please enter city");
                txtcity.Focus();
                return;
            }
            
            try
            {
                string s="";
                if (txtcuid.Text == "0")
                {
                    s = "insert into customers(CNAME,ADDR,CITY) values('" + txtname.Text + "','" + txtaddress.Text + "','" + txtcity.Text + "')";
                    
                }
                else
                {
                    s = "update customers set CNAME='" + txtname.Text + "',ADDR='" +txtaddress.Text+ "',CITY='"+txtcity.Text+"' where cuid='" + txtcuid.Text + "'";
                }
                o.con.Open();
                SqlCommand cmd = new SqlCommand(s, o.con);
                cmd.ExecuteNonQuery();
                btnclear_Click(sender, e);
                loadgrid();
                o.con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        db o = new db();
        void loadgrid()
        {
            string sql = "Select * from customers";
            SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void customer_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtaddress.Text = "";
            txtcity.Text = "";
            txtcuid.Text = "";
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            txtcuid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtcity.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtcuid.Text != "0")
            {
                if (MessageBox.Show("are you sure to delete", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {

                    try
                    {
                        string s = "Delete from customers where cuid=" + txtcuid.Text;

                        o.con.Open();
                        SqlCommand cmd = new SqlCommand(s, o.con);
                        cmd.ExecuteNonQuery();
                        btnclear_Click(sender, e);
                        loadgrid();
                        o.con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
