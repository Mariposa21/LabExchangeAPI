using LabExchangeAPI.LogicLayer.Models;

namespace LabExchangeAPI.LogicLayer.Models
{
    public class TestType
    {
        public int TestTypeId { get; set; }
        public string TestTypeName { get; set; }
        public TestTypeCategory TestTypeCategory { get; set; }
        public string TestTypeNormalValues { get; set; }
        public bool AbnormalValuesCritical { get; set; }
        public bool IsValidTestType { get; set; }
    }
}