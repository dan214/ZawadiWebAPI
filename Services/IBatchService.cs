﻿using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public interface IBatchService
    {
        List<BatchEntity> GetAll();
        Batch? Get(int id);

        Batch Add(Batch batch);

        void Delete(Batch batch);
        void Update(Batch batch);
    }
}
