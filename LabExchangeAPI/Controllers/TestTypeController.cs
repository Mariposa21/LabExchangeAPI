using LabExchangeAPI.LabExchangeDatabase;
using LabExchangeAPI.LogicLayer;
using LabExchangeAPI.LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LabExchangeAPI.Controllers
{
    [ApiController]
    [Route("TestTypes")]
    public class TestTypeController : ControllerBase
    {

        private readonly ILogger<TestTypeController> _logger;
        private TestTypeLogic _logicLayer;

        public TestTypeController(ILogger<TestTypeController> logger, 
            LabExchangeDatabaseContext dbContext)
        {
            _logger = logger;
            _logicLayer = new TestTypeLogic(dbContext);
        }


        [HttpGet("~/TestTypeCategories", Name = "GetTestTypeCategories")]
        public IEnumerable<string> GetTestTypeCategories()
        {
            return Enum.GetNames(typeof(TestTypeCategory)); 
        }

        [HttpGet(Name = "GetTestTypes")]
        public async Task<List<TestType>> GetTestTypes()
        {
            List<TestType> TestTypeArray = await _logicLayer.GetTestTypesAsync(); 
            return TestTypeArray; 
        }

        [HttpPost(Name = "PostTestTypes")]
        public async Task<IActionResult> PostTestTypes([FromBody] List<TestType> testTypes)
        {
            await _logicLayer.PostTestTypesAsync(testTypes); 
            return Ok(); 
        }

        [HttpDelete(Name = "DeleteTestTypes")]
        public async Task<IActionResult> DeleteTestTypes(List<int> testTypeIds)
        {
            await _logicLayer.DeleteTestTypesAsync(testTypeIds);
            return Ok();  
        }
    }
}