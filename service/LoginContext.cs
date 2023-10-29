using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Crud_ADO.service
{
    public class LoginContext
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public void Slogin(Login login)
        {
            SqlConnection con=new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("select * from student_tbl where id='"+ login.Password +"' and name='"+ login.UserName +"'", con);
            con.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {

            }


        }
    }
}