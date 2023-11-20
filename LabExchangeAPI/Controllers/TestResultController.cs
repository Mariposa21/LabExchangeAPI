using LabExchangeAPI.LabExchangeDatabase;
using LabExchangeAPI.LogicLayer;
using LabExchangeAPI.LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabExchangeAPI.Controllers
{
    [ApiController]
    [Route("TestResult")]
    public class TestResultController : ControllerBase
    {
        private readonly ILogger<TestResultController> _logger;
        private TestResultLogic _logicLayer; 

        public TestResultController(ILogger<TestResultController> logger, 
            LabExchangeDatabaseContext dbContext)
        {
            _logger = logger;
            _logicLayer = new TestResultLogic(dbContext);
        }

        [HttpGet("{TestResultId}", Name = "GetTestResult")]
        public async Task<TestResult> GetTestResult([FromRoute] int TestResultId)
        {
            TestResult testResult = await _logicLayer.GetTestResultAsync(TestResultId);
            return testResult; 
        }

        [HttpPost(Name = "PostTestResults")]
        public async Task<IActionResult> PostTestResults([FromBody] List<TestResult> testResults)
        {
            await _logicLayer.PostTestResultsAsync(testResults);
            return Ok();
        }

        
        [HttpDelete(Name = "DeleteTestResult")]
        public async Task<IActionResult> DeleteTestResult([FromBody] List<int> testResultIds)
        {
            await _logicLayer.DeleteTestResultsAsync(testResultIds);
            return Ok();
        }
    }
}