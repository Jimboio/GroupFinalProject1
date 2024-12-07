namespace rowecoryfinalproj.Models
{
    public class TeamMember
    {
        public int Id { get; set; } // Primary Key
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CollegeProgram { get; set; }
        public string YearInProgram { get; set; }  // Freshman, Sophomore, etc.
    }
}
