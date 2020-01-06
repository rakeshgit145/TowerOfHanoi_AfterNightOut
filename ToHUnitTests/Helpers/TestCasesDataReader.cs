using Newtonsoft.Json;
using System.IO;
using ToH_AfterNightOutTests.TestCasesData;

namespace ToH_AfterNightOutTests.Helpers
{
    class TestCasesDataReader
    {
        private string _filepath;
        public TestCasesDataReader(string filepath)
        {
            _filepath = filepath;
        }
        /// <summary>
        /// Method to parse Json TestCasesData from Json file & return its testCaseDataModel
        /// </summary>
        public TohTestCasesDM ParseJson2Model()
        {
            string jsonData;
            TohTestCasesDM testCaseDM = new TohTestCasesDM();
            try
            {
                //Json Data read
                using (StreamReader reader = new StreamReader(_filepath))
                {
                    jsonData = reader.ReadToEnd();
                }
                testCaseDM = JsonConvert.DeserializeObject<TohTestCasesDM>(jsonData);
            }
            catch (System.Exception exe)
            {
                //handle & log exception
            }
            return testCaseDM;
        }
    }
}
