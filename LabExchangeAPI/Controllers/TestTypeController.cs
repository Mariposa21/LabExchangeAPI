using LabExchangeAPI.BusinessModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabExchangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestTypeController : ControllerBase
    {

        private readonly ILogger<TestTypeController> _logger;

        public TestTypeController(ILogger<TestTypeController> logger)
        {
            _logger = logger;
        }


        [HttpGet("~/TestTypeCategories")]
        public IEnumerable<string> GetTestTypeCategories()
        {
            return Enum.GetNames(typeof(TestTypeCategory)); 
        }

        [HttpGet("~/TestTypes")]
        public IEnumerable<TestType> GetTestTypes()
        {
            List<TestType> TestTypeArray = new List<TestType>();
            TestType testTypeMock1 = new TestType()
            {
                TestTypeId = 1, 
                AbnormalValuesCritical = true,
                TestTypeName = "Pregnancy",
                IsValidTestType = true,
                TestTypeCategory = TestTypeCategory.Urine, 
                TestTypeNormalValues = "Negative"
            };
            TestType testTypeMock2 = new TestType()
            {
                TestTypeId = 2,
                AbnormalValuesCritical = false,
                TestTypeName = "Strep",
                IsValidTestType = true,
                TestTypeCategory = TestTypeCategory.Swab,
                TestTypeNormalValues = "Negative"
            };

            TestTypeArray.Add(testTypeMock1);
            TestTypeArray.Add(@testTypeMock2);
            return TestTypeArray; 
        }

        [HttpPost(Name = "PostTestTypes")]
        public async Task<IActionResult> PostTestTypes([FromBody] List<TestType> testTypes)
        {
            return Ok(); 
        }

        [HttpDelete(Name = "DeleteTestTypes")]
        public async Task<IActionResult> DeleteTestTypes(string[] testTypeIds)
        {
            foreach(string TestTypeId in testTypeIds)
            {
                Console.WriteLine("Deleting " +  TestTypeId.ToString());
            }
            return NoContent();  
        }
    }
}