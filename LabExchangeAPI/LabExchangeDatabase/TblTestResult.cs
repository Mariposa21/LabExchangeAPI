using System;
using System.Collections.Generic;

namespace LabExchangeAPI.LabExchangeDatabase;

public partial class TblTestResult
{
    public long TestResultId { get; set; }

    public string VendorResultId { get; set; } = null!;

    public DateTime SubmissionDateTime { get; set; }

    public DateTime ResultGenerationDateTime { get; set; }

    public string PatientMedicalRecordNum { get; set; } = null!;

    public DateTime PatientDateOfBirth { get; set; }

    public int ResultTestTypeId { get; set; }

    public int VendorId { get; set; }

    public string? TestResultShortDescription { get; set; }

    public string? TestResultNotes { get; set; }

    public bool? FlagForReview { get; set; }

    public bool? IsValidTestResult { get; set; }

    public int ApiUserId { get; set; }

    public virtual TblTestType ResultTestType { get; set; } = null!;

    public virtual TblVendor Vendor { get; set; } = null!;
}
