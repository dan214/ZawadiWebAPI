using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public interface IBatchService
    {
        List<Batch> GetAll();
        Batch? Get(int id);

        void Add(Batch batch);

        void Delete(int id);
        void Update(Batch batch);
    }
}
