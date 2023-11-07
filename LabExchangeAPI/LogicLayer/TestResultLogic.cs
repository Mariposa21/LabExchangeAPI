using LabExchangeAPI.LabExchangeDatabase;
using LabExchangeAPI.LogicLayer.Models;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;
using System.Globalization;

namespace LabExchangeAPI.LogicLayer
{
    public class TestResultLogic
    {
        private LabExchangeDatabaseContext _context;

        public TestResultLogic(LabExchangeDatabaseContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<TestResult>> GetTestResultsAsync()
        {
            List<TestResult> testResults = new List<TestResult>();
            var dbTestResults = await _context.TblTestResults.ToListAsync();

            if (dbTestResults.Count > 0)
            {
                foreach (TblTestResult dbTestResult in dbTestResults)
                {
                    testResults.Add(new TestResult()
                    {
                        Id = (int)dbTestResult.TestResultId, 
                        VendorId = dbTestResult.VendorId,
                        VendorResultId = dbTestResult.VendorResultId,
                        PatientMedicalRecordNum = dbTestResult.PatientMedicalRecordNum,
                        ResultGenerationDateTime = dbTestResult.ResultGenerationDateTime,
                        PatientDateOfBirth = DateOnly.FromDateTime(dbTestResult.PatientDateOfBirth), 
                        SubmissionDateTime = dbTestResult.SubmissionDateTime,
                        IsValidTestResult = (bool)dbTestResult.IsValidTestResult, 
                        FlagForReview = (bool)dbTestResult.FlagForReview, 
                        ResultTestType = new TestType()
                        {
                            TestTypeNormalValues = dbTestResult.ResultTestType.TestTypeNormalValues,
                            TestTypeCategory = (TestTypeCategory)Enum.ToObject(typeof(TestTypeCategory), dbTestResult.ResultTestType.TestTypeCategoryId),
                            AbnormalValuesCritical = dbTestResult.ResultTestType.IsAbnormalValuesCritical,
                            IsValidTestType = dbTestResult.ResultTestType.IsValidTestType,
                            TestTypeId = dbTestResult.ResultTestType.TestTypeId,
                            TestTypeName = dbTestResult.ResultTestType.TestTypeName
                        }, 
                        TestResultShort = dbTestResult.TestResultShortDescription, 
                        TestResultNotes = dbTestResult.TestResultNotes
                    }
                    );
                }
                return testResults;
            }
            return Array.Empty<TestResult>().ToList();
        }

        public async Task PostTestTypesAsync(List<TestResult> testResults)
        {
            List<TblTestResult> dbTestResults = new List<TblTestResult>();
            foreach (TestResult testResult in testResults)
            {
                if (await _context.TblTestResults.AnyAsync(t => t.TestResultId == testResult.Id)) {
                    var testResultToUpsert = await _context.TblTestResults.FirstOrDefaultAsync(t => t.TestResultId == testResult.Id);

                    testResultToUpsert.VendorId = testResult.VendorId;
                    testResultToUpsert.VendorResultId = testResult.VendorResultId;
                    testResultToUpsert.PatientMedicalRecordNum = testResult.PatientMedicalRecordNum;
                    testResultToUpsert.ResultGenerationDateTime = testResult.ResultGenerationDateTime;
                    testResultToUpsert.PatientDateOfBirth = DateTime.Parse(testResult.PatientDateOfBirth.ToShortDateString(), new CultureInfo("en-US", true)); 
                    testResultToUpsert.SubmissionDateTime = testResult.SubmissionDateTime;
                    testResultToUpsert.IsValidTestResult = (bool)testResult.IsValidTestResult;
                    testResultToUpsert.FlagForReview = (bool)testResult.FlagForReview;
                    testResultToUpsert.ResultTestType = new TblTestType()
                    {
                        TestTypeNormalValues = testResult.ResultTestType.TestTypeNormalValues,

                        TestTypeCategory = new TblTestTypeCategory()
                        {
                            TestTypeCategoryId = (byte)(TestTypeCategory)Enum.ToObject(typeof(TestTypeCategory), testResult.ResultTestType.TestTypeCategory),
                            TestTypeCategory = testResult.ResultTestType.TestTypeCategory.ToString()
                        },
                        IsAbnormalValuesCritical = testResult.ResultTestType.AbnormalValuesCritical,
                        IsValidTestType = testResult.ResultTestType.IsValidTestType,
                        TestTypeId = testResult.ResultTestType.TestTypeId,
                        TestTypeName = testResult.ResultTestType.TestTypeName
                    };
                    testResultToUpsert.TestResultShortDescription = testResult.TestResultShort;
                    testResultToUpsert.TestResultNotes = testResult.TestResultNotes; 
                    dbTestResults.Add(testResultToUpsert);
                }
                else
                {
                    dbTestResults.Add(new TblTestResult()
                    {
                        VendorId = testResult.VendorId,
                        VendorResultId = testResult.VendorResultId,
                        PatientMedicalRecordNum = testResult.PatientMedicalRecordNum,
                        ResultGenerationDateTime = testResult.ResultGenerationDateTime,
                        PatientDateOfBirth = DateTime.Parse(testResult.PatientDateOfBirth.ToShortDateString(), new CultureInfo("en-US", true)),
                        SubmissionDateTime = testResult.SubmissionDateTime,
                        IsValidTestResult = (bool)testResult.IsValidTestResult,
                        FlagForReview = (bool)testResult.FlagForReview,
                        ResultTestType = new TblTestType()
                        {
                            TestTypeNormalValues = testResult.ResultTestType.TestTypeNormalValues,
                            TestTypeCategory = new TblTestTypeCategory()
                            {
                                TestTypeCategoryId = (byte)(TestTypeCategory)Enum.ToObject(typeof(TestTypeCategory), testResult.ResultTestType.TestTypeCategory),
                                TestTypeCategory = testResult.ResultTestType.TestTypeCategory.ToString()
                            },
                            IsAbnormalValuesCritical = testResult.ResultTestType.AbnormalValuesCritical,
                            IsValidTestType = testResult.ResultTestType.IsValidTestType,
                            TestTypeId = testResult.ResultTestType.TestTypeId,
                            TestTypeName = testResult.ResultTestType.TestTypeName
                        },
                        TestResultShortDescription = testResult.TestResultShort,
                        TestResultNotes = testResult.TestResultNotes
                    }); 
                     
            }
            }

            await _context.BulkInsertOrUpdateAsync(dbTestResults);
        }

        public async Task DeleteTestTypesAsync(List<int> testTypeIds)
        {
            var testTypesToDelete = await _context.TblTestTypes.Where(t => testTypeIds.Any(id => id == t.TestTypeId)).ToListAsync();
            await _context.BulkDeleteAsync(testTypesToDelete);
        }
    }
}
