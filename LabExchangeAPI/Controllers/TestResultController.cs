using Microsoft.AspNetCore.Mvc;

namespace LabExchangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestResultController : ControllerBase
    {
        private static readonly string[] TestResults = new[]
        {
        "Positive", "Negative", "Inconclusive"
    };

        private readonly ILogger<TestResultController> _logger;

        public TestResultController(ILogger<TestResultController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTestResult")]
        public IEnumerable<string> GetTestResult()
        {
            return Array.Empty<string>(); 
        }

        [HttpPost(Name = "PostTestResults")]
        public IEnumerable<string> PostTestResults()
        {
            return Array.Empty<string>();
        }

        [HttpPut(Name = "PutTestResult")]
        public IEnumerable<string> PutTestResult()
        {
            return Array.Empty<string>();
        }

        [HttpDelete(Name = "DeleteTestResult")]
        public IEnumerable<string> DeleteTestResult()
        {
            return Array.Empty<string>();
        }
    }
}