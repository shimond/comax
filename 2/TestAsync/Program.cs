using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TestAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MAIN 1 Started"); // 1
            _ = Function1();
            Console.WriteLine("MAIN 1 Completed"); // 3
            Console.ReadLine();
        }


        static async Task Function1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Function 1 Started {0}", i); //2
            }
            await Function2();
            Console.WriteLine("Function 1 Finished"); //7
        }

        static async Task Function2()
        {
            Console.WriteLine("Function 2 Started"); //4
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(  "Function 2 {0}", i); //5
                await Task.Delay(100);
            }
            Console.WriteLine("Function 2 completed"); //6



        }

        private static async Task TestSqlConcept()
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Users", sqlConnection);
            await sqlConnection.OpenAsync();
            var dataReader = await sqlCommand.ExecuteReaderAsync();
            while (await dataReader.ReadAsync())
            {
                var userId = dataReader.GetInt32(0);
                var userName = dataReader.GetString(1);
                Console.WriteLine($"User ID: {userId}, User Name: {userName}");
            }
            dataReader.Close();
            sqlConnection.Close();
        }
    }
}
