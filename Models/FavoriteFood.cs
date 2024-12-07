namespace rowecoryfinalproj.Models
{
    public class FavoriteFood
    {
        public int Id { get; set; } // Primary Key
        public string FoodName { get; set; }
        public string CuisineType { get; set; }
        public bool IsSweet { get; set; }
        public int Calories { get; set; }
    }
}
