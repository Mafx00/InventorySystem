
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<Log> Logs { get; set; }

        public void Add(Batch batch) {       }

        internal object Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}