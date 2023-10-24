using System.Xml.Linq;
using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public class CourseService: ICourseService
    {
        private readonly ZetechDbContext _dbContext;
        public List<Course> Courses { get; }
        public CourseService(ZetechDbContext dbContext)
        {
            _dbContext = dbContext;
            Courses = _dbContext.Course.ToList();
        }

        public List<Course> GetAll() => Courses;

        public Course? Get(int id) => Courses.FirstOrDefault(p => p.CourseId == id);

        public void Add(Course course)
        {
            Courses.Add(course);
        }

        public void Delete(int id)
        {
            var course = Get(id);
            if (course is null)
                return;

            Courses.Remove(course);
        }

        public void Update(Course course)
        {
            var index = Courses.FindIndex(p => p.CourseId == course.CourseId);
            if (index == -1)
                return;

            Courses[index] = course;
        }
    }
}
