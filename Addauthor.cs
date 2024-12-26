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
    public partial class Addauthor : Form
    {
        private readonly SqlConnection conn;
        public Addauthor(SqlConnection conn)
        {
            InitializeComponent(); 
            this.conn = conn;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string authorName = textBox2.Text;
            DateTime cur_date = dateTimePicker1.Value;
                int bookId = 0;
                string bookCheckQuery = "SELECT id FROM books WHERE title = @title;";
            SqlCommand bookCheckCommand = new SqlCommand(bookCheckQuery, conn);
                
                    bookCheckCommand.Parameters.AddWithValue("@title", title);
                    object result = bookCheckCommand.ExecuteScalar();

                    if (result != null)
                    {
                        bookId = (int)result; 
                    }
                    else
                    {
                        MessageBox.Show("the specified book does not exist");
                        return; 
                    }
                

                int authorId = 0;
                string authorCheckQuery = "SELECT id FROM authors WHERE name = @name;";
        SqlCommand authorCheckCommand = new SqlCommand(authorCheckQuery, conn);
                
                    authorCheckCommand.Parameters.AddWithValue("@name", authorName);
                    object authorResult = authorCheckCommand.ExecuteScalar();

                    if (authorResult != null)
                    {
                        authorId = (int)authorResult;    
                    }
                    else
                    {
                       
                        string insertAuthorQuery = "INSERT INTO authors (name) OUTPUT INSERTED.id VALUES (@name)";
                SqlCommand insertAuthorCommand = new SqlCommand(insertAuthorQuery, conn);
                        
                            insertAuthorCommand.Parameters.AddWithValue("@name", authorName);
                            authorId = (int)insertAuthorCommand.ExecuteScalar();   
                        
                    }
                

               
                string insertAuthoredQuery = "INSERT INTO authored (book_id, author_id, year) VALUES (@bookId, @authorId, @year)";
            SqlCommand insertAuthoredCommand = new SqlCommand(insertAuthoredQuery, conn);
               
                    insertAuthoredCommand.Parameters.AddWithValue("@bookId", bookId);
                    insertAuthoredCommand.Parameters.AddWithValue("@authorId", authorId);
                    insertAuthoredCommand.Parameters.AddWithValue("@year", cur_date.Year); // Assuming you want to store the current year  
                    insertAuthoredCommand.ExecuteNonQuery();
            MessageBox.Show("valid submition");

            }
    }
}
