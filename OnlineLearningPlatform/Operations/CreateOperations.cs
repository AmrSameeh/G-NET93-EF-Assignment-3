using OnlineLearningPlatform.Data;
using OnlineLearningPlatform.Models;
using OnlineLearningPlatform.Models.Enums;

namespace OnlineLearningPlatform.Operations;

public static class CreateOperations
{
    public static void AddInstructor()
    {
        using var db = new AppDbContext();

        var instructor = new Instructor
        {
            FullName = "New Instructor",
            Email = "new.instructor@example.com",
            Bio = "Experienced C# Instructor",
            JoinedAt = DateTime.UtcNow
        };

        bool exists = db.Instructors.Any(
            i => i.Email == instructor.Email);

        if (exists)
        {
            Console.WriteLine("Instructor already exists.");
            return;
        }

        db.Instructors.Add(instructor);

        db.SaveChanges();

        Console.WriteLine(
            $"Instructor added successfully. ID: {instructor.Id}");
    }

    public static void AddCourse()
    {
        using var db = new AppDbContext();

        int instructorId = SeedIds.Instructor;
        int categoryId = SeedIds.AspNetCategory;

        bool instructorExists = db.Instructors.Any(
            i => i.Id == instructorId);

        if (!instructorExists)
        {
            Console.WriteLine("Instructor does not exist.");
            return;
        }

        bool categoryExists = db.Categories.Any(
            c => c.Id == categoryId);

        if (!categoryExists)
        {
            Console.WriteLine("Category does not exist.");
            return;
        }

        var course = new Course
        {
            Title = "ASP.NET Core Fundamentals - New",
            Description = "Learn ASP.NET Core",
            Price = 7500m,
            Level = CourseLevel.Beginner,
            IsPublished = false,
            PublishedAt = null,

            InstructorId = instructorId,
            CategoryId = categoryId
        };
        
        db.Courses.Add(course);

        db.SaveChanges();

        Console.WriteLine(
            $"Course added successfully. ID: {course.Id}");
    }

    public static void AddSeveralStudents()
    {
        using var db = new AppDbContext();

        var students = new List<Student>
        {
            new Student
            {
                FullName = "Omar Ali",
                Email = "omar.ali@example.com",
                DateOfBirth = new DateTime(2002, 4, 10)
            },

            new Student
            {
                FullName = "Mariam Ahmed",
                Email = "mariam.ahmed@example.com",
                DateOfBirth = new DateTime(2001, 8, 21)
            },

            new Student
            {
                FullName = "Youssef Samir",
                Email = "youssef.samir@example.com",
                DateOfBirth = new DateTime(2003, 1, 15)
            }
        };

        var emails = students.Select(s => s.Email).ToList();

        var existingEmails = db.Students
            .Where(s => emails.Contains(s.Email))
            .Select(s => s.Email)
            .ToList();

        students = students
            .Where(s => !existingEmails.Contains(s.Email))
            .ToList();

        if (students.Count == 0)
        {
            Console.WriteLine("All sample students already exist.");
            return;
        }

        db.Students.AddRange(students);

        db.SaveChanges();

        foreach (var student in students)
        {
            Console.WriteLine(
                $"Student: {student.FullName}, ID: {student.Id}");
        }
    }

    public static void EnrollStudent()
    {
        using var db = new AppDbContext();

        var student = db.Students.FirstOrDefault(
            s => s.Email == "omar.ali@example.com");

        int courseId = SeedIds.PublishedCourse;

        if (student == null)
        {
            Console.WriteLine("Student does not exist.");
            return;
        }

        var course = db.Courses.Find(courseId);

        if (course == null)
        {
            Console.WriteLine("Course does not exist.");
            return;
        }

        if (!course.IsPublished)
        {
            Console.WriteLine(
                "Enrollment refused: Course is not published.");
            return;
        }

        bool alreadyEnrolled = db.Enrollments.Any(
            e => e.StudentId == student.Id &&
                 e.CourseId == courseId);

        if (alreadyEnrolled)
        {
            Console.WriteLine(
                "Student is already enrolled in this course.");
            return;
        }

        var enrollment = new Enrollment
        {
            StudentId = student.Id,
            CourseId = courseId,

            EnrolledAt = DateTime.UtcNow,

            ProgressPercentage = 0,

            Status = EnrollmentStatus.Active,

            FinalGrade = null
        };

        db.Enrollments.Add(enrollment);

        db.SaveChanges();

        Console.WriteLine(
            "Student enrolled successfully.");
    }
}