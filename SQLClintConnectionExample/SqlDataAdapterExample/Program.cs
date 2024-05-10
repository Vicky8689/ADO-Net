using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace SqlDataAdapterExample
{
    
    internal class Program
    {
        static void Connection()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);

            string qurey = "select * from customers";
            //SqlCommand cmd = new SqlCommand(qurey, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(qurey,conn);

            DataSet ds = new DataSet();

            adapter.Fill(ds);      //retrun int
            

            //get data
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine($"{row["id"]}  {row["name"]}");
            }

        }
        static void Main(string[] args)
        {
            Program.Connection();
           
        }
    }
}
