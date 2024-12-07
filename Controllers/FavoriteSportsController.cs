using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rowecoryfinalproj.Models;

namespace rowecoryfinalproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteSportsController : ControllerBase
    {
        private readonly DataContext _context;

        public FavoriteSportsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteSport>>> GetFavoriteSports(int? id)
        {
            if (id == null || id == 0)
                return await _context.FavoriteSports.Take(5).ToListAsync();

            var favoriteSport = await _context.FavoriteSports.FindAsync(id);
            if (favoriteSport == null)
                return NotFound();

            return new List<FavoriteSport> { favoriteSport };
        }

        [HttpPost]
        public async Task<ActionResult<FavoriteSport>> PostFavoriteSport(FavoriteSport favoriteSport)
        {
            _context.FavoriteSports.Add(favoriteSport);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFavoriteSports", new { id = favoriteSport.Id }, favoriteSport);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteSport(int id, FavoriteSport favoriteSport)
        {
            if (id != favoriteSport.Id)
                return BadRequest();

            _context.Entry(favoriteSport).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteSport(int id)
        {
            var favoriteSport = await _context.FavoriteSports.FindAsync(id);
            if (favoriteSport == null)
                return NotFound();

            _context.FavoriteSports.Remove(favoriteSport);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
