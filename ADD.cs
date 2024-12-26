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
    public partial class ADD : Form
    {
        private readonly SqlConnection conn;
        public ADD(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ADD_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title_book = textBox1.Text;
            string number = textBox2.Text;
            string checkQuery = "SELECT COUNT(*) FROM books WHERE title = @title";
            SqlCommand checkCommand = new SqlCommand(checkQuery, conn);
            
                checkCommand.Parameters.AddWithValue("@title", title_book);
                int count = (int)checkCommand.ExecuteScalar();
            if(count > 0)
            {
                string updateQuery = "UPDATE books SET number_of_additions = number_of_additions + @number WHERE title = @title";

                SqlCommand updateCommand = new SqlCommand(updateQuery, conn);

                updateCommand.Parameters.AddWithValue("@number", number);
                updateCommand.Parameters.AddWithValue("@title", title_book);
                updateCommand.ExecuteNonQuery();
            }
            else
            {
                string insertQuery = "INSERT INTO books (title , number_of_additions) VALUES (@title, @number)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, conn);
                
                    insertCommand.Parameters.AddWithValue("@title", title_book);
                    insertCommand.Parameters.AddWithValue("@number", number);
                    insertCommand.ExecuteNonQuery();
                
            }
            MessageBox.Show("Valid submition");
                
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
