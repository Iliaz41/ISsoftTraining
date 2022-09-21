using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task9_2
{
    public class EmployeeVacationConfig : IEntityTypeConfiguration<EmployeeVacation>
    {
        public void Configure(EntityTypeBuilder<EmployeeVacation> builder)
        {
            builder.ToTable(nameof(EmployeeVacation));
            builder.HasNoKey();
            builder.Property(p => p.EmployeeId).HasColumnName("EmployeeId");
            builder.Property(p => p.VacationId).HasColumnName("VacationId");
        }
    }
}
