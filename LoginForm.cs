using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Registration
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            password.UseSystemPasswordChar = true;

        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-63KI9KR\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");






        private void login_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select count(*) from registration where User_username=@user_username AND User_password=@user_password", con);

            con.Open();


            cmd.Parameters.AddWithValue("@user_username", username.Text);
            cmd.Parameters.AddWithValue("@user_password", password.Text);
            string dataToSend = username.Text;
            registration form = new registration(dataToSend);
            form.ShowDialog();
            int count = (int)cmd.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("login successfull", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                registration loginForm = new registration();
                loginForm.ShowDialog();
                this.Close();
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("Username or Password is missing!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            username.Clear();
            password.Clear();
            con.Close();
        }


        private void username_Leave_1(object sender, EventArgs e)
        {
            con.Open();
            if (username.Text == string.Empty)
            {
                MessageBox.Show("Username name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlCommand cmd = new SqlCommand("select count(*) from registration where User_username=@user_username", con);

                


                cmd.Parameters.AddWithValue("@user_username", username.Text);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {

                }
                else
                {
                    MessageBox.Show("Username is incorrect", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    username.Text = "";
                }

                
            }
            con.Close();
        }
        private void password_Leave(object sender, EventArgs e)
        {
            con.Open();
            if (password.Text == string.Empty)
            {
                MessageBox.Show("Password is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SqlCommand cmd = new SqlCommand("select count(*) from registration where User_password=@user_password", con);

               


                cmd.Parameters.AddWithValue("@user_password", password.Text);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {

                }
                else
                {
                    MessageBox.Show("Password is incorrect", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    password.Text = "";
                }


            }
            con.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Signup loginForm = new Signup();
            loginForm.ShowDialog();
            this.Close();
            InitializeComponent();
        }
    }
}

