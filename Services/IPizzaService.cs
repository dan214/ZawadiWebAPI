﻿using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public interface IPizzaService
    {
        List<Pizza> GetAll();
        Pizza? Get(int id);

        void Add(Pizza pizza);

        void Delete(int id);
        void Update(Pizza pizza);

    }
}
