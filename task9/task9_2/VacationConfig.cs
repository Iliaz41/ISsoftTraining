using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task9_2
{
    public class VacationConfig : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> builder)
        {
            builder.ToTable(nameof(Vacation));
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.StartDate).HasColumnName("StartDate");
            builder.Property(p => p.EndDate).HasColumnName("EndDate");
        }
    }
}
