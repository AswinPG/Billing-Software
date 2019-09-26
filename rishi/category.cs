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
    public partial class category : Form
    {
        public category()
        {
            InitializeComponent();
        }
        db o = new db();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtcategory.Text == "")
            {
                MessageBox.Show("Please enter Category Name");
                txtcategory.Focus();
                return;
            }
            try
            {
                string s = "";
                if (txtcid.Text == "0")
                {
                    s = "insert into category(CNAME)values('" + txtcategory.Text+ "')";
                }
                else
                {
                    s = "update category set CNAME='" + txtcategory.Text + "'where CID='"+ txtcid.Text+"'";
                }
                o.con.Open();
                SqlCommand cmd = new SqlCommand(s, o.con);
                cmd.ExecuteNonQuery();
                btnClear_Click(sender, e);
                loadgrid();
                o.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadgrid()
            {
                string sql = "select CID,category.CNAME as 'category' from category";
                SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
        }


        

        private void category_Load(object sender, EventArgs e)
        {
            loadgrid();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtcategory.Text = "";
            txtcid.Text = "0";
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtcid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtcategory.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtcid.Text != "0")
            {
                if (MessageBox.Show("are you sure to delete", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {

                    try
                    {
                        string s = "Delete from category where cid=" + txtcid.Text;

                        o.con.Open();
                        SqlCommand cmd = new SqlCommand(s, o.con);
                        cmd.ExecuteNonQuery();
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
