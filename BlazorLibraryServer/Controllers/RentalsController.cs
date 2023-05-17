using BlazorFullStack.Contract;
using BlazorLibraryServer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorLibraryServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public RentalsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> Get()
        {
            var rentals = await _dbContext.Rentals.ToListAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> Get(int id)
        {
            var rental = await _dbContext.Rentals.FindAsync(id);

            if (rental is null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rental rental)
        {
            _dbContext.Rentals.Add(rental);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Rental rental)
        {
            if (id != rental.Id)
            {
                return BadRequest();
            }

            var existingRental = await _dbContext.Rentals.FindAsync(id);

            if (existingRental is null)
            {
                return NotFound();
            }

            existingRental.ReadingNumber = rental.ReadingNumber;
            existingRental.InventoryNumber = rental.InventoryNumber;
            existingRental.RentalTime = rental.RentalTime;
            existingRental.ReturnDeadline = rental.ReturnDeadline;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingRental = await _dbContext.Rentals.FindAsync(id);

            if (existingRental is null)
            {
                return NotFound();
            }

            _dbContext.Rentals.Remove(existingRental);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
