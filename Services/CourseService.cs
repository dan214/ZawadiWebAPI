﻿using Microsoft.EntityFrameworkCore;
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
            Courses = _dbContext.Course.Include(c => c.Batch).ToList();
        }

        public List<Course> GetAll() => Courses;

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
