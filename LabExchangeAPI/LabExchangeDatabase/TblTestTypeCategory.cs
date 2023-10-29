using System;
using System.Collections.Generic;

namespace LabExchangeAPI.LabExchangeDatabase;

public partial class TblTestTypeCategory
{
    public byte TestTypeCategoryId { get; set; }

    public string TestTypeCategory { get; set; } = null!;

    public virtual ICollection<TblTestType> TblTestTypes { get; set; } = new List<TblTestType>();
}
