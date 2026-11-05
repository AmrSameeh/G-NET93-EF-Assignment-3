using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;

namespace OnlineLearningPlatform.Configurations;

public class InstructorConfiguration
    : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.FullName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.HasIndex(i => i.Email)
            .IsUnique();

        builder.Property(i => i.Bio)
            .HasMaxLength(1000);

        builder.Property(i => i.JoinedAt)
            .IsRequired();

        builder.HasMany<Course>()
            .WithOne()
            .HasForeignKey(c => c.InstructorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}