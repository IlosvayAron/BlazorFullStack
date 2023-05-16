using BlazorFullStack.Contract;
using BlazorLibraryServer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorLibraryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public MembersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> Get()
        {
            var members = await _dbContext.Members.ToListAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> Get(int id)
        {
            var member = await _dbContext.Members.FindAsync(id);

            if (member is null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Member member)
        {
            _dbContext.Members.Add(member);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            var existingMember = await _dbContext.Members.FindAsync(id);

            if (existingMember is null)
            {
                return NotFound();
            }

            existingMember.Name = member.Name;
            existingMember.Address = member.Address;
            existingMember.ReadingNumber = member.ReadingNumber;
            existingMember.DateOfBirth = member.DateOfBirth;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingMember = await _dbContext.Members.FindAsync(id);

            if (existingMember is null)
            {
                return NotFound();
            }

            _dbContext.Members.Remove(existingMember);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
