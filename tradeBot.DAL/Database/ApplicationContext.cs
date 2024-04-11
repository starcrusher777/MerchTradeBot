using Microsoft.EntityFrameworkCore;
using tradeBot.DAL.Entities;

namespace tradeBot.DAL.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<OfferEntity> Offer { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<UserEntity> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=localhost;Database=tradeBot;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public bool Delete<T>(T record) where T : class
        {
            try
            {
                Get<T>().Remove(record);
                base.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public DbSet<T> Get<T>() where T : class
        {
            return base.Set<T>();
        }
        
        public int UpdateOrInsert<T>(T record) where T : class
        {
            var dbSet = Get<T>();

            if (dbSet.Any(x => x.Equals(record)))
            {
                dbSet.Update(record);
            }
            else
            {
                dbSet.Add(record);
            }

            return base.SaveChanges();
        }
        public Task<int> UpdateOrInsertAsync<T>(T record) where T : class
        { 
            return Task.FromResult<int>(UpdateOrInsert(record));
        }
    }
}