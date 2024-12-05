using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Final_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "TableData", "TeamMembers.txt");

        public TeamMembersController()
        {
            // Ensure the directory and file exist
            if (!Directory.Exists(Path.GetDirectoryName(_filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
            }

            if (!System.IO.File.Exists(_filePath))
            {
                System.IO.File.WriteAllText(_filePath, "[]"); // Initialize with an empty JSON array
            }
        }

        // GET: api/TeamMembers
        [HttpGet]
        public ActionResult<IEnumerable<TeamMember>> GetTeamMembers()
        {
            var teamMembers = ReadFromFile();
            return teamMembers.Take(5).ToList(); // Return the first 5 members
        }

        // GET: api/TeamMembers/{id?}
        [HttpGet("{id?}")]
        public ActionResult<IEnumerable<TeamMember>> GetTeamMember(int? id)
        {
            var teamMembers = ReadFromFile();

            if (id == null || id == 0)
            {
                return teamMembers.Take(5).ToList();
            }

            var teamMember = teamMembers.FirstOrDefault(tm => tm.Id == id.Value);

            if (teamMember == null)
            {
                return NotFound();
            }

            return new List<TeamMember> { teamMember };
        }

        // POST: api/TeamMembers
        [HttpPost]
        public ActionResult<TeamMember> PostTeamMember(TeamMember teamMember)
        {
            var teamMembers = ReadFromFile();

            teamMember.Id = teamMembers.Any() ? teamMembers.Max(tm => tm.Id) + 1 : 1; // Assign a new ID
            teamMembers.Add(teamMember);

            WriteToFile(teamMembers);

            return CreatedAtAction(nameof(GetTeamMember), new { id = teamMember.Id }, teamMember);
        }

        // PUT: api/TeamMembers/5
        [HttpPut("{id}")]
        public IActionResult PutTeamMember(int id, TeamMember teamMember)
        {
            var teamMembers = ReadFromFile();
            var existingMember = teamMembers.FirstOrDefault(tm => tm.Id == id);

            if (existingMember == null)
            {
                return NotFound();
            }

            // Update the existing member
            existingMember.FullName = teamMember.FullName;
            existingMember.Birthdate = teamMember.Birthdate;
            existingMember.CollegeProgram = teamMember.CollegeProgram;
            existingMember.YearInProgram = teamMember.YearInProgram;

            WriteToFile(teamMembers);

            return NoContent();
        }

        // DELETE: api/TeamMembers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTeamMember(int id)
        {
            var teamMembers = ReadFromFile();
            var teamMember = teamMembers.FirstOrDefault(tm => tm.Id == id);

            if (teamMember == null)
            {
                return NotFound();
            }

            teamMembers.Remove(teamMember);
            WriteToFile(teamMembers);

            return NoContent();
        }

        // Helper: Read data from file
        private List<TeamMember> ReadFromFile()
        {
            var json = System.IO.File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<TeamMember>>(json) ?? new List<TeamMember>();
        }

        // Helper: Write data to file
        private void WriteToFile(List<TeamMember> teamMembers)
        {
            var json = JsonConvert.SerializeObject(teamMembers, Formatting.Indented);
            System.IO.File.WriteAllText(_filePath, json);
        }
    }
}
