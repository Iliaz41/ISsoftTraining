using System;

namespace task9_2
{
    public class EmployeeVacation
    {
        public Guid EmployeeId { get; set; }
        public Guid VacationId { get; set; }

        public override string ToString() => $"{EmployeeId}-{VacationId}";
    }
}
