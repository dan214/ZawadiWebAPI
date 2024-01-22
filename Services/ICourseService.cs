using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public interface ICourseService
    {
        List<Course> GetAll();
        Course? Get(int id);

        void Add(Course Course);

        void Delete(Course course);
        void Update(Course course);
    }
}
