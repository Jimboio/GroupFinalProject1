using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NicklasWAProject.Data;
using NicklasWAProject.Models;

namespace NicklasWAProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteBreakfastFoodsController : ControllerBase
    {
        private readonly TeamDbContext _context;

        public FavoriteBreakfastFoodsController(TeamDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteBreakfastFood>>> GetFavoriteBreakfastFoods(int? id)
        {
            if (!id.HasValue || id == 0)
            {
                return await _context.FavoriteBreakfastFoods.Take(5).ToListAsync();
            }

            var breakfastFood = await _context.FavoriteBreakfastFoods.FindAsync(id);
            if (breakfastFood == null)
            {
                return NotFound();
            }

            return Ok(breakfastFood);
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteBreakfastFood>> PostFavoriteBreakfastFood(FavoriteBreakfastFood breakfastFood)
        {
            _context.FavoriteBreakfastFoods.Add(breakfastFood);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFavoriteBreakfastFoods), new { id = breakfastFood.Id }, breakfastFood);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteBreakfastFood(int id, FavoriteBreakfastFood breakfastFood)
        {
            if (id != breakfastFood.Id)
            {
                return BadRequest();
            }

            _context.Entry(breakfastFood).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteBreakfastFood(int id)
        {
            var breakfastFood = await _context.FavoriteBreakfastFoods.FindAsync(id);
            if (breakfastFood == null)
            {
                return NotFound();
            }

            _context.FavoriteBreakfastFoods.Remove(breakfastFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
