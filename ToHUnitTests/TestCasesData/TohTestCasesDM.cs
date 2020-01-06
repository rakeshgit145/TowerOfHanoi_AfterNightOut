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
        public string ExpectedValue { get; set; }
        public string DiskCount { get; set; }
        public string KSquareTiles { get; set; }
        public string Source { get; set; }
        public string Auxiliary { get; set; }
        public string Destination { get; set; }
    }

}
