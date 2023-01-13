using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class DContext : DbContext
    {
        public DContext(DbContextOptions options) : base(options)   
        {

        }
        public DbSet<UserClass> Users { get; set; }
    }
}