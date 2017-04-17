using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CyberQLogger;

namespace CyberQLogger
{
    [TestClass]
    public class LoggerTestFixture
    {
        [TestMethod]
        public void LogCsvFileToDisk()
        {
            var mockFileOutputter = new MockFileOutputter();
            var logger = new Logger(mockFileOutputter);

            DateTime d = DateTime.Parse("12/17/1978 05:34:22");
            var dataToLog = new GuruData(d, 220.3f, 99.1f, float.NaN, float.NaN);

            logger.Log(dataToLog);

            Assert.AreEqual(1, mockFileOutputter.Rows.Count);
            Assert.AreEqual("05:34,220.3,99.1,NaN,NaN\n", mockFileOutputter.Rows[0]);
        }
    }
}
