using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace AppSimpleSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connecting_params = @"Server=DESKTOP-6CKK7D0\MYSQLEXPRESS;" +
                    "Database = MojeFinanse;Trusted_Connection = True;";
                SqlConnection sqlConnection = new SqlConnection(connecting_params);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT IDKlienta,Imie,Nazwisko,Inicjaly FROM Klienci", sqlConnection);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t",
                            reader[0], reader[1], reader[2], reader[3]));
                    }
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem z uruchomieniem kodu TSQL " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
