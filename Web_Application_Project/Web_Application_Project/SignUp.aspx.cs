using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Application_Project
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";

            //2- create insert statement
            string insertData = "INSERT INTO Member VALUES(@UserName, @FirstName, @LastName, @Gender, @Email, @Phone, @Country, @Password,@Re_password)";

            //3- create sql command
            SqlCommand cmdInsert = new SqlCommand(insertData, connection);
            cmdInsert.Parameters.AddWithValue("@UserName", UserName.Text);
            cmdInsert.Parameters.AddWithValue("@FirstName", FName.Text);
            cmdInsert.Parameters.AddWithValue("@LastName", LName.Text);
            cmdInsert.Parameters.AddWithValue("@Gender", Gender.SelectedValue);
            cmdInsert.Parameters.AddWithValue("@Email", Email.Text);
            cmdInsert.Parameters.AddWithValue("@Phone", Phone.Text);
            cmdInsert.Parameters.AddWithValue("@Country", Country.SelectedValue);
            cmdInsert.Parameters.AddWithValue("@Password", Password.Text);
            cmdInsert.Parameters.AddWithValue("@Re_password",RePassword.Text);

            //4- open
            connection.Open();
            //5- execute
            cmdInsert.ExecuteNonQuery();
            //6- close
            connection.Close();

            MSG.Text = "Welcome, " + FName.Text + " " + LName.Text + " to Our System!";
        }
    }
    }
