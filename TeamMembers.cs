namespace Final_Project
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TeamMember
    {
        [Key] // Marks the primary key
        public int Id { get; set; } // Primary key

        [Required]
        public string FullName { get; set; }

        public DateTime Birthdate { get; set; }

        public string CollegeProgram { get; set; }

        public string YearInProgram { get; set; } // E.g., Freshman, Sophomore
    }
}