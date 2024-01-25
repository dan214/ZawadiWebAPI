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
        public ActionResult<IEnumerable<BatchEntity>> Index()
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

        [HttpPost]
        public IActionResult Create([FromBody] Batch batch)
        {
            if (batch == null)
            {
                return BadRequest("Invalid item data");
            }
            try
            {
                var addedBatch = _batchService.Add(batch);
                return CreatedAtRoute("DefaultApi", new { id = addedBatch.BatchId }, addedBatch);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var batch = _batchService.Get(id);

            if (batch == null)
            {
                return NotFound();
            }

            try
            {
                _batchService.Delete(batch);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(batch);
        }
    }
}
