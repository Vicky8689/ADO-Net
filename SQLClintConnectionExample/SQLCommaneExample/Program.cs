using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace SQLCommaneExample
{
    internal class Program
    {
        static void Connection()
        {
            string cs  = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            try{
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string qurey = "select * from customers";
                    SqlCommand cmd = new SqlCommand(qurey,conn);

                    conn.Open();
                   
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        Console.WriteLine("ID = " + dr["id"] + " name = " + dr["name"] + "City = " + dr["city"]);
                    }

                }
            }
            catch(SqlException ex) { Console.WriteLine(ex.Message); }
        }
        static void Main(string[] args)
        {
            Program.Connection();



        }
    }
}
