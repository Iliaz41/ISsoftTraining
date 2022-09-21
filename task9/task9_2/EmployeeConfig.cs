using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task9_2
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee));
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Email).HasColumnName("Email");
            builder.Property(p => p.FirstName).HasColumnName("FirstName");
            builder.Property(p => p.LastName).HasColumnName("LastName");
        }
    }
}
