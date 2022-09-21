using System;

namespace task9_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionHelper connect = new ConnectionHelper("Data Source=(local);Initial Catalog=Db;Integrated Security=True;TrustServerCertificate=True");
            connect.OpenConnection();
            connect.Clear();
            foreach (var el in CsvHelper.ReadFile("data.csv"))
            {
                connect.Insert((el.Key, el.Value));
            }
            Console.WriteLine("Done");
            connect.CloseConnection();
        }
    }
}
