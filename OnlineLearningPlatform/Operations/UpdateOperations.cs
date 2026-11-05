using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models.Enums;

namespace OnlineLearningPlatform.Operations;

public static class UpdateOperations
{
    public static void ChangeCoursePrice()
    {
        using var db = new AppDbContext();

        var course = db.Courses.Find(
            SeedIds.PublishedCourse);

        if (course == null)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        course.Price = 899.99m;

        db.SaveChanges();

        Console.WriteLine(
            $"Course price updated to {course.Price}");
    }

    public static void UpdateEnrollmentProgress()
    {
        using var db = new AppDbContext();

        int studentId = SeedIds.SeedStudent1;
        int courseId = SeedIds.PublishedCourse;

        decimal newProgress = 100;

        if (newProgress < 0 || newProgress > 100)
        {
            Console.WriteLine(
                "Progress must be between 0 and 100.");

            return;
        }

        var enrollment = db.Enrollments.Find(
            studentId,
            courseId);

        if (enrollment == null)
        {
            Console.WriteLine("Enrollment not found.");
            return;
        }

        enrollment.ProgressPercentage = newProgress;

        if (newProgress == 100)
        {
            enrollment.Status = EnrollmentStatus.Completed;

            enrollment.FinalGrade ??= 95;
        }
        else if (enrollment.Status == EnrollmentStatus.Completed)
        {
            enrollment.Status = EnrollmentStatus.Active;
            enrollment.FinalGrade = null;
        }

        db.SaveChanges();

        Console.WriteLine(
            $"Progress updated: {enrollment.ProgressPercentage}%");

        Console.WriteLine(
            $"Status: {enrollment.Status}");
    }

    public static void PublishCourse()
    {
        using var db = new AppDbContext();

        var course = db.Courses.FirstOrDefault(
            c => c.Title == "ASP.NET Core Fundamentals - New");

        if (course == null)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        course.IsPublished = true;

        course.PublishedAt = DateTime.UtcNow;

        db.SaveChanges();

        Console.WriteLine(
            $"Course {course.Title} published successfully.");

        Console.WriteLine(
            $"Published At: {course.PublishedAt}");
    }
}