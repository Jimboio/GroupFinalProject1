public class Hobby
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public bool IsOutdoor { get; set; }
}

public class FavoriteBreakfastFood
{
    public int Id { get; set; }
    public string FoodName { get; set; }
    public string CuisineType { get; set; }
    public bool IsSweet { get; set; }
    public int Calories { get; set; }
}
