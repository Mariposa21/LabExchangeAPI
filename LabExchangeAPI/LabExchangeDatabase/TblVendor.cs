using System;
using System.Collections.Generic;

namespace LabExchangeAPI.LabExchangeDatabase;

public partial class TblVendor
{
    public int VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public string VendorStreetAddress1 { get; set; } = null!;

    public string? VendorStreetAddress2 { get; set; }

    public string? VendorCity { get; set; }

    public string VendorState { get; set; } = null!;

    public string VendorZipCode { get; set; } = null!;

    public string VendorPhone { get; set; } = null!;

    public string? VendorExtension { get; set; }

    public int ApiUserId { get; set; }

    public virtual ICollection<TblTestResult> TblTestResults { get; set; } = new List<TblTestResult>();
}
