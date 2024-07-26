using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDbContext _db;

        public MoviesController(MovieDbContext db)
        {
            _db = db;
        }

        [HttpGet("Rating")]
        public async Task<IActionResult> GetRatings()
        {
            var ratings = await _db.Movies
                .Select(m => new { m.Title, m.Rating })
                .ToListAsync();
            return Ok(ratings);
        }
    }
}
