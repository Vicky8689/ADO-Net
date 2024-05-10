using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCommandExampleNoneQuery
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

                    /*Execute sclare -----take multipal values and return single values --------------------*/            

                   // string query = $"select max(id) from customers";
                    string query = $"select * from customers where id=3";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    int maxsid = (int)cmd.ExecuteScalar();

                    Console.WriteLine("MAxsalary is  "+maxsid);


                    /*delete data by id ------------------------------------------------ */

                    //Console.WriteLine("Enter ID :");
                    //string uid = Console.ReadLine();


                    //string query = $"delete from customers where id='{uid}'";

                    //SqlCommand cmd = new SqlCommand(query, conn);
                    //conn.Open();
                    //cmd.ExecuteNonQuery();
                    //Console.WriteLine("happy data was deleted ");





                    /*update data --------------------------------------------------- */
                    ////-----------------------take data
                    //Console.WriteLine("Enter ID :");
                    //string uid = Console.ReadLine(); 
                    //Console.WriteLine("Enter name :");
                    //string uname = Console.ReadLine();

                    //Console.WriteLine("Enter city :");
                    //string ucity = Console.ReadLine();

                    ////----------------------create query
                    //string query = $"update customers set name = '{uname}',city = '{ucity}' where id='{uid}'";

                    ////-----------------------create commond object
                    //SqlCommand cmd = new SqlCommand(query, conn);
                    ////----------------------open connection
                    //conn.Open();
                    ////-----------------------execute none qury
                    //cmd.ExecuteNonQuery();

                    //Console.WriteLine("happy");




                    /*inserting data --------------------------------------------------- */

                    ////get data
                    //Console.WriteLine("Enter name :");
                    //string iname = Console.ReadLine();

                    //Console.WriteLine("Enter city :");
                    //string icity = Console.ReadLine();

                    ////create query
                    ////string qurey = "insert into customers(name,city) values(@name,@city)";
                    //string qurey = $"insert into customers(name,city) values('{iname}','{icity}')";

                    ////create commend object
                    //SqlCommand cmd = new SqlCommand(qurey, conn);

                    ////cmd.Parameters.AddWithValue("@name", iname);
                    ////cmd.Parameters.AddWithValue("@city", icity);

                    // conn.Open();


                    //int a = cmd.ExecuteNonQuery();

                    //if (a > 0)
                    //{
                    //    Console.WriteLine("data inserted succesfully ");
                    //}
                    //else { Console.WriteLine("data insertion faild"); }






                     SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine("ID = " + dr["id"] + " name = " + dr["name"] + "City = " + dr["city"]);
                    }

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
