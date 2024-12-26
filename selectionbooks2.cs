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
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace projrctdatabase
{
    public partial class selectionbooks2 : Form
    {
        private readonly SqlConnection conn;
        string user;
        public selectionbooks2(SqlConnection conn, string username)
        {
            InitializeComponent();
            user = username;
            this.conn = conn;
        }

        private void selectionbooks2_Load(object sender, EventArgs e)
        {
            string query = "SELECT title from books WHERE number_of_additions > 0;";
            FILL(new SqlCommand(query, conn));
        }
        private void FILL(SqlCommand query)
        {
            var adaptor = new SqlDataAdapter(query);
            DataTable dataTable = new DataTable();
            adaptor.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
        }
        private void txtbox_TextChanged(object sender, EventArgs e)
        {
            string cur = txtbox.Text;
            string query = "SELECT title FROM books WHERE title LIKE @cur ;";
            SqlCommand comand = new SqlCommand(query, conn);
            comand.Parameters.AddWithValue("@cur", cur + '%');
            FILL(comand);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cur = txtbox.Text;
          

         
              
                string nested_query = "SELECT id FROM members WHERE user_name = @user;";
                SqlCommand comand = new SqlCommand(nested_query, conn);
                comand.Parameters.AddWithValue("@user", user);
                int id = (int)comand.ExecuteScalar();

                
                string nested_query2 = "SELECT id, number_of_additions FROM books WHERE title = @cur;";
                SqlCommand comand2 = new SqlCommand(nested_query2, conn);
                comand2.Parameters.AddWithValue("@cur", cur);
            int id_book = (int)comand2.ExecuteScalar();
            
                    
                            
                            DateTime cur_date = DateTime.Now;
                            string query = "INSERT INTO sold (member_id, book_id, date) VALUES (@id, @id_book, @cur_date);";
                            SqlCommand comand3 = new SqlCommand(query, conn);
                            comand3.Parameters.AddWithValue("@id", id);
                            comand3.Parameters.AddWithValue("@id_book", id_book);
                            comand3.Parameters.AddWithValue("@cur_date", cur_date);
                            comand3.ExecuteNonQuery();

                            string updateQuery = "UPDATE books SET number_of_additions = number_of_additions - 1, sold = sold + 1 WHERE id = @id_book;";
                            SqlCommand comand4 = new SqlCommand(updateQuery, conn);
                            comand4.Parameters.AddWithValue("@id_book", id_book);
                            comand4.ExecuteNonQuery();

                            MessageBox.Show("Valid submission");
                       
                       
               
                
            }
            
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            txtbox.Text = cellValue;
        }
    }
}
