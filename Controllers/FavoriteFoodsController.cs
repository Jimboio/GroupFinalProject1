using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rowecoryfinalproj.Models;

namespace rowecoryfinalproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteFoodsController : ControllerBase
    {
        private readonly DataContext _context;

        public FavoriteFoodsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteFood>>> GetFavoriteFoods(int? id)
        {
            if (id == null || id == 0)
                return await _context.FavoriteFoods.Take(5).ToListAsync();

            var favoriteFood = await _context.FavoriteFoods.FindAsync(id);
            if (favoriteFood == null)
                return NotFound();

            return new List<FavoriteFood> { favoriteFood };
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteFood>> PostFavoriteFood(FavoriteFood favoriteFood)
        {
            _context.FavoriteFoods.Add(favoriteFood);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFavoriteFoods", new { id = favoriteFood.Id }, favoriteFood);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteFood(int id, FavoriteFood favoriteFood)
        {
            if (id != favoriteFood.Id)
                return BadRequest();

            _context.Entry(favoriteFood).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteFood(int id)
        {
            var favoriteFood = await _context.FavoriteFoods.FindAsync(id);
            if (favoriteFood == null)
                return NotFound();

            _context.FavoriteFoods.Remove(favoriteFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
