using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;

namespace OnlineLearningPlatform.Configurations;

public class StudentConfiguration
    : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.FullName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasIndex(s => s.Email)
            .IsUnique();

        builder.Property(s => s.DateOfBirth)
            .IsRequired();
    }
}