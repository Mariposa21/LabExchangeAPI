using LabExchangeAPI.LabExchangeDatabase;
using LabExchangeAPI.LogicLayer;
using LabExchangeAPI.LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabExchangeAPI.Controllers
{
    [ApiController]
    [Route("Vendors")]
    public class VendorController : ControllerBase
    {

        private readonly ILogger<VendorController> _logger;
        private VendorLogic _logicLayer;


        public VendorController(ILogger<VendorController> logger,
            LabExchangeDatabaseContext dbContext)
        {
            _logger = logger;
            _logicLayer = new VendorLogic(dbContext);
        }


        [HttpGet(Name = "GetVendors")]
        public async Task<List<Vendor>> GetVendors()
        {
            List<Vendor> vendorArray = await _logicLayer.GetVendorsAsync();
            return vendorArray;
        }

        [HttpPost(Name = "PostVendor")]
        public async Task<IActionResult> PostVendors([FromBody] List<Vendor> vendors)
        {
            await _logicLayer.PostVendorsAsync(vendors);
            return Ok();
        }

        [HttpDelete(Name = "DeleteVendor")]
        public async Task<IActionResult> DeleteVendors([FromBody] List<int> vendorIds)
        {
            await _logicLayer.DeleteTestTypesAsync(vendorIds);
            return Ok();
        }
    }
}