using LabExchangeAPI.LabExchangeDatabase;
using LabExchangeAPI.LogicLayer;
using LabExchangeAPI.LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabExchangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestTypeController : ControllerBase
    {

        private readonly ILogger<TestTypeController> _logger;
        private LabExchangeDatabaseContext _context;

        public TestTypeController(ILogger<TestTypeController> logger, LabExchangeDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("~/TestTypeCategories")]
        public IEnumerable<string> GetTestTypeCategories()
        {
            return Enum.GetNames(typeof(TestTypeCategory)); 
        }

        [HttpGet("~/TestTypes")]
        public async Task<List<TestType>> GetTestTypes()
        {
            List<TestType> TestTypeArray = new List<TestType>();
            //TestType testTypeMock1 = new TestType()
            //{
            //    TestTypeId = 1, 
            //    AbnormalValuesCritical = true,
            //    TestTypeName = "Pregnancy",
            //    IsValidTestType = true,
            //    TestTypeCategory = TestTypeCategory.Urine, 
            //    TestTypeNormalValues = "Negative"
            //};
            //TestType testTypeMock2 = new TestType()
            //{
            //    TestTypeId = 2,
            //    AbnormalValuesCritical = false,
            //    TestTypeName = "Strep",
            //    IsValidTestType = true,
            //    TestTypeCategory = TestTypeCategory.Swab,
            //    TestTypeNormalValues = "Negative"
            //};

            //TestTypeArray.Add(testTypeMock1);
            //TestTypeArray.Add(@testTypeMock2);
            TestTypeLogic testTypeLogic = new TestTypeLogic(_context); 
            TestTypeArray = await testTypeLogic.GetTestTypesAsync(); 
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