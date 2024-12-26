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
    public partial class profileuser : Form
    {
        private readonly SqlConnection conn;
        string g;
        public profileuser(SqlConnection conn, string username)
        {
            InitializeComponent();
            label1.Text = username;
            g = username;
            this.conn = conn;
        }

        private void profileuser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btbuy_Click(object sender, EventArgs e)
        {
            selectionbooks2 form = new(conn, g);

            form.ShowDialog();
        }

        private void btborrow_Click(object sender, EventArgs e)
        {
            Selectioinbooks form = new(conn, g);
            form.ShowDialog();
        }

        private void btmybooks_Click(object sender, EventArgs e)
        {
            viewbooks vb = new(conn, g);
        }

        private void btreturn_Click(object sender, EventArgs e)
        {
            Form2 fo = new(conn, g);
            fo.ShowDialog();
        }
    }
}
