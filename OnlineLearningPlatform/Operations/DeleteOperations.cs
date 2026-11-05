using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Data;

namespace OnlineLearningPlatform.Operations;

public static class DeleteOperations
{
    public static void UnenrollStudent()
    {
        using var db = new AppDbContext();

        int studentId = SeedIds.SeedStudent2;
        int courseId = SeedIds.PublishedCourse;

        var enrollment = db.Enrollments.Find(
            studentId,
            courseId);

        if (enrollment == null)
        {
            Console.WriteLine("Enrollment not found.");
            return;
        }

        db.Enrollments.Remove(enrollment);

        db.SaveChanges();

        Console.WriteLine(
            "Student unenrolled successfully.");
    }

    public static void TryDeleteParentCategory()
    {
        using var db = new AppDbContext();

        var category = db.Categories.Find(
            SeedIds.ProgrammingCategory);

        if (category == null)
        {
            Console.WriteLine("Category not found.");
            return;
        }

        db.Categories.Remove(category);

        try
        {
            db.SaveChanges();

            Console.WriteLine("Category deleted.");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(
                "Cannot delete category because it has sub-categories.");

            Console.WriteLine(
                $"Database Error: {ex.GetBaseException().Message}");

            db.Entry(category).State = EntityState.Unchanged;
        }
    }

    public static void SafeDeleteCategory()
    {
        using var db = new AppDbContext();

        int categoryId = SeedIds.DatabasesCategory;

        var category = db.Categories.Find(categoryId);

        if (category == null)
        {
            Console.WriteLine("Category not found.");
            return;
        }

        bool hasSubCategories = db.Categories.Any(
            c => c.ParentCategoryId == categoryId);

        if (hasSubCategories)
        {
            Console.WriteLine(
                "Cannot delete category: It has sub-categories.");

            return;
        }

        bool hasCourses = db.Courses.Any(
            c => c.CategoryId == categoryId);

        if (hasCourses)
        {
            Console.WriteLine(
                "Cannot delete category: Courses are assigned to it.");

            return;
        }

        db.Categories.Remove(category);

        db.SaveChanges();

        Console.WriteLine(
            "Category deleted safely.");
    }

    public static void DeleteCourseWithEnrollments()
    {
        using var db = new AppDbContext();

        int courseId = SeedIds.CourseToDelete;

        var course = db.Courses.Find(courseId);

        if (course == null)
        {
            Console.WriteLine("Course not found.");
            return;
        }
        int beforeCount = db.Enrollments
            .Count(e => e.CourseId == courseId);

        Console.WriteLine(
            $"Enrollments Before Delete: {beforeCount}");
        db.Courses.Remove(course);

        db.SaveChanges();

        int afterCount = db.Enrollments
            .Count(e => e.CourseId == courseId);

        Console.WriteLine(
            $"Enrollments After Delete: {afterCount}");


    }
}