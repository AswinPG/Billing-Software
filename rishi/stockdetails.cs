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
    public partial class stockdetails : Form
    {
        public stockdetails()
        {
            InitializeComponent();
        }
        db o = new db();
        DataTable dt;
        void loadgrid()
        {
            string sql = "select product.PNAME as product,stock.QTY FROM stock inner join product on stock.PID=product.PID";
            SqlDataAdapter da = new SqlDataAdapter(sql, o.con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadgrid();
            textBox1.Text = "";
        }

        private void stockdetails_Load(object sender, EventArgs e)
        {
            loadgrid();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DataView dv = new DataView(dt);
                dv.RowFilter = "PRODUCT like '%" + textBox1.Text + "%'";
                dataGridView1.DataSource = dv;
            }
        }
    }
}
