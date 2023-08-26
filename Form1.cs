using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Registration
{
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
            User_state.Items.Add("Kerala");
            User_state.Items.Add("Karnataka");
            User_state.Items.Add("Tamilnadu");
            User_city.Items.Add("Angamaly");
            User_city.Items.Add("Aluva");
            User_city.Items.Add("Kalady");
            User_city.Items.Add("Bengaluru");
            User_city.Items.Add("Mysoor");
            User_city.Items.Add("Chennai");
            User_city.Items.Add("Salem");

        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-63KI9KR\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
        public int id;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GetAllRecords()
        {

            SqlCommand cmd = new SqlCommand("select * from Registration", con);
            DataTable dt = new DataTable();
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            recordview.DataSource = dt;

        }


        private void create_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {

                SqlCommand cmd = new SqlCommand("insert into registration(First_name,Last_name,Date_of_birth,Age,Email_id,User_address,Phone,User_state,User_city,User_username,User_password) values(@First_name,@Last_name,@Date_of_birth,@Age,@Email_id,@User_address,@Phone,@User_state,@User_city,@User_username,@User_password)", con);
                DateTime selectedDate = date_of_birth.Value;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@First_name", first_name.Text);
                cmd.Parameters.AddWithValue("@Last_name", last_name.Text);
                cmd.Parameters.AddWithValue("@Date_of_birth", selectedDate);
                cmd.Parameters.AddWithValue("@age", age.Text);
                cmd.Parameters.AddWithValue("@Email_id", email_id.Text);
                cmd.Parameters.AddWithValue("@User_address", user_address.Text);
                cmd.Parameters.AddWithValue("@Phone", phone.Text);
                cmd.Parameters.AddWithValue("@User_state", User_state.Text);
                cmd.Parameters.AddWithValue("@User_city", User_city.Text);
                cmd.Parameters.AddWithValue("@User_username", user_username.Text);
                cmd.Parameters.AddWithValue("@User_password", user_password.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("information is saved in databse successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAllRecords();
            }
        }

        private bool IsValid()
        {
            if (first_name.Text == string.Empty)
            {
                MessageBox.Show("First name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (last_name.Text == string.Empty)
            {
                MessageBox.Show("Last name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (email_id.Text == string.Empty)
            {
                MessageBox.Show("Email id is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (phone.Text == string.Empty)
            {
                MessageBox.Show("Phone number is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void clear_function()
        {
            first_name.Clear();
            last_name.Clear();
            email_id.Clear();
            phone.Clear();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE Registration SET First_name=@First_name,Last_name=@Last_name," +
                    "Date_of_birth=@Date_of_birth,Age=@age,Email_id=@Email_id,User_address=@User_address,Phone=@Phone," +
                    "User_state=@User_state,User_city=@User_city,User_username=@User_username,User_password=@User_password WHERE PK_Id=@id", con);
                DateTime selectedDate = date_of_birth.Value;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@First_name", first_name.Text);
                cmd.Parameters.AddWithValue("@Last_name", last_name.Text);
                cmd.Parameters.AddWithValue("@Date_of_birth", selectedDate);
                cmd.Parameters.AddWithValue("@age", age.Text);
                cmd.Parameters.AddWithValue("@Email_id", email_id.Text);
                cmd.Parameters.AddWithValue("@User_address", user_address.Text);
                cmd.Parameters.AddWithValue("@Phone", phone.Text);
                cmd.Parameters.AddWithValue("@User_state", User_state.Text);
                cmd.Parameters.AddWithValue("@User_city", User_city.Text);
                cmd.Parameters.AddWithValue("@User_username", user_username.Text);
                cmd.Parameters.AddWithValue("@User_password", user_password.Text);

                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("information is updated in databse successfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAllRecords();
            }
            else
            {
                MessageBox.Show("Please select a student to update his information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void recordview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            id = Convert.ToInt32(recordview.SelectedRows[0].Cells[0].Value);
            first_name.Text = recordview.SelectedRows[0].Cells[1].Value.ToString();
            last_name.Text = recordview.SelectedRows[0].Cells[2].Value.ToString();
            date_of_birth.Text = recordview.SelectedRows[0].Cells[3].Value.ToString();
            age.Text = recordview.SelectedRows[0].Cells[4].Value.ToString();
            email_id.Text = recordview.SelectedRows[0].Cells[5].Value.ToString();
            user_address.Text = recordview.SelectedRows[0].Cells[6].Value.ToString();
            phone.Text = recordview.SelectedRows[0].Cells[7].Value.ToString();
            User_state.Text = recordview.SelectedRows[0].Cells[8].Value.ToString();
            User_city.Text = recordview.SelectedRows[0].Cells[9].Value.ToString();
            user_username.Text = recordview.SelectedRows[0].Cells[10].Value.ToString();
            user_password.Text = recordview.SelectedRows[0].Cells[11].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void read_Click(object sender, EventArgs e)
        {
            GetAllRecords();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Registration WHERE PK_Id=@id", con);

                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("information is deleted from databse successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetAllRecords();
            }
            else
            {
                MessageBox.Show("Please select a student to delete his information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
    


