using Microsoft.AspNetCore.Mvc;

namespace LabExchangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestTypeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TestTypeController> _logger;

        public TestTypeController(ILogger<TestTypeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTestTypes")]
        public IEnumerable<string> GetTestTypes()
        {
            return Array.Empty<string>();
        }

        [HttpPost(Name = "PostTestTypes")]
        public IEnumerable<string> PostTestTypes()
        {
            return Array.Empty<string>();
        }

        [HttpDelete(Name = "DeleteTestTypes")]
        public IEnumerable<string> DeleteTestTypes()
        {
            return Array.Empty<string>();
        }
    }
}