using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DataTableExample
{
    internal class Program
    {
       



        static void Main(string[] args)
        {
           

            try
            {
                DataTable employees = new DataTable("employees");

                //create columns
                DataColumn id = new DataColumn("id")
                {
                    Caption = "emp_id",
                    DataType = typeof(int),
                    AllowDBNull = false,
                    AutoIncrement = true,
                    AutoIncrementSeed = 1,
                    AutoIncrementStep = 1,
                 };
                employees.Columns.Add(id);
                //id.Caption = "emp_id";
                //id.DataType = typeof(int);
                //id.AllowDBNull = false;
                //employees.Columns.Add(id);

                DataColumn name = new DataColumn("name");
                name.Caption = "emp_name";
                name.DefaultValue = "Anonymuss";
                name.Unique = true;
                name.DataType = typeof(string);
                name.AllowDBNull = false;
                name.MaxLength = 50;
                employees.Columns.Add(name);

                DataColumn gender = new DataColumn("gender");
                gender.Caption = "emp_gender";
                gender.DataType = typeof(string);
                gender.AllowDBNull = false;
                gender.MaxLength = 10;
                employees.Columns.Add(gender);

                //adding rows

                DataRow r1 = employees.NewRow();
              //  r1["id"] = 1;
               // r1["name"] = "vicky";
                r1["gender"] = "MAle";
                employees.Rows.Add(r1);

                employees.Rows.Add(null,"mukesh","male");
                employees.Rows.Add(null, "jyoti","female");

                employees.PrimaryKey = new DataColumn[] { id };
               

                foreach(DataRow row in employees.Rows)
                {
                    Console.WriteLine(row["id"] +" " + row["name"]+" " + row[gender]);
                }
                

            }
            catch(Exception ex) { 
                Console.WriteLine(ex.Message);
            }




        }
    }
}
