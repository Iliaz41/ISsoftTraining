using Microsoft.EntityFrameworkCore;

namespace task9_2
{
    public class AppContext : DbContext
    {
        private const string Connection = "Server=(local);Database=Db;Trusted_Connection=True;MultipleActiveResultSets=True";

        public DbSet<Training> Trainings { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Vacation> Vacations { get; set; }

        //public DbSet<EmployeeTraining> EmployeeTrainings { get; set; }

        public DbSet<EmployeeVacation> EmployeeVacations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrainingConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new VacationConfig());
            modelBuilder.ApplyConfiguration(new EmployeeVacationConfig());
            //modelBuilder.ApplyConfiguration(new EmployeeTrainingConfig());
        }
    }
}
