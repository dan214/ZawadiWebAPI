using System.Runtime.Serialization;

namespace ZetechWebAPI.Models
{
    [DataContract]
    public class CourseEntity
    {
        [DataMember(Name = "courseId")]
        public int CourseId { get; set; }

        [DataMember(Name = "courseName")]
        public string? CourseName { get; set; }

        [DataMember(Name = "description")]
        public string? Description { get; set; }

        [DataMember(Name = "batch")]
        public Batch? Batch { get; set; }

        [DataMember(Name = "batchId")]
        public int? BatchId { get; set; }

        [DataMember(Name = "dateCreated")]
        public DateTime? DateCreated { get; set; }
    }
}
