using System.Xml.Linq;
using ZetechWebAPI.Models;

namespace ZetechWebAPI.Services
{
    public class BatchService: IBatchService
    {
        private readonly ZetechDbContext _dbContext;
        public List<Batch> Batches { get; }
        public BatchService(ZetechDbContext dbContext)
        {
            _dbContext = dbContext;
            Batches = _dbContext.Batch.ToList();
        }

        public List<BatchEntity> GetAll()
        {
            var batches = _dbContext.Batch.ToList();
            return (from batch in Batches
                    let courseEntity = new BatchEntity
                    {
                        BatchId = batch.BatchId,
                        BatchName = batch.BatchName,
                        Description = batch.Description,
                        DateCreated = batch.DateCreated,
                        Courses = _dbContext.Course.Where(c => c.BatchId == batch.BatchId).ToList()
                    }
                    select courseEntity).ToList();
        }

        public Batch? Get(int id) => Batches.FirstOrDefault(p => p.BatchId == id);

        public Batch Add(Batch batch)
        {
            if (batch == null) throw new ArgumentNullException(nameof(batch));
            _dbContext.Batch.Add(batch);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return batch;
        }

        public void Delete(Batch batch)
        {
            _dbContext.Batch.Remove(batch);

            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Update(Batch batch)
        {
            var index = Batches.FindIndex(p => p.BatchId == batch.BatchId);
            if (index == -1)
                return;

            Batches[index] = batch;
        }
    }
}
