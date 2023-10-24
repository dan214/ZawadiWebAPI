using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public class PizzaService: IPizzaService
    {
        private readonly ZetechDbContext _dbContext;
        public List<Pizza> Pizzas { get; }
        static int nextId = 3;
        public PizzaService(ZetechDbContext dbContext)
        {
            _dbContext = dbContext;
            Pizzas = _dbContext.Pizza.ToList();
        }

        public List<Pizza> GetAll() => Pizzas;

        public Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        public void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        public void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        public void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}
