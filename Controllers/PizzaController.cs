using Microsoft.AspNetCore.Mvc;
using ZetechWebAPI.Models;
using ZetechWebAPI.Services;

namespace ZetechWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        public PizzaController(ZetechDbContext dbContext, IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        // GET all action

        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> GetAll()
        {
            return _pizzaService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetPizza(int id){ 
            var pizza = _pizzaService.Get(id);

            if(pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            _pizzaService.Add(pizza);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = _pizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            _pizzaService.Update(pizza);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = _pizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            _pizzaService.Delete(id);

            return NoContent();
        }

        // GET by Id action

        // POST action

        // PUT action

        // DELETE action
    }
}
