using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public interface ICourseService
    {
        List<CourseEntity> GetAll();
        CourseEntity? Get(int id);

        Course Add(Course Course);

        void Delete(int id);
        void Update(Course course);
    }
}
