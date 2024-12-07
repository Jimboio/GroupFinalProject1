namespace rowecoryfinalproj.Models
{
    public class Hobby
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsOutdoor { get; set; }
    }
}
