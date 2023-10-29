namespace LabExchangeAPI.LogicLayer.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorStreetAddress1 { get; set; }
        public string? VendorStreetAddress2 { get; set; }
        public string VendorCity { get; set; }
        public string VendorState { get; set; }
        public string VendorZipCode { get; set; }
        public string VendorPhone { get; set; }
        public string? VendorExtension { get; set; }
    }
}