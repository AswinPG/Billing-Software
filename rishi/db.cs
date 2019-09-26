using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace rishi
{
    class db
    {
        public SqlConnection con;
        public db()
        {
            
            
                try
                {
                string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\rishi\Documents\dbshop.mdf';Integrated Security=True;Connect Timeout=30";
                con = new SqlConnection(str);
                
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    
                }
            
        }
    }
}
