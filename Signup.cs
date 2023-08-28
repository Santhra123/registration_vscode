using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Registration
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
            
            User_state.Items.Add("Kerala");
            User_state.Items.Add("Karnataka");
            User_state.Items.Add("Tamilnadu");
            user_password.UseSystemPasswordChar = true;
            password1.UseSystemPasswordChar = true;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-63KI9KR\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {


                SqlCommand cmd = new SqlCommand("insert into registration(First_name,Last_name,Date_of_birth,Age,Email_id,User_address,Phone,User_state,User_city,User_username,User_password,Gender) values(@First_name,@Last_name,@Date_of_birth,@Age,@Email_id,@User_address,@Phone,@User_state,@User_city,@User_username,@User_password,@Gender)", con);
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
                if (male.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Male");

                }
                else if (female.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Female");
                }
                else if (other.Checked)
                {
                    cmd.Parameters.AddWithValue("@Gender", "Other");
                }
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("information is saved in databse successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
                InitializeComponent();
                clear_all();
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
            else if (date_of_birth.Text == string.Empty)
            {
                MessageBox.Show("Date of birth is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (User_state.Text == string.Empty)
            {
                MessageBox.Show("User state is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (User_city.Text == string.Empty)
            {
                MessageBox.Show("User city is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (user_address.Text == string.Empty)
            {
                MessageBox.Show("User address is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (user_username.Text == string.Empty)
            {
                MessageBox.Show("Username is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (user_password.Text == string.Empty)
            {
                MessageBox.Show("Password is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (male.Checked == false && female.Checked == false && other.Checked == false)
            {
                MessageBox.Show("Gender field is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (age.Text == string.Empty)
            {
                MessageBox.Show("Age is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (password1.Text == string.Empty)
            {
                MessageBox.Show("Confirm password is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void clear_all()
        {
            first_name.Clear();
            last_name.Clear();
            email_id.Clear();
            phone.Clear();
            age.Clear();
            User_city.Text = string.Empty;
            User_state.Text = string.Empty;
            User_city.Items.Clear();
            password1.Clear();
            user_address.Clear();
            user_username.Clear();
            user_password.Clear();
            female.Checked = false;
            male.Checked = false;
            other.Checked = false;

        }

       

        private void first_name_Validating(object sender, CancelEventArgs e)
        {
            if (first_name.Text == string.Empty)
            {
                MessageBox.Show("First name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                ValidateName();

            }
        }

        private void ValidateName()
        {
            string input = first_name.Text;
            if (!IsValidAlphabet(input))

            {
                MessageBox.Show("First name is not valid", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                first_name.Text = "";
            }
        }

        private bool IsValidAlphabet(string input)
        {
            string pattern = @"^[a-zA-Z]+$";
            return Regex.IsMatch(input, pattern);
        }

        private void last_name_Validating(object sender, CancelEventArgs e)
        {
            if (last_name.Text == string.Empty)
            {
                MessageBox.Show("Last name is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                ValidateLastName();

            }
        }

        private void ValidateLastName()
        {
            string input = last_name.Text;
            if (!IsValidAlphabet(input))

            {
                MessageBox.Show("Last name is not valid", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                last_name.Text = "";
            }

        }
    

        private void email_id_Validating(object sender, CancelEventArgs e)
        {
            if (email_id.Text == string.Empty)
            {
                MessageBox.Show("Email id is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                ValidateEmailId();

            }
        }

        private void ValidateEmailId()
        {
            string input = email_id.Text;
            if (!IsValidEmail(input))

            {
                MessageBox.Show("Email id is not valid", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                email_id.Text = "";
            }

        }

        private bool IsValidEmail(string input)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            return Regex.IsMatch(input, pattern);
        }

    

    private void date_of_birth_Validating(object sender, CancelEventArgs e)
        {
            DateTime birthdate = date_of_birth.Value;



            DateTime currentDate = DateTime.Now;
            if(birthdate>currentDate)
            {
                MessageBox.Show("Selected date is greater than current date", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void age_Validating(object sender, CancelEventArgs e)
        {
            if (age.Text == string.Empty)
            {
                MessageBox.Show("Age is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void phone_Validating(object sender, CancelEventArgs e)
        {
            if (phone.Text == string.Empty)
            {
                MessageBox.Show("Phone number is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Validatephone();

            }
        }

        private void Validatephone()
        {
            string input = phone.Text;
            if (!IsValidPhone(input))

            {
                MessageBox.Show("Phone number is not valid", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phone.Text = "";
            }
        }

        private bool IsValidPhone(string input)
        {
            string pattern = @"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$";

            return Regex.IsMatch(input, pattern);
        }

    

    private void User_state_Validating(object sender, CancelEventArgs e)
        {

        }

        private void user_address_Validating(object sender, CancelEventArgs e)
        {

        }

        private void User_city_Validating(object sender, CancelEventArgs e)
        {

        }

        private void user_username_Validating(object sender, CancelEventArgs e)
        {

            if (user_username.Text == string.Empty)
            {
                MessageBox.Show("Username is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Validateusername();

            }
        }

        private void Validateusername()
        {
            string input = user_username.Text;
            if (!IsValidusername(input))

            {
                MessageBox.Show("Username contains only alphabets and digits", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_username.Text = "";
            }
        }

        private bool IsValidusername(string input)
        {
            string pattern = @"^[a-zA-Z0-9_]+$";

            return Regex.IsMatch(input, pattern);
        }


        private void user_password_Validating(object sender, CancelEventArgs e)
        {
            if (user_password.Text == string.Empty)
            {
                MessageBox.Show("Password is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Validatepassword();

            }
        }

        private void Validatepassword()
        {
            string input = user_password.Text;
            if (!IsValidpassword(input))

            {
                MessageBox.Show("Password contains atleast one uppercase,digit & special character", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_password.Text = "";
            }
        }

        private bool IsValidpassword(string input)
        {
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";

            return Regex.IsMatch(input, pattern);
        }


    

    private void password1_Validating(object sender, CancelEventArgs e)
        {

            if (user_password.Text != password1.Text)
            {
                MessageBox.Show("Password and Confirm passwords are not matching", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password1.Text = "";
            }
        
    }

        private void User_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            User_city.Items.Clear();
            User_city.Text = string.Empty;

            // Populate city combo box based on selected state
            string selectedState = User_state.SelectedItem.ToString();
            if (selectedState == "Kerala")
            {
                User_city.Items.AddRange(new string[] { "Angamaly", "Aluva", "Kalady" });
            }
            else if (selectedState == "Karnataka")
            {
                User_city.Items.AddRange(new string[] { "Bengaluru", "Mysoor" });
            }
            else if (selectedState == "Tamilnadu")
            {
                User_city.Items.AddRange(new string[] { "Chennai", "Salem" });
            }
        }

        private void date_of_birth_ValueChanged(object sender, EventArgs e)
        {
            age.Clear();
            DateTime birthdate = date_of_birth.Value;



            DateTime currentDate = DateTime.Now;
            int age1 = currentDate.Year - birthdate.Year;

            if (birthdate > currentDate.AddYears(age1))
            {
                age1--;
            }
            age.Text = age1.ToString();
        }
    }
    }


