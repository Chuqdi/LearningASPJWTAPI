
using LearningAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
