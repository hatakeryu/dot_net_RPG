using dot_net_RPG.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext: DbContext
    {
        public DataContext (DbContextOptions<DataContext> options): base(options){ }

        public DbSet<Character> Characters{get; set;}
    }
}