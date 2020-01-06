using System.Collections.Generic;

namespace ToH_AfterNightOutTests.TestCasesData
{
    public class TohTestCasesDM
    {
        public Testdata TestData { get; set; }
    }

    public class Testdata
    {
        public IEnumerable<Data_For_Eofnkabc> Data_for_eOfnkabc { get; set; }
    }

    public class Data_For_Eofnkabc
    {
        public string expectedValue { get; set; }
        public string diskCount { get; set; }
        public string kSquareTiles { get; set; }
        public string source { get; set; }
        public string auxiliary { get; set; }
        public string destination { get; set; }
    }

}
