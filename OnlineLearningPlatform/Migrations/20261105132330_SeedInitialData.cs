using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[]
                {
            "Id",
            "FullName",
            "Email",
            "Bio",
            "JoinedAt"
                },
                values: new object[]
                {
            1,
            "Ahmed Hassan",
            "ahmed.instructor@example.com",
            "Senior Software Instructor",
            new DateTime(2024, 1, 1)
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[]
                {
            "Id",
            "Name",
            "Description",
            "ParentCategoryId"
                },
                values: new object[,]
                {
            { 1, "Programming", "Programming Topics", null },
            { 2, "Backend", "Backend Development", 1 },
            { 3, "ASP.NET", "ASP.NET Courses", 2 },
            { 4, "Databases", "Database Fundamentals", 1 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[]
                {
            "Id",
            "FullName",
            "Email",
            "DateOfBirth"
                },
                values: new object[,]
                {
            {
                1,
                "Seed Student One",
                "seed.one@example.com",
                new DateTime(2001, 2, 10)
            },
            {
                2,
                "Seed Student Two",
                "seed.two@example.com",
                new DateTime(2002, 5, 20)
            }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[]
                {
            "Id",
            "Title",
            "Description",
            "Price",
            "Level",
            "IsPublished",
            "PublishedAt",
            "InstructorId",
            "CategoryId"
                },
                values: new object[,]
                {
            {
                1,
                "C# Fundamentals",
                "Introduction to C#",
                500m,
                1,
                true,
                new DateTime(2024, 2, 1),
                1,
                3
            },
            {
                2,
                "EF Core for Beginners",
                "EF Core Cascade Delete Demo",
                650m,
                1,
                true,
                new DateTime(2024, 3, 1),
                1,
                3
            }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[]
                {
            "StudentId",
            "CourseId",
            "EnrolledAt",
            "ProgressPercentage",
            "Status",
            "FinalGrade"
                },
                values: new object[,]
                {
            { 1, 1, new DateTime(2024, 2, 2), 40m, 1, null },
            { 2, 1, new DateTime(2024, 2, 3), 20m, 1, null },
            { 1, 2, new DateTime(2024, 3, 2), 10m, 1, null },
            { 2, 2, new DateTime(2024, 3, 3), 50m, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "StudentId", "CourseId" },
                keyValues: new object[,]
                {
            { 1, 1 },
            { 2, 1 },
            { 1, 2 },
            { 2, 2 }
                });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
