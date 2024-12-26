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
    public partial class Addtranslator : Form
    {
        private readonly SqlConnection conn;
        public Addtranslator(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text.Trim();
            string translatorName = textBox2.Text.Trim();
            string language = textBox3.Text.Trim();
            DateTime curDate = DateTime.Now;

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
                MessageBox.Show("The specified book does not exist.");
                return;
            }

            int translatorId = 0;
            string translatorCheckQuery = "SELECT id FROM translators WHERE name = @name;";
            SqlCommand translatorCheckCommand = new SqlCommand(translatorCheckQuery, conn);
            translatorCheckCommand.Parameters.AddWithValue("@name", translatorName);
            object translatorResult = translatorCheckCommand.ExecuteScalar();

            if (translatorResult != null)
            {
                translatorId = (int)translatorResult;
            }
            else
            {
                string insertTranslatorQuery = "INSERT INTO translators (name) OUTPUT INSERTED.id VALUES (@name)";
                SqlCommand insertTranslatorCommand = new SqlCommand(insertTranslatorQuery, conn);
                insertTranslatorCommand.Parameters.AddWithValue("@name", translatorName);
                translatorId = (int)insertTranslatorCommand.ExecuteScalar();
            }

            string insertTranslatedQuery = "INSERT INTO translated (book_id, translator_id, year, _language) VALUES (@bookId, @translatorId, @year, @language)";
            SqlCommand insertTranslatedCommand = new SqlCommand(insertTranslatedQuery, conn);
            insertTranslatedCommand.Parameters.AddWithValue("@bookId", bookId);
            insertTranslatedCommand.Parameters.AddWithValue("@translatorId", translatorId);
            insertTranslatedCommand.Parameters.AddWithValue("@year", curDate.Year);
            insertTranslatedCommand.Parameters.AddWithValue("@language", language);
            insertTranslatedCommand.ExecuteNonQuery();

            MessageBox.Show("Valid submission.");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
