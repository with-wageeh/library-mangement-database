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

namespace projrctdatabase;

public partial class LoginUser : Form
{
    private readonly SqlConnection conn;

    public LoginUser(SqlConnection conn)
    {
        InitializeComponent();
        this.conn = conn;
    }

    private void LoginUser_Load(object sender, EventArgs e)
    {

    }

    private void submtionbutton_Click(object sender, EventArgs e)
    {
        string username = usertextbox.Text;
        string password = passwordtextbox.Text;
        string query = "SELECT COUNT(*) FROM members WHERE user_name = @username AND password = @password AND state = 'USER'";

        SqlCommand comand = new SqlCommand(query, conn);
        comand.Parameters.AddWithValue("@username", username);
        comand.Parameters.AddWithValue("@password", password);

        int ans =  (int) comand.ExecuteScalar();
        if (ans == 1)
        {
            profileuser prof = new profileuser(conn, username);
            prof.ShowDialog(); 
        }
        else
        {
            MessageBox.Show("Invalid Username or Password");
        }

    }
}
