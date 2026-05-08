using _27_FrontToBackSqlConnectionn.Models;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnectionn.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider>Sliders { get; set; }

    }
}
