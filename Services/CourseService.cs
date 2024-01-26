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

        public CourseEntity? Get(int id)
        {
            var course = _dbContext.Course.FirstOrDefault(p => p.CourseId == id);
            if (course == null) throw new ArgumentNullException(nameof(course));

            var courseEntity = new CourseEntity
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                Description = course.Description,
                DateCreated = course.DateCreated,
                Batch = _dbContext.Batch.FirstOrDefault(c => c.BatchId == course.BatchId)
            };

            return courseEntity;
        }

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

        public void Delete(int id)
        {
            var course = _dbContext.Course.FirstOrDefault(c => c.CourseId == id);
            if (course == null) throw new ArgumentNullException(nameof(course));

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

        public Course Update(Course course)
        {
            if (course == null) throw new ArgumentNullException(nameof(course));
            _dbContext.Course.Update(course);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return course;
        }
    }
}
