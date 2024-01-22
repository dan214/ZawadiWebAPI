using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZetechWebAPI.Models;
using ZetechWebAPI.Services;

namespace ZetechWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        // GET: CourseController
        public ActionResult<IEnumerable<Course>> Index()
        {
            return _courseService.GetAll();
        }

        [HttpGet("{id}")]
        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var course = _courseService.Get(id);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _courseService.Get(id);

            if (course == null)
            {
                return NotFound();
            }

            try
            {
                _courseService.Delete(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(course);
        }
        }
}
