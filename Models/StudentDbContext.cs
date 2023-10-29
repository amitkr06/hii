using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Crud_ADO.Models
{
    public class StudentDbContext
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        public List<Student> GetDetails()
        {
            List<Student> list = new List<Student>();
            SqlConnection con=new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("getDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                Student student = new Student();
                student.id = Convert.ToInt32(dr.GetValue(0).ToString());
                student.name= dr.GetValue(1).ToString();
                student.gender = dr.GetValue(2).ToString();
                student.city = dr.GetValue(3).ToString();
                student.age = Convert.ToInt32(dr.GetValue(4).ToString());

                list.Add(student);

            }
            return list;

        }

        public bool AddStudent(Student student)
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("addEmpolyee", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@city", student.city);
            cmd.Parameters.AddWithValue("@gender", student.gender);
            cmd.Parameters.AddWithValue("@age", student.age);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateStudent(Student student)
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("sp_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", student.id);
            cmd.Parameters.AddWithValue("@name", student.name);
            cmd.Parameters.AddWithValue("@city", student.city);
            cmd.Parameters.AddWithValue("@gender", student.gender);
            cmd.Parameters.AddWithValue("@age", student.age);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteStudent(int id) 
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("sp_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open() ;
            int i = cmd.ExecuteNonQuery();
            con.Close();


            if (i > 0)
            {
                return true;
            }
            else
            { return false;}



        }
    }
}