using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ToH_AfterNightOut.Helpers;
using ToH_AfterNightOutTests.Helpers;

namespace ToHUnitTests
{
    [TestClass]
    public class ToH_AfterNightOutTests
    {

        MathematicalSolution mathematicalSoln;
        TestCasesDataReader testCasesDR;
        static string _testCasesFilePath = @".\TestCasesData\ToHTestCases.json";

        public ToH_AfterNightOutTests()
        {
            mathematicalSoln = new MathematicalSolution();
        }

        /// <summary>
        /// Tests for ∑1≤n≤10000 E(n,10n,3n,6n,9n)
        /// </summary>
        [TestMethod]
        public void mathematicallySolve_ForGivenIntValues_ReturnsStepCount()
        {
            var expectedValue = 983975221;
            int n = 10000;  //Number of Disks
            int k = 10, a = 3, b = 6, c = 9;    //testing for the required problem statement.

            var result = mathematicalSoln.mathematicallySolve(n, k, a, b, c);

            Assert.AreEqual(expectedValue, result, $"Expected value of {expectedValue} is equal to actual value of {result}.");
        }

        /// <summary>
        /// For Reading data from JSON file & handling data driven approach
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetData()
        {
            var testDataList = new TestCasesDataReader(_testCasesFilePath).ParseJson2Model().TestData.Data_for_eOfnkabc;
            foreach (var testData in testDataList)
            {
                yield return new object[] {
                    Convert.ToInt32(testData.expectedValue),
                    Convert.ToInt32(testData.diskCount),
                    Convert.ToInt32(testData.kSquareTiles),
                    Convert.ToInt32(testData.source),
                    Convert.ToInt32(testData.auxiliary),
                    Convert.ToInt32(testData.destination)
                };
            }
        }

        /// <summary>
        /// Tests Steps Count for e(n,k,a,b,c)
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void StepsCountForSingleValue_eOfnkabc_ReturnsStepCount(int expectedValue, int diskCount, int kSquareTiles, int source, int auxiliary, int destination)
        {
            //var dataTest = data;
            //var expectedValue = 60;
            //int diskCount = 2, kSquareTiles = 5, source = 1, auxiliary = 3, destination = 5;

            var result = mathematicalSoln.StepsCountForFixedDiskCount(diskCount, kSquareTiles, source, auxiliary, destination);

            Assert.AreEqual(expectedValue, result, $"Expected value of {expectedValue} is equal to actual value of {result}.");
        }
    }
}
