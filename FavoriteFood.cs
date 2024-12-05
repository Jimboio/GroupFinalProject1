namespace Final_Project
{
    using System.ComponentModel.DataAnnotations;

    public class FavoriteFood
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FoodName { get; set; }

        public string Cuisine { get; set; }
        public bool IsVegetarian { get; set; }
        public int Calories { get; set; }
    }

}
