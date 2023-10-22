namespace LabExchangeAPI.BusinessModels
{
    public class TestResult
    {
        public string VendorResultId { get; set; }
        public DateTime SubmissionDateTime { get; set; }
        public DateTime ResultGenerationDateTime { get; set; }
        public string PatientMedicalRecordNum { get; set; }
        public DateOnly PatientDateOfBirth { get; set; }
        public int TestTypeId { get; set; }
        public int VendorId { get; set; }
        public string TestResultShort { get; set; }
        public string TestResultNotes { get; set; }
        public bool FlagForReview { get; set; }
        public bool IsValidTestResult { get; set; }
    }
}