using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace SQLDataReaderExamples
{
    internal class Program
    {
        static void Connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    string qurey = "select * from customers";
                    SqlCommand cmd = new SqlCommand(qurey, conn);

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        //
                       Console.WriteLine("ID = " + dr["id"] + " name = " + dr["name"] + "City = " + dr["city"]);
                       // Console.WriteLine("ID = " + dr[0] + " name = " + dr[1] + " City = " + dr[2]);
                    }
                    dr.Close();

                }
            }
            catch (SqlException ex) { Console.WriteLine(ex.Message); }
        }
        static void Main(string[] args)
        {
            Program.Connection();


        }
    }
}
