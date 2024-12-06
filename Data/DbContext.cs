using Microsoft.EntityFrameworkCore;
using NicklasWAProject.Models;  

namespace NicklasWAProject.Data  
{
    public class TeamDbContext : DbContext
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<FavoriteBreakfastFood> FavoriteBreakfastFoods { get; set; }
    }
}
