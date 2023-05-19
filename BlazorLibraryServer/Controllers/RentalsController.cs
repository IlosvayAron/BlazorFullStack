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

        [HttpGet("{inventoryNumber}")]
        public async Task<ActionResult<Rental>> GetRentalsByInventoryNumber(int inventoryNumber)
        {
            var rental = await _dbContext.Rentals.Where(x => x.InventoryNumber == inventoryNumber).FirstOrDefaultAsync();

            if (rental is null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpGet("member/{readingNumber}")]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentalsByreadingNumber(int readingNumber)
        {
            var rental = await _dbContext.Rentals.Where(x => x.ReadingNumber == readingNumber).ToListAsync();

            if (rental is null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rental rental)
        {
            if (rental.ReturnDeadline <= rental.RentalTime)
            {
                return BadRequest("The Return Deadline must be a date later than the Rental Time.");
            }

            _dbContext.Rentals.Add(rental);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Rental rental)
        {
            if (id != rental.Id)
            {
                return BadRequest("Rental with this ID do not exist.");
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
