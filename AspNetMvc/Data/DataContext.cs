using AspNetMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvc.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Yangilik> Yangiliklar { get; set; }
    }
}
