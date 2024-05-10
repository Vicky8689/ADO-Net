using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace SQLClintConnectionExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.Connection();
        }
        static void Connection()
        {
            //string cs = "Data Source=DESKTOP-N8RM81S\\SQLEXPRESS;Initial Catalog=swiggy;Integrated Security=true";
            //Data Source= db server name , Initial Catalog = databasename ,Integrated Security= true for sindeosauthontication
          
            
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            Console.WriteLine(cs);
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))   
                {
                    conn.Open();                  
                    if (conn.State == ConnectionState.Open)   //state property
                     {Console.WriteLine("connection succesfull");}              
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }




            //SqlConnection con = new SqlConnection(cs);
            //try
            //{
            //    con.Open();

            //    if (con.State == ConnectionState.Open)
            //    {
            //        Console.WriteLine("connection succesfull");
            //    }
            //    else
            //    {
            //        Console.WriteLine("connection not succesfull");
            //    }
            //}
            //catch (Exception ex) { Console.WriteLine(ex.Message); }
            //finally
            //{

            //con.Close();
            //}

        }


    }

}
