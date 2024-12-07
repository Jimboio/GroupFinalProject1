using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rowecoryfinalproj.Models;

namespace rowecoryfinalproj.Controllers
{
    // Controllers/TeamMembersController.cs
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly DataContext _context;

        public TeamMembersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers(int? id)
        {
            if (id == null || id == 0)
                return await _context.TeamMembers.Take(5).ToListAsync();

            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
                return NotFound();

            return new List<TeamMember> { teamMember };
        }

        [HttpPost]
        public async Task<ActionResult<TeamMember>> PostTeamMember(TeamMember teamMember)
        {
            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTeamMembers", new { id = teamMember.Id }, teamMember);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember(int id, TeamMember teamMember)
        {
            if (id != teamMember.Id)
                return BadRequest();

            _context.Entry(teamMember).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
                return NotFound();

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
