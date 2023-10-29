using System;
using System.Collections.Generic;

namespace LabExchangeAPI.LabExchangeDatabase;

public partial class TblTestType
{
    public int TestTypeId { get; set; }

    public string TestTypeName { get; set; } = null!;

    public byte TestTypeCategoryId { get; set; }

    public string TestTypeNormalValues { get; set; } = null!;

    public bool IsAbnormalValuesCritical { get; set; }

    public bool IsValidTestType { get; set; }

    public int ApiUserId { get; set; }

    public virtual ICollection<TblTestResult> TblTestResults { get; set; } = new List<TblTestResult>();

    public virtual TblTestTypeCategory TestTypeCategory { get; set; } = null!;
}
