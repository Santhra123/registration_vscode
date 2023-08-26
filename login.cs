using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace trail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-K28T3TB\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=TrueData Source=DESKTOP-K28T3TB\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();

        }

        private void GetStudentsRecord()
        {
            
            SqlCommand cmd = new SqlCommand("select * from login",con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            recordview.DataSource = dt;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(IsValid())
            {

                SqlCommand cmd = new SqlCommand("insert into login values(@user_email,@password)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@user_email", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("information is saved in databse successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentsRecord();
            }
        }

        private bool IsValid()
        {
            if(username.Text==string.Empty)
            {
                MessageBox.Show("Student name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
