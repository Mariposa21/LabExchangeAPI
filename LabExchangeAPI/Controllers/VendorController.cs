using LabExchangeAPI.LogicLayer.Models;
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
        public IEnumerable<Vendor> GetVendors()
        {
            List<Vendor> VendorArray = new List<Vendor>();
            Vendor vendorMock1 = new Vendor()
            {
                VendorId = 1, 
                VendorName = "DiagnosticsLab", 
                VendorStreetAddress1 = "123 Blueberry Lane", 
                VendorStreetAddress2 = null, 
                VendorCity = "Boston", 
                VendorState = "MA", 
                VendorZipCode = "00000", 
                VendorPhone = "888-888-8888", 
                VendorExtension = null
            };
            Vendor vendorMock2 = new Vendor()
            {
                VendorId = 1,
                VendorName = "BloodLabsNewEngland",
                VendorStreetAddress1 = "123 Strawberry Circle",
                VendorStreetAddress2 = null,
                VendorCity = "Boston",
                VendorState = "MA",
                VendorZipCode = "00000",
                VendorPhone = "888-888-8888",
                VendorExtension = "1234"
            };
            VendorArray.Add(vendorMock1);
            VendorArray.Add(vendorMock2);
            return VendorArray;
        }

        [HttpPost(Name = "PostVendor")]
        public async Task<IActionResult> PostVendors([FromBody] List<Vendor> vendors)
        {
            return Ok(); 
        }

        [HttpPut(Name = "PutVendor")]
        public async Task<IActionResult> PutVendor([FromBody] Vendor vendor)
        {
            return Ok(); 
        }

        [HttpDelete(Name = "DeleteVendor")]
        public async Task<IActionResult> DeleteVendors([FromBody] string[] vendorIds)
        {
            foreach (string VendorId in vendorIds)
            {
                Console.WriteLine("Deleting " + VendorId.ToString());
            }
            return NoContent();
        }
    }
}