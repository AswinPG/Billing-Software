using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rishi
{
    public partial class brand : Form
    {
        public brand()
        {
            InitializeComponent();
            loadcombo();
        }
        public void loadcombo()
        {
            string sql = "select CID,CNAME from category";
            SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ComboBoxCategory.DataSource = dt;
            ComboBoxCategory.DisplayMember = "Cname";
            ComboBoxCategory.ValueMember = "CID";
            ComboBoxCategory.SelectedIndex = -1;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBname.Text == "")
            {
                MessageBox.Show("Please enter Brand Name");
                txtBname.Focus();
                return;
            }
            if (ComboBoxCategory.SelectedIndex== -1)
            {
                MessageBox.Show("Please Select Category Name");
                ComboBoxCategory.Focus();
                return;
            }
            try
            {
                string s = "";
                if (TxtBID.Text == "0")
                {
                    s = "insert into brand(bname,cid)values('" + txtBname.Text + "','" + ComboBoxCategory.SelectedValue.ToString() + "')";
                }
                else
                {
                   s = "update brand set bname='"+txtBname.Text+"',cid='"+ ComboBoxCategory.SelectedValue.ToString() +"' where bid='" + TxtBID.Text+"'";
                }
                o.con.Open();
                SqlCommand cmd = new SqlCommand(s,o.con);
                cmd.ExecuteNonQuery();
                btnClear_Click( sender,  e);
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
            string sql = "select brand.BID,BRAND.BNAME as 'BRAND NAME',category.CNAME as 'CATEGORY' from brand inner join category on brand.CID=category.CID;";
            SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void brand_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            TxtBID.Text = "0";
            ComboBoxCategory.SelectedIndex = -1;
            txtBname.Text = "";

        }

        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtBID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            ComboBoxCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtBID.Text != "0")
            {
                if(MessageBox.Show("are you sure to delete","Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Error)==DialogResult.OK)
                { 

                    try
                    {
                        string s = "Delete from brand where bid=" + TxtBID.Text;
                        string p = "Delete from product where bid=" + TxtBID.Text;
                        o.con.Open();
                        SqlCommand cms = new SqlCommand(p, o.con);
                        SqlCommand cmd = new SqlCommand(s, o.con);
                        cmd.ExecuteNonQuery();
                        cms.ExecuteNonQuery();
                        btnClear_Click(sender, e);
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

        }
    }
}
