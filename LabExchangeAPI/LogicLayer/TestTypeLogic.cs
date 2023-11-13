using LabExchangeAPI.LabExchangeDatabase;
using LabExchangeAPI.LogicLayer.Models;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace LabExchangeAPI.LogicLayer
{
    public class TestTypeLogic
    {
        private LabExchangeDatabaseContext _context;

        public TestTypeLogic(LabExchangeDatabaseContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<TestType>> GetTestTypesAsync()
        {
            List<TestType> testTypes = new List<TestType>();
                var dbTestTypes = await _context.TblTestTypes.ToListAsync();

                if (dbTestTypes.Count > 0)
                {
                    foreach (TblTestType dbTestType in dbTestTypes)
                    {
                        testTypes.Add(new TestType()
                        {
                            TestTypeNormalValues = dbTestType.TestTypeNormalValues,
                            TestTypeCategory = (TestTypeCategory)Enum.ToObject(typeof(TestTypeCategory), dbTestType.TestTypeCategoryId),
                            AbnormalValuesCritical = dbTestType.IsAbnormalValuesCritical,
                            IsValidTestType = dbTestType.IsValidTestType,
                            TestTypeId = dbTestType.TestTypeId,
                            TestTypeName = dbTestType.TestTypeName
                        }
                        );
                    }
                    return testTypes;
                }
                    return Array.Empty<TestType>().ToList();
        }

        public async Task PostTestTypesAsync(List<TestType> testTypes)
        {
            List<TblTestType> testTypesEntities = new List<TblTestType>();
            foreach (TestType testType in testTypes)
            {
                testTypesEntities.Add(new TblTestType()
                {
                    TestTypeId = testType.TestTypeId,
                    TestTypeCategoryId = (byte)testType.TestTypeCategory, 
                    TestTypeName = testType.TestTypeName,
                    TestTypeNormalValues = testType.TestTypeNormalValues,
                    ApiUserId = 123, 
                    IsValidTestType = testType.IsValidTestType,
                    IsAbnormalValuesCritical = testType.AbnormalValuesCritical
                });
            }
            if (testTypesEntities.Count > 0)
            {
                await _context.BulkInsertOrUpdateAsync(testTypesEntities);
            }
        }

        public async Task DeleteTestTypesAsync(List<int> testTypeIds)
        {
            var testTypesToDelete = await _context.TblTestTypes.Where(t => testTypeIds.Any(id => id == t.TestTypeId)).ToListAsync();
            await _context.BulkDeleteAsync(testTypesToDelete); 
        }
    }
}
