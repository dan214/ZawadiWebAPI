using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
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
            var courses = _courseService.GetAll();

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
            };

            var json = JsonSerializer.Serialize(courses, jsonOptions);

            return Ok(json);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Course course)
        {
            if (course == null)
            {
                return BadRequest("Invalid item data");
            }
            try
            {
                var addedCourse = _courseService.Add(course);
                return CreatedAtRoute("DefaultApi", new { id = addedCourse.CourseId }, addedCourse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
