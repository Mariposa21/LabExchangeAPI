using Microsoft.AspNetCore.Mvc;

namespace LabExchangeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendorController : ControllerBase
    {
        private static readonly string[] Tests = new[]
        {
        "RxExpress", "LabTestRS", "FamilyTest"
    };

        private readonly ILogger<VendorController> _logger;

        public VendorController(ILogger<VendorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetVendors")]
        public IEnumerable<string> GetVendors()
        {
            return Array.Empty<string>();
        }

        [HttpPost(Name = "PostVendor")]
        public IEnumerable<string> PostVendors()
        {
            return Array.Empty<string>();
        }

        [HttpPut(Name = "PutVendor")]
        public IEnumerable<string> PutVendor()
        {
            return Array.Empty<string>();
        }

        [HttpDelete(Name = "DeleteVendor")]
        public IEnumerable<string> DeleteVendors()
        {
            return Array.Empty<string>();
        }
    }
}