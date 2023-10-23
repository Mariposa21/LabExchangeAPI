using LabExchangeAPI.BusinessModels;
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
        public TestResult GetTestResult(string testResultId)
        {
            TestType testTypeMock1 = new TestType()
            {
                TestTypeId = 1,
                AbnormalValuesCritical = true,
                TestTypeName = "Pregnancy",
                IsValidTestType = true,
                TestTypeCategory = TestTypeCategory.Urine,
                TestTypeNormalValues = "Negative"
            };

            TestResult testResult = new TestResult()
            {
                Id = 1,
                VendorResultId = "1",
                VendorId = 1,
                FlagForReview = true,
                IsValidTestResult = true,
                PatientDateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddYears(-25)),
                PatientMedicalRecordNum = "M1234-5134",
                ResultGenerationDateTime = DateTime.Today.AddDays(-2),
                SubmissionDateTime = DateTime.Today.AddDays(-5),
                ResultTestType = testTypeMock1,
                TestResultShort = "Positive",
                TestResultNotes = null
            };
            return testResult; 
        }

        [HttpPost(Name = "PostTestResults")]
        public async Task<IActionResult> PostTestResults([FromBody] List<TestResult> testResults)
        {
            return Ok();
        }

        [HttpPut(Name = "PutTestResult")]
        public async Task<IActionResult> PutTestResult([FromBody] TestResult testResult)
        {
            return Ok();
        }

        [HttpDelete(Name = "DeleteTestResult")]
        public async Task<IActionResult> DeleteTestResult(string[] testResultIds)
        {
            foreach (string testResultId in testResultIds)
            {
                Console.WriteLine("Deleting " + testResultId.ToString());
            }
            return NoContent();
        }
    }
}