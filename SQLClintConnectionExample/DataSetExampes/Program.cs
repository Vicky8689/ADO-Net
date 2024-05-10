using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace DataSetExampes
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
                    string empqury = $"update employees set firstname = 'vicky' where Employeeid=1";
                    string stdqury = "select * from Students";

                    SqlDataAdapter sda_1 = new SqlDataAdapter(empqury,conn);
                    SqlDataAdapter sda_2 = new SqlDataAdapter(stdqury,conn);

                    DataTable empt = new DataTable();
                    DataTable stdt = new DataTable();

                    sda_1.Fill(empt);
                    sda_1.Update(empt);

                    sda_2.Fill(stdt);

                    DataSet ds = new DataSet();

                    ds.Tables.Add(empt);
                   ds.Tables.Add(stdt);



                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        Console.WriteLine(row[0] + "  " + row[1] + "  " + row[2] + "  " + row[3]);
                    }










                    //string query = "spGetEmployees";

                    //SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    //adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //DataSet ds = new DataSet();
                    //adapter.Fill(ds);


                    //foreach (DataRow row in ds.Tables[0].Rows)
                    //{
                    //    Console.WriteLine(row[0]+"  " + row[1]+"  " + row[2]+"  " + row[3]);
                    //}
                    //Console.WriteLine("------------------------------------------------------------------------------------");
                    //foreach (DataRow row in ds.Tables[1].Rows)
                    //{
                    //    Console.WriteLine(row[0] + "  " + row[1] + "  " + row[2] + "  " + row[3]);
                    //}


                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        static void Main(string[] args)
        {
            Program.Connection();

        }
    }
}
