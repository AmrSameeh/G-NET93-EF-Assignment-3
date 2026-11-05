using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;

namespace OnlineLearningPlatform.Configurations;

public class CourseConfiguration
    : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses", table =>
        {
            table.HasCheckConstraint(
                "CK_Courses_Price",
                "[Price] >= 0");

            table.HasCheckConstraint(
                "CK_Courses_PublishedDate",
                "([IsPublished] = 0 AND [PublishedAt] IS NULL) OR ([IsPublished] = 1 AND [PublishedAt] IS NOT NULL)");
        });

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .HasMaxLength(2000);

        builder.Property(c => c.Price)
            .HasPrecision(10, 2);

        builder.Property(c => c.Level)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(c => c.IsPublished)
            .IsRequired();

        builder.Property(c => c.PublishedAt);

        builder.HasOne<Instructor>()
            .WithMany()
            .HasForeignKey(c => c.InstructorId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(c => c.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}