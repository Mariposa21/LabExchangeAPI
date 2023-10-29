using LabExchangeAPI.LabExchangeDatabase;
using LabExchangeAPI.LogicLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabExchangeAPI.LogicLayer
{
    public class TestTypeLogic
    {

        private readonly ILogger<TestTypeLogic> _logger;

        public TestTypeLogic(ILogger<TestTypeLogic> logger)
        {
            _logger = logger;
        }
        public async Task<List<TestType>> GetTestTypes()
        {
            List<TestType> testTypes = new List<TestType>();
            using (LabExchangeDatabaseContext dbContext = new LabExchangeDatabaseContext())
            {
                var dbTestTypes = await dbContext.TblTestTypes.ToListAsync();

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
        }
    }
}
