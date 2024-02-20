using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCartController : ControllerBase
    {
        private readonly MovieCartService _movieCartService;

        public MovieCartController(MovieCartService movieCartService)
        {
            _movieCartService = movieCartService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var movies = await _movieCartService.GetMoviesAsync();
                return Ok(movies);
            }
            catch (TimeoutException)
            {
                return StatusCode(504, "Gateway Timeout - Unable to fetch movies from MoviesService.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An internal error occurred.");
            }
        }
    }
}
