using OnlineLearningPlatform.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineLearningPlatform.Models
{
    public class Enrollment
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime EnrolledAt { get; set; }

        public decimal ProgressPercentage { get; set; }

        public EnrollmentStatus Status { get; set; }

        public decimal? FinalGrade { get; set; }
    }
}
