using Models.Models;

namespace ContextAndMigrations.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(t => t.LastName)
            .IsRequired()
            .HasMaxLength(50);
    }
}
