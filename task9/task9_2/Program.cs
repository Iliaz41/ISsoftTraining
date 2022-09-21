using System;

namespace task9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppContext();
            foreach (var item in context.Trainings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------");
            foreach (var item in context.Employees)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------");
            foreach (var item in context.Vacations)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------");
            foreach (var item in context.EmployeeVacations)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------");
            Helper.CheckDurationAndShow(context);
            Console.WriteLine("-----------------------");
            Helper.AmountOfEmployees(context);
        }
    }
}
