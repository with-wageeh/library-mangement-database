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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace projrctdatabase
{
    public partial class Form2 : Form
    {
        private readonly SqlConnection conn;
        string g;
        public Form2(SqlConnection conn, string username)
        {
            InitializeComponent();
            g = username;
            this.conn = conn;
        }

        private void txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cur = txtbox.Text;
            string nested_query = "SELECT id FROM books WHERE title = @cur;";
            SqlCommand comand = new SqlCommand(nested_query, conn);
            comand.Parameters.AddWithValue("@cur", cur);


            int id_book = (int) comand.ExecuteScalar();
            string query = "SELECT COUNT(*) FROM booked WHERE book_id = @id_book;";
            SqlCommand comand2 = new SqlCommand(query, conn);
            comand2.Parameters.AddWithValue("@id_book", id_book);


            int ans = (int)comand2.ExecuteScalar();
            if (ans == 1)
            {
                string query2 = "DELETE FROM booked WHERE book_id = @id_book;";
                SqlCommand comand4 = new SqlCommand(query2, conn);
                comand4.Parameters.AddWithValue("@id_book", id_book);
                comand4.ExecuteNonQuery();

                string query3 = "UPDATE books SET number_of_additions = number_of_additions + 1 , booked = booked - 1 WHERE id = @id_book;";
                SqlCommand comand3 = new SqlCommand(query3, conn);
                comand3.Parameters.AddWithValue("@id_book", id_book);
                comand3.ExecuteNonQuery();
                MessageBox.Show("valid return");
            }
            else
            {
                MessageBox.Show("you don't have this book");
            }
            txtbox.Text = "";
        }
    }
}
