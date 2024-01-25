using System.Runtime.Serialization;

namespace ZetechWebAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string? CourseName { get; set; }

        public string? Description { get; set; }

        public int? BatchId { get; set; }

        public DateTime? DateCreated { get; set; }

    }
}
