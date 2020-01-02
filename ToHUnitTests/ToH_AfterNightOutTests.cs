using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToH_AfterNightOut;

namespace ToHUnitTests
{
    [TestClass]
    public class ToH_AfterNightOutTests
    {
        /// <summary>
        /// Tests for ∑1≤n≤10000 E(n,10n,3n,6n,9n)
        /// </summary>
        [TestMethod]
        public void mathematicallySolve_forGivenIntValues_ReturnsStepCount()
        {
            var expectedValue = 983975221;
            int n = 10000;  //Number of Disks
            int k = 10, a = 3, b = 6, c = 9;    //testing for the required problem statement.

            var result = ToHAfterNightOut.mathematicallySolve(n, k, a, b, c);

            Assert.AreEqual(expectedValue, result, $"Expected value of {expectedValue} is equal to actual value of {result}.");
        }

        /// <summary>
        /// Tests Steps Count for e(2,5,1,3,5)
        /// </summary>
        [TestMethod]
        public void StepsCountForSingleValue_eOf2_5_1_3_5_ReturnsStepCount()
        {
            var expectedValue = 60;
            int diskCount = 2, kSquareTiles = 5, source = 1, auxiliary = 3, destination = 5;

            var result = ToHAfterNightOut.StepsCountForFixedDiskCount(diskCount, kSquareTiles, source, auxiliary, destination);

            Assert.AreEqual(expectedValue, result, $"Expected value of {expectedValue} is equal to actual value of {result}.");
        }

        /// <summary>
        /// Tests Steps Count for e(3,20,4,9,17)
        /// </summary>
        [TestMethod]
        public void StepsCountForSingleValue_eOf3_20_4_9_17_ReturnsStepCount()
        {
            var expectedValue = 2358;
            int diskCount = 3, kSquareTiles = 20, source = 4, auxiliary = 9, destination = 17;

            var result = ToHAfterNightOut.StepsCountForFixedDiskCount(diskCount, kSquareTiles, source, auxiliary, destination);

            Assert.AreEqual(expectedValue, result, $"Expected value of {expectedValue} is equal to actual value of {result}.");
        }
    }
}
