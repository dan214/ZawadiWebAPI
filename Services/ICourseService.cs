using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public interface ICourseService
    {
        List<CourseEntity> GetAll();
        Course? Get(int id);

        Course Add(Course Course);

        void Delete(Course course);
        void Update(Course course);
    }
}
