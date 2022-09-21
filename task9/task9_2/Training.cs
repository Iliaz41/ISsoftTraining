using System;

namespace task9_2
{
    public class Training
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public Training(Guid id, string name, DateTime startDate, DateTime endDate, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

        public Training()
        {

        }

        public override string ToString() => $"{Name}: {StartDate}-{EndDate} {Description}";

    }
}
