using Microsoft.EntityFrameworkCore;
using proactivity.Domain.Entities;

namespace proactivity.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        
        public DbSet<Activity> Activities { get; set; }
    }
}