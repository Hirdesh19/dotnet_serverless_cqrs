using Microsoft.AspNetCore.Mvc;

namespace AWSServerless.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : BaseController
    {
        /// <summary>
        /// Gets the health check.
        /// </summary>
        /// <returns>The health check.</returns>
        [HttpGet]
        public IActionResult GetHealthCheck()
        {
            return GenerateResponse(StatusType.Success);
        }
    }
}