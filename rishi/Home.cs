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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        db o = new db();
        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bRANDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(brand))
                {
                    f.Activate();
                    return;
                }
            }
            brand frm = new brand();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cATEGORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(category))
                {
                    f.Activate();
                    return;
                }
            }
            category frm = new category();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pRODUCTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(Product))
                {
                    f.Activate();
                    return;
                }
            }
            Product frm = new Product();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cUSTOMERSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(customer))
                {
                    f.Activate();
                    return;
                }
            }
            customer frm = new customer();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pURCHASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(purchase))
                {
                    f.Activate();
                    return;
                }
            }
            purchase frm = new purchase();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sTOCKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(stockdetails))
                {
                    f.Activate();
                    return;
                }
            }
            stockdetails frm = new stockdetails();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(Sales))
                {
                    f.Activate();
                    return;
                }
            }
            Sales frm = new Sales();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cHANGEPASSWORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(change))
                {
                    f.Activate();
                    return;
                }
            }
            change frm = new change();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
