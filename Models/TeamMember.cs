namespace NicklasWAProject.Models
{
    public class TeamMember
    {
        public int Id { get; set; } // Primary key
        
        public string FullName { get; set; } // The member's full name
        
        public DateTime Birthdate { get; set; } // Birthdate of the member
        
        public string CollegeProgram { get; set; } // The college program the member is enrolled in
        
        public string YearInProgram { get; set; } // The year or level in the program (e.g., Freshman, Sophomore, etc.)
    }
}
