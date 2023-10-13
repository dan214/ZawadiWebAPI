using Microsoft.AspNetCore.Mvc;
using ZawadiWholesaleWebAPI.Models;
using ZawadiWholesaleWebAPI.Services;

namespace ZawadiWholesaleWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : Controller
    {
        public PizzaController()
        {
        }
        // GET all action

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() =>
    PizzaService.GetAll();

        [HttpGet("{id}")]
        public IActionResult GetPizza(int id){ 
            var pizza = PizzaService.Get(id);

            if(pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }

        // GET by Id action

        // POST action

        // PUT action

        // DELETE action
    }
}
