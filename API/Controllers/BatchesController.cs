using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatchesController
    {
        private readonly DataContext _context;

        public BatchesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Batch>> GetBatches()
        {
            var batches = _context.Batches.ToList();
            return batches;
        }        

        [HttpGet("{id}")]
        public ActionResult<Batch> GetBatch(int id)
        {
            return _context.Batches.Find(id);
        }

        [HttpGet("search/{name}")]
        public ActionResult<IEnumerable<Batch>> GetBatch(string name)
        {
            List<Batch> items = (List<Batch>)_context.Batches.Where(x => x.Name == name).ToList();
            return items;
        }

        [HttpPost("create")]
        public ActionResult<Batch> AddBatch(Batch batch)
        {   
            _context.Batches.Add(batch);
            _context.Logs.Add(new Log(_context.Logs.ToList().Count()+100, batch.Id, "created "+ batch.Name, DateTime.Now.ToString()));


            _context.SaveChanges();
            return batch;
        }

        [HttpPut("{id}")]
        public ActionResult<Batch> UpdateBatch(int id, Batch batch)
        {
          Batch batchtoUpdate= _context.Batches.Find(id);
          if(batchtoUpdate !is null)
          {
            batchtoUpdate.Name = batch.Name;
            batchtoUpdate.Quantity = batch.Quantity;
            batchtoUpdate.DeliveryDate = batch.DeliveryDate;
            batchtoUpdate.ExpirationDate = batch.ExpirationDate;
          }
            _context.SaveChanges();

            return batch;
        }

        [HttpDelete("delete/{id}")]
        public void DeleteBatch(int id)
        {
            Batch batch = _context.Batches.Find(id);
            _context.Logs.Add(new Log(_context.Logs.ToList().Count()+100, batch.Id, "removed "+ batch.Name, DateTime.Now.ToString()));
            var result = _context.Remove(batch);

            _context.SaveChanges();
        }

        [HttpGet("order")]
        public ActionResult<IEnumerable<Batch>> OrderBatchesByFreshness()
        {
            var sortedList = _context.Batches.OrderByDescending(x => x.ExpirationDate).ToList();
            return sortedList;
        }

        [HttpGet("history")]
        public ActionResult<IEnumerable<Log>> GetLogs()
        {
            var logs = _context.Logs.ToList();
            return logs;
        }  
    }
}