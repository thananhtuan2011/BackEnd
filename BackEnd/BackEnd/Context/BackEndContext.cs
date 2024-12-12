using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BackEnd.Context
{
    public class BackEndContext: DbContext
    {
        public BackEndContext(DbContextOptions<BackEndContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Companies { get; set; }
    }
}
