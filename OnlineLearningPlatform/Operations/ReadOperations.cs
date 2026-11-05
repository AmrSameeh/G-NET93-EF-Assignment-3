using OnlineLearningPlatform.Data;

namespace OnlineLearningPlatform.Operations;

public static class ReadOperations
{
    public static void FindCourse()
    {
        using var db = new AppDbContext();

        var courseById = db.Courses.Find(
            SeedIds.PublishedCourse);

        if (courseById == null)
        {
            Console.WriteLine("Course by ID not found.");
        }
        else
        {
            Console.WriteLine(
                $"Found by ID: {courseById.Title}");
        }

        var courseByTitle = db.Courses.FirstOrDefault(
            c => c.Title == "C# Fundamentals");

        if (courseByTitle == null)
        {
            Console.WriteLine("Course by title not found.");
        }
        else
        {
            Console.WriteLine(
                $"Found by Title: {courseByTitle.Title}");
        }
    }

    public static void FilterCourses()
    {
        using var db = new AppDbContext();

        decimal minPrice = 100;
        decimal maxPrice = 1500;

        var courses = db.Courses
            .Where(c =>
                c.Price >= minPrice &&
                c.Price <= maxPrice)

            .OrderByDescending(c => c.Price)

            .Select(c => new
            {
                c.Title,
                c.Level,
                c.Price
            })

            .ToList();

        Console.WriteLine("\nCourses by Price:");

        foreach (var course in courses)
        {
            Console.WriteLine(
                $"Title: {course.Title} | " +
                $"Level: {course.Level} | " +
                $"Price: {course.Price}");
        }
    }

    public static void PrintCategories()
    {
        using var db = new AppDbContext();

        int parentId = SeedIds.ProgrammingCategory;

        var subCategories = db.Categories
            .Where(c => c.ParentCategoryId == parentId)
            .ToList();

        Console.WriteLine("\nSub-Categories:");

        if (subCategories.Count == 0)
        {
            Console.WriteLine("No sub-categories found.");
        }

        foreach (var category in subCategories)
        {
            Console.WriteLine(category.Name);
        }

        var topCategories = db.Categories
            .Where(c => c.ParentCategoryId == null)
            .ToList();

        Console.WriteLine("\nTop-Level Categories:");

        foreach (var category in topCategories)
        {
            Console.WriteLine(category.Name);
        }
    }

    public static void PrintCourseRoster()
    {
        using var db = new AppDbContext();

        int courseId = SeedIds.PublishedCourse;

        bool courseExists = db.Courses.Any(
            c => c.Id == courseId);

        if (!courseExists)
        {
            Console.WriteLine("Course not found.");
            return;
        }
        var studentIds = db.Enrollments
            .Where(e => e.CourseId == courseId)
            .Select(e => e.StudentId)
            .ToList();

        Console.WriteLine(
            $"Number of Students: {studentIds.Count}");

        var students = db.Students
            .Where(s => studentIds.Contains(s.Id))
            .ToList();

        Console.WriteLine("\nCourse Roster:");

        foreach (var student in students)
        {
            Console.WriteLine(student.FullName);
        }
    }
}