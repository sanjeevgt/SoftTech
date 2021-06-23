
using Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure
{
    public class DataContext : DbContext
    {
      
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<ProductCategory> ProductCategorys { get;set;}
    }
}