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
    public partial class Register : Form
    {
        private readonly SqlConnection conn;

        public Register(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            string pass = txtpass.Text;
            string ssn = txtssn.Text;
            string address = txtaddress.Text;
            string username = txtuser.Text;
            DateTime date = txtdate.Value;
            string query = "INSERT INTO members ( ssn , name , birth_date , user_name , password , address , state)" +
                " VALUES (@ssn , @name , @date , @username , @pass , @address , 'USER')";
            String query2 = "SELECT COUNT(*) FROM members WHERE user_name = @username AND password = @pass AND state = 'USER'";

            SqlCommand comand = new SqlCommand(query, conn);
            SqlCommand comand2 = new SqlCommand(query2, conn);
            comand.Parameters.AddWithValue("@username", username);
            comand.Parameters.AddWithValue("@pass", pass);
            comand.Parameters.AddWithValue("@name", name);
            comand.Parameters.AddWithValue("@date", date);
            comand.Parameters.AddWithValue("@address", address);
            comand.Parameters.AddWithValue("@ssn", ssn);
            comand2.Parameters.AddWithValue("@username", username);
            comand2.Parameters.AddWithValue("@pass", pass);
            int ans = (int) comand2.ExecuteScalar();
            if(ans == 1)
            {
                MessageBox.Show("Invalid username or password");

            }
            else
            {
                comand.ExecuteNonQuery();
                MessageBox.Show("valid submition");
                clearbutton.PerformClick();
               
            }
            
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            txtname.Text = txtpass.Text = txtssn.Text = txtaddress.Text = txtuser.Text = "";
            txtdate.Value = DateTime.Today;
        }
    }
}
