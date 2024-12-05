using System.ComponentModel.DataAnnotations;

namespace Final_Project
{
    public class OtherTable
    {
            
        [Key]
        public int Id { get; set; }

        [Required]
        public string HobbyName { get; set; }

        public string Description { get; set; }
        public int DifficultyLevel { get; set; } // Optional column
        public bool IsOutdoor { get; set; }
    }
}

