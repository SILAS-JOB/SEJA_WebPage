using Microsoft.EntityFrameworkCore;
using SEJA_WepApp.Entities;

namespace SEJA_WepApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}
