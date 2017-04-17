using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    [TestClass]
    public class FileOutputterTestFixture
    {
        [TestMethod]
        public void WriteSingleLineToDisk()
        {
            var tempFile = Path.GetTempFileName();

            var fileOutputter = new FileOutputter(tempFile);

            fileOutputter.Output("Test Row\n");

            Assert.AreEqual("Test Row\n", File.ReadAllText(tempFile));

            File.Delete(tempFile);
        }

        [TestMethod]
        public void WriteMultipleLinesToDisk()
        {
            var tempFile = Path.GetTempFileName();

            var fileOutputter = new FileOutputter(tempFile);

            fileOutputter.Output("Test Row1\n");
            fileOutputter.Output("Test Row2\n");

            Assert.AreEqual("Test Row1\nTest Row2\n", File.ReadAllText(tempFile));

            File.Delete(tempFile);
        }
    }
}
