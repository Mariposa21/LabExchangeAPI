namespace LabExchangeAPI.BusinessModels
{
    public class TestType
    {
        public int TestTypeId { get; set; }
        public TestTypeCategory TestTypeCategory { get; set; }
        public string TestTypeNormalValues { get; set; }
        public bool AbnormalValuesCritical { get; set; }
        public bool IsValidTestType { get; set; }
    }
}