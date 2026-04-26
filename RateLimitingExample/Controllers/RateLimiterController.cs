using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace RateLimitingExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateLimiterController : ControllerBase
    {
        [HttpGet("fixed")]
        [EnableRateLimiting("fixed")]
        public IActionResult Fixed()
        => Ok("Fixed Window Success");

        [HttpGet("sliding")]
        [EnableRateLimiting("sliding")]
        public IActionResult Sliding()
            => Ok("Sliding Window Success");

        [HttpGet("token")]
        [EnableRateLimiting("token")]
        public IActionResult Token()
            => Ok("Token Bucket Success");

        [HttpGet("concurrency")]
        [EnableRateLimiting("concurrency")]
        public async Task<IActionResult> Concurrency()
        {
            await Task.Delay(3000);
            return Ok("Concurrency Success");
        }

        [HttpGet("partitioned")]
        [EnableRateLimiting("partitioned")]
        public IActionResult Partitioned()
            => Ok("Partitioned Success");
    }
}
