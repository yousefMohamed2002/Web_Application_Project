using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Web_Application_Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            string Quary = "SELECT * FROM Member WHERE UserName=@UserName and Password=@password";
            SqlCommand sqlCommand = new SqlCommand(Quary, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@UserName", UserName.Text);
            sqlCommand.Parameters.AddWithValue("@password", Password.Text);
            sqlConnection.Open();
            SqlDataReader sqlData ;
            sqlData = sqlCommand.ExecuteReader();
            if (sqlData.Read())
            {
                Response.Redirect("~/MemberHome.aspx");
            }
            else
            {
                txt.Text = "wronge UserName or Password";
            }
            sqlConnection.Close(); 


        }
    }
}