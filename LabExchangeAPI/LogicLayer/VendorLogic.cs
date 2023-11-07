using LabExchangeAPI.LabExchangeDatabase;
using LabExchangeAPI.LogicLayer.Models;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace LabExchangeAPI.LogicLayer
{
    public class VendorLogic
    {
        private LabExchangeDatabaseContext _context;

        public VendorLogic(LabExchangeDatabaseContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Vendor>> GetVendorsAsync()
        {
            List<Vendor> vendorsList = new List<Vendor>();
            var dbVendors = await _context.TblVendors.ToListAsync();

                if (dbVendors.Count > 0)
                {
                    foreach (TblVendor dbVendor in dbVendors)
                    {
                        vendorsList.Add(new Vendor()
                        {
                            VendorId = dbVendor.VendorId, 
                            VendorName = dbVendor.VendorName,
                            VendorStreetAddress1 = dbVendor.VendorStreetAddress1,
                            VendorStreetAddress2 = dbVendor.VendorStreetAddress2,
                            VendorCity = dbVendor.VendorCity, 
                            VendorState = dbVendor.VendorState,
                            VendorZipCode = dbVendor.VendorZipCode,
                            VendorPhone = dbVendor.VendorPhone,
                            VendorExtension = dbVendor.VendorExtension
                        }
                        );
                    }
                    return vendorsList;
                }
                    return Array.Empty<Vendor>().ToList();
        }

        public async Task PostVendorsAsync(List<Vendor> vendors)
        {
            await _context.BulkInsertOrUpdateAsync(vendors);
        }

        public async Task DeleteTestTypesAsync(List<int> vendorIds)
        {
            var vendorTypesToDelete = await _context.TblVendors.Where(t => vendorIds.Any(id => id == t.VendorId)).ToListAsync();
            await _context.BulkDeleteAsync(vendorTypesToDelete);
        }
    }
}
