using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace projrctdatabase
{
    public partial class adminprofile : Form
    {
        private readonly SqlConnection conn;
        public adminprofile(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void adminprofile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ADD ad = new(conn);
            ad.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Addauthor ad = new(conn);
            ad.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Addtranslator ad = new(conn);
            ad.ShowDialog();
        }
    }
}
