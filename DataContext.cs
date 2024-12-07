using Microsoft.EntityFrameworkCore;
using rowecoryfinalproj.Models;

namespace rowecoryfinalproj
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<FavoriteFood> FavoriteFoods { get; set; }
        public DbSet<FavoriteSport> FavoriteSports { get; set; }
    }
}
