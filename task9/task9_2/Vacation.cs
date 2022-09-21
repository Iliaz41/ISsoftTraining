using System;

namespace task9_2
{
    public class Vacation
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Vacation(DateTime startDate, DateTime endDate)
        {
            Id = Guid.NewGuid();
            StartDate = startDate;
            EndDate = endDate;
        }

        public Vacation()
        {

        }

        public override string ToString() => $"{StartDate}-{EndDate}";
    }
}
