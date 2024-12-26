using Microsoft.Data.SqlClient;

namespace projrctdatabase
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private string connection_string = "Server=DESKTOP-NKRIGA5;Database=bob;Trusted_Connection=True;TrustServerCertificate=True;Connect Timeout=60;";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginUser form = new LoginUser(conn);
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(connection_string);
            conn.Open();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register reg = new Register(conn);
            reg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminprofile prof = new(conn);
            prof.ShowDialog();
        }
    }
}
