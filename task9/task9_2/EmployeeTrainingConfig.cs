using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task9_2
{
    public class EmployeeTrainingConfig : IEntityTypeConfiguration<EmployeeTraining>
    {
        public void Configure(EntityTypeBuilder<EmployeeTraining> builder)
        {
            builder.ToTable(nameof(Employee));
            builder.HasNoKey();
            builder.Property(p => p.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(p => p.TrainingId).HasColumnName("TrainingId");
        }
    }
}
