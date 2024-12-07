namespace rowecoryfinalproj.Models
{
    public class FavoriteSport
    {
        public int Id { get; set; } // Primary Key
        public string SportName { get; set; }
        public string Position { get; set; }  // Shortstop for Baseball, Point Guard for Basketball, etc.
        public string Season { get; set; } // Spring, Summer, Fall, Winter
        public bool IsOutdoor { get; set; }
    }
}
