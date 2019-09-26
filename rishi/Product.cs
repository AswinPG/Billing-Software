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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
            loadcombo();
        }
        db o = new db();
        

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("please enter product name");
                txtname.Focus();
                return;
            }
            if (comboBoxbrand.SelectedIndex == -1)
            {
                MessageBox.Show("please select brand");
                comboBoxbrand.Focus();
                return;
            }
            if (txtrate.Text == "")
            {
                MessageBox.Show("please enter rate");
                txtrate.Focus();
                return;
            }
            
            try
            {
                string s = "";
                if (txtpid.Text == "0")
                {
                    s = "insert into product(pname,bid,rate)values('" + txtname.Text + "','" + comboBoxbrand.SelectedValue.ToString() + "','"+txtrate.Text+"')";
                    MessageBox.Show("Product Added Successfully");
                }
                else
                {
                    s = "update product set pname='" + txtname.Text + "',bid='" + comboBoxbrand.SelectedValue.ToString() + "',rate='"+txtrate.Text+"' where pid='" + txtpid.Text + "'";
                    MessageBox.Show("Product Updated Successfully");
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void loadcombo()
        {
            string sql = "select BID,BNAME from brand";
            SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBoxbrand.DataSource = dt;
            comboBoxbrand.DisplayMember = "Bname";
            comboBoxbrand.ValueMember = "BID";
            comboBoxbrand.SelectedIndex = -1;
        }
        void loadgrid()
        {
            string sql = "select * from product";
            SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        private void btnclear_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            comboBoxbrand.SelectedIndex = -1;
            
            txtrate.Text = "";
            txtpid.Text = "0";
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtpid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBoxbrand.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtrate.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtpid.Text != "0")
            {
                if (MessageBox.Show("are you sure to delete", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {

                    try
                    {
                        string s = "Delete from product where pid=" + txtpid.Text;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            loadgrid();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            loadgrid();
            
        }

        private void comboBoxbrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
