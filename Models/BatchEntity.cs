using System.Runtime.Serialization;

namespace ZetechWebAPI.Models
{
    [DataContract]
    public class BatchEntity
    {
        [DataMember(Name = "courseId")]
        public int BatchId { get; set; }

        [DataMember(Name = "courseName")]
        public string? BatchName { get; set; }

        [DataMember(Name = "description")]
        public string? Description { get; set; }

        [DataMember(Name = "batch")]
        public DateTime? DateCreated { get; set; }

        [DataMember(Name = "courses")]
        public List<Course>? Courses { get; set; }
    }
}
