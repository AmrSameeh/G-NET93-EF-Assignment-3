using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Models;
using OnlineLearningPlatform.Configurations;

namespace OnlineLearningPlatform.Data;

public class AppDbContext : DbContext
{
    public DbSet<Instructor> Instructors { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnConfiguring(
                DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=OnlineLearningPlatform;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(
            new InstructorConfiguration());

        modelBuilder.ApplyConfiguration(
            new CategoryConfiguration());

        modelBuilder.ApplyConfiguration(
            new CourseConfiguration());

        modelBuilder.ApplyConfiguration(
            new StudentConfiguration());

        modelBuilder.ApplyConfiguration(
            new EnrollmentConfiguration());
    }
}