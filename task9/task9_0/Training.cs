using System;

namespace task9_0
{
    public class Training
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public Training(string name, DateTime startDate, DateTime endDate, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }
    }
}
