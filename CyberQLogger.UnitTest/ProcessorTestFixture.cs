using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    [TestClass]
    public class ProcessorTestFixture
    {
        [TestMethod]
        public void ProcessMultipleTimes()
        {
            var xmlInput = @"<nutcstatus>
   <!--all temperatures are displayed in tenths F, regardless of setting of unit-->
   <!--all temperatures sent by browser to unit should be in F.  you can send tenths F with a decimal place, ex: 123.5-->  
   <OUTPUT_PERCENT>100</OUTPUT_PERCENT>
   <TIMER_CURR>00:00:00</TIMER_CURR>
   <COOK_TEMP>684</COOK_TEMP>
   <FOOD1_TEMP>202</FOOD1_TEMP>
   <FOOD2_TEMP>OPEN</FOOD2_TEMP>
   <FOOD3_TEMP>OPEN</FOOD3_TEMP>
   <COOK_STATUS>2</COOK_STATUS>
   <FOOD1_STATUS>4</FOOD1_STATUS>
   <FOOD2_STATUS>4</FOOD2_STATUS>
   <FOOD3_STATUS>4</FOOD3_STATUS>
   <TIMER_STATUS>0</TIMER_STATUS>
   <DEG_UNITS>1</DEG_UNITS>
   <COOK_CYCTIME>6</COOK_CYCTIME>
   <COOK_PROPBAND>300</COOK_PROPBAND>
   <COOK_RAMP>0</COOK_RAMP>
</nutcstatus>";

            var source = new MockSource();
            source.Input = xmlInput;
            source.Now = DateTime.Parse("12/17/1978 23:45:55");

            var outputter = new MockFileOutputter();

            var processor = new Processor(source, outputter);

            processor.Process();
            processor.Process();

            Assert.AreEqual(2, outputter.Rows.Count);
            Assert.AreEqual("23:45,68.4,20.2,NaN,NaN\n", outputter.Rows[0]);
            Assert.AreEqual("23:45,68.4,20.2,NaN,NaN\n", outputter.Rows[1]);


        }
    }
}
