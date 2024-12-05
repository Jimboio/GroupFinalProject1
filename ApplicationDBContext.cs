namespace Final_Project
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties represent your tables
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobby { get; set; }
        public DbSet<FavoriteFood> FavoriteFood { get; set; }
        public DbSet<OtherTable> OtherTables { get; set; }
    }
}