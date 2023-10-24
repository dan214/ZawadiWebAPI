using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZetechWebAPI.Models;
using ZetechWebAPI.Services;

namespace ZetechWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BatchController : Controller
    {
        private readonly IBatchService _batchService;
        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }

        [HttpGet]
        // GET: BatchController
        public ActionResult<IEnumerable<Batch>> Index()
        {
            return _batchService.GetAll();
        }

        [HttpGet("{id}")]
        // GET: BatchController/Details/5
        public ActionResult Details(int id)
        {
            var course = _batchService.Get(id);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
    }
}
