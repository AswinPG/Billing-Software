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
    public partial class purchase : Form
    {
        public purchase()
        {
            InitializeComponent();
        }
        db o = new db();
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
        }

        private void purchase_Load(object sender, EventArgs e)
        {
            loadcombo();
        }
        public void loadcombo()
        {
            string sql = "select PID,PNAME from Product";
            SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            combopro.DataSource = dt;
            combopro.DisplayMember = "PNAME";
            combopro.ValueMember = "PID";
            combopro.SelectedIndex = -1;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (combopro.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Product");
                return;
            }
            if (txtquantity.Text == "")
            {
                MessageBox.Show("Please enter Quantity");
                return;
            }
            dataGridView1.Rows.Add(combopro.SelectedValue.ToString(), combopro.Text, txtquantity.Text,dateTimePicker2.Text);
            combopro.SelectedIndex = -1;
            txtquantity.Text = "";
            combopro.Focus();
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("please add products");
                combopro.Focus();
                return;
            }
            if (txtinvo.Text == "")
            {
                MessageBox.Show("Please enter Invoice No");
                return;
            }
            if(checkBox1.Checked==true & dateTimePicker2.CustomFormat==" ")
            {
                MessageBox.Show("Please enter Expiry Date");
                return;
            }
            for(int i=0; i<dataGridView1.Rows.Count;i++)
            {
                string sql = "insert into purchase(PID,QTY,PDATE,PINV,EXP) values('"+dataGridView1.Rows[i].Cells[0].Value.ToString()+ "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','"+dateTimePicker1.Text+"','"+txtinvo.Text+"','"+dateTimePicker2.Text+"')";
                o.con.Open();
                SqlCommand cmd = new SqlCommand(sql, o.con);
                cmd.ExecuteNonQuery();
                o.con.Close();
            }


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string sql = "";
                if (ispresent(dataGridView1.Rows[i].Cells[0].Value.ToString()))
                {
                    //stock update
                    sql = "update stock set qty= qty+'"+ dataGridView1.Rows[i].Cells[2].Value.ToString()+"' where PID='"+ dataGridView1.Rows[i].Cells[0].Value.ToString()+"'";
                }
                else
                {
                    //insert
                    sql = "insert into stock(PID,QTY) values(" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "," + dataGridView1.Rows[i].Cells[2].Value.ToString() + ")";
                }
                
                o.con.Open();
                SqlCommand cmd = new SqlCommand(sql, o.con);
                cmd.ExecuteNonQuery();
                o.con.Close();
            }


            MessageBox.Show("Purchase Entry Saved");
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        bool ispresent(string pid)
        {
            bool a = false;
            SqlDataAdapter da = new SqlDataAdapter("SELECT PID from stock where PID='"+pid+"'", o.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count>0)
            {
                a = true;
            }
            return a;
            
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void combopro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            }
            else
            {
                dateTimePicker2.CustomFormat = " ";
            }
        }
    }
    
    
}
