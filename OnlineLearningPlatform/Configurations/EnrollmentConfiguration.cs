using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;

namespace OnlineLearningPlatform.Configurations;

public class EnrollmentConfiguration
    : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollments", table =>
        {
            table.HasCheckConstraint(
                "CK_Enrollments_Progress",
                "[ProgressPercentage] >= 0 AND [ProgressPercentage] <= 100");

            table.HasCheckConstraint(
                "CK_Enrollments_Completed",
                "([Status] <> 2) OR ([ProgressPercentage] = 100)");
        });

        builder.HasKey(e => new
        {
            e.StudentId,
            e.CourseId
        });

        builder.Property(e => e.EnrolledAt)
            .IsRequired();

        builder.Property(e => e.ProgressPercentage)
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(e => e.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(e => e.FinalGrade)
            .HasPrecision(5, 2);

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Course>()
            .WithMany()
            .HasForeignKey(e => e.CourseId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}