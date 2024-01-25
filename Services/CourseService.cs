using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using ZetechWebAPI.Models;
using System.Linq;

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

        public List<CourseEntity> GetAll()
        {
            var courses = _dbContext.Course.ToList();
            return (from course in courses
                    let courseEntity = new CourseEntity
                    {
                        CourseId = course.CourseId,
                        CourseName = course.CourseName,
                        Description = course.Description,
                        DateCreated = course.DateCreated,
                        Batch = _dbContext.Batch.FirstOrDefault(c => c.BatchId == course.BatchId)
                    }
                    select courseEntity).ToList();
        }

        public Course? Get(int id) => Courses.FirstOrDefault(p => p.CourseId == id);

        public Course Add(Course course)
        {
            if(course == null) throw new ArgumentNullException(nameof(course));
            _dbContext.Course.Add(course);

            try
            {
                _dbContext.SaveChanges();
            }catch (Exception)
            {
                throw;
            }

            return course;
        }

        public void Delete(Course course)
        {
            _dbContext.Course.Remove(course);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
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
