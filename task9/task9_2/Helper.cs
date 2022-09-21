using System;

namespace task9_2
{
    public class Helper
    {
        public static void CheckDurationAndShow(AppContext context)
        {
            foreach (var item in context.Vacations)
            {
                if ((item.EndDate - item.StartDate).Duration().Days > 30)
                {
                    foreach (var element in context.EmployeeVacations)
                    {
                        if (item.Id == element.VacationId)
                        {
                            foreach (var el in context.Employees)
                            {
                                if (element.EmployeeId == el.Id)
                                {
                                    Console.WriteLine(el.FirstName + " " + el.LastName);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void AmountOfEmployees(AppContext context)
        {
            int counter = 0;
            bool flag = true;
            bool show = true;
            foreach (var training in context.Trainings)
            {
                counter = 0;
                foreach (var employee in context.Employees)
                {
                    flag = true;
                    foreach (var id in context.EmployeeVacations)
                    {
                        if (employee.Id == id.EmployeeId)
                        {
                            foreach (var element in context.Vacations)
                            {
                                if (id.VacationId == element.Id)
                                {
                                    if (IsInRange(training.StartDate, element.StartDate, element.EndDate) || IsInRange(training.EndDate, element.StartDate, element.EndDate))
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!flag)
                        {
                            break;
                        }
                    }
                    if (flag)
                    {
                        counter++;
                        //EmployeeTraining employeeTraining = new EmployeeTraining(employee.Id, training.Id);
                        //context.EmployeeTrainings.Add(employeeTraining);
                        //context.SaveChanges();
                    }
                }
                if (show)
                {
                    Console.WriteLine("Amount of employees on first training: " + counter);
                    show = false;
                }
                else
                {
                    Console.WriteLine("Amount of employees on second training: " + counter);
                }
            }
        }
                    

        private static bool IsInRange(DateTime dateToCheck, DateTime startDate, DateTime endDate)
        {
            return dateToCheck >= startDate && dateToCheck < endDate;
        }
    }
}
