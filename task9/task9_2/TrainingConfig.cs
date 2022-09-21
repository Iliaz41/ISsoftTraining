using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace task9_2
{
    public class TrainingConfig : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.ToTable(nameof(Training));
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.StartDate).HasColumnName("StartDate");
            builder.Property(p => p.EndDate).HasColumnName("EndDate");
            builder.Property(p => p.Description).HasColumnName("Description");
        }
    }
}
