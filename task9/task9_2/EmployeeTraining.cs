using System;

namespace task9_2
{
    public class EmployeeTraining
    {
        public Guid EmployeeId { get; set; }
        public Guid TrainingId { get; set; }

        public EmployeeTraining(Guid guidEmployee, Guid guidTraining)
        {
            EmployeeId = guidEmployee;
            TrainingId = guidTraining;
        }

        public EmployeeTraining()
        {

        }
    }
}
