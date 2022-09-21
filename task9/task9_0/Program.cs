using System;

namespace task9_0
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionHelper connect = new ConnectionHelper("Data Source=(local);Initial Catalog=Db;Integrated Security=True;TrustServerCertificate=True");
            connect.OpenConnection();
            var date1 = new DateTime(2015, 09, 05);
            var date2 = new DateTime(2015, 09, 29);
            Training training1 = new Training("Modern JavaScript", date1, date2, "");
            var date3 = new DateTime(2016, 04, 01);
            var date4 = new DateTime(2016, 04, 25);
            Training training2 = new Training("Modern JavaScript", date3, date4, "");
            connect.Insert(training1);
            connect.Insert(training2);
            Console.WriteLine("Done");
            connect.CloseConnection();
        }
    }
}
