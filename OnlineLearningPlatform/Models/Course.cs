using OnlineLearningPlatform.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLearningPlatform.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public CourseLevel Level { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? PublishedAt { get; set; }

        public int InstructorId { get; set; }

        public int CategoryId { get; set; }
    }
}
