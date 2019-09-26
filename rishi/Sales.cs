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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }
        db o = new db();
        
        public void loadcombo()
        {
            string sql = "select PID,PNAME from Product";
            SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboproduct.DataSource = dt;
            comboproduct.DisplayMember = "PNAME";
            comboproduct.ValueMember = "PID";
            comboproduct.SelectedIndex = -1;
            txtstock.Text = "";
            txtrate.Text = "";
            txtbrand.Text = "";

        }
        public void loadcombo1()
        {
            string sql = "select CUID,CNAME from customers";
            SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboname.DataSource = dt;
            comboname.DisplayMember = "CNAME";
            comboname.ValueMember = "CUID";
            comboname.SelectedIndex = -1;
            txtaddr.Text = "";
            txtstock.Text = "";
            txtrate.Text = "";
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (comboproduct.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Product");
                return;
            }
            if (comboname.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Customer Name");
                return;
            }
            if (txtquantity.Text == "")
            {
                MessageBox.Show("Please enter Quantity");
                return;
            }
            decimal rate = decimal.Parse(txtrate.Text);
            decimal qty = decimal.Parse(txtquantity.Text);
            decimal gst = decimal.Parse(txtgst.Text);
            decimal discount = decimal.Parse(txtdiscount.Text);
            decimal total = rate * qty;

            decimal Total = decimal.Parse(txttotal.Text);
            Total = Total + total;
            decimal grandtotal = decimal.Parse(txtgrandtotal.Text);
            grandtotal = Total + (Total*(gst / 100)) + (Total*(discount / 100));

            txttotal.Text = Total.ToString();
            txtgrandtotal.Text= grandtotal.ToString();

            dataGridView1.Rows.Add(comboproduct.SelectedValue.ToString(), comboproduct.Text, txtquantity.Text,txtrate.Text,total);
            comboproduct.SelectedIndex = -1;
            txtquantity.Text = "";
            comboproduct.Focus();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            txtbrand.Text = "";
            txtbill.Text = "";
            txtgrandtotal.Text = "0.00";
            txttotal.Text = "0.00";
            txtaddr.Text = "";
            comboname.Text = "";
            comboproduct.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            txtstock.Text = "";
            txtrate.Text = "";
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            loadcombo();
            loadcombo1();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("please add products");
                comboproduct.Focus();
                return;
            }
            if (txtbill.Text == "")
            {
                MessageBox.Show("Please enter Bill No");
                return;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string sql = "insert into sales(PID,QTY,BILLDATE,BILLNO,CUID,AMT) values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dateTimePicker1.Text + "','" + txtbill.Text + "','"+ comboname.SelectedIndex.ToString()+"','"+ txtgrandtotal.Text+ "')";
                o.con.Open();
                SqlCommand cmd = new SqlCommand(sql, o.con);
                cmd.ExecuteNonQuery();
                o.con.Close();
            }


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string sql = "";
                
                //stock update
                sql = "update stock set qty= qty-'" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "' where PID='" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'";
                
                
                

                o.con.Open();
                SqlCommand cmd = new SqlCommand(sql, o.con);
                cmd.ExecuteNonQuery();
                o.con.Close();
            }


            MessageBox.Show("Saved Successfully");
            dataGridView1.Rows.Clear();
            txtbrand.Text = "";
            txtbill.Text = "";
            txtgrandtotal.Text = "0.00";
            txttotal.Text = "0.00";
            txtaddr.Text = "";
            comboname.Text = "";
            comboproduct.SelectedIndex = -1;
            txtstock.Text = "";
            txtrate.Text = "";
        }

        private void comboproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                string sql = "select product.PID,product.PNAME,product.RATE,product.BID,stock.QTY from stock inner join product on stock.PID=product.PID where PNAME='" + comboproduct.Text + "'";
                SqlCommand da = new SqlCommand(sql, o.con);
                DataTable dt = new DataTable();
                o.con.Open();
                da.ExecuteNonQuery();
                SqlDataReader dr;
                dr = da.ExecuteReader();
                while (dr.Read())
                {
                    string rate = (string)dr["RATE"].ToString();
                    txtrate.Text = rate;

                    string brand = (string)dr["BID"].ToString();
                    txtbrand.Text = brand;

                    string stock = (string)dr["QTY"].ToString();
                    txtstock.Text = stock;

                }
                o.con.Close();
        }
        
        private void comboname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM customers where CNAME='" + comboname.Text + "'";
            SqlCommand da = new SqlCommand(sql, o.con);
            DataTable dt = new DataTable();
            o.con.Open();
            da.ExecuteNonQuery();
            SqlDataReader dr;
            dr = da.ExecuteReader();
            while (dr.Read())
            {
                string phone = (string)dr["ADDR"].ToString();
                txtaddr.Text = phone;
             }
            o.con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtrate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
    
}
