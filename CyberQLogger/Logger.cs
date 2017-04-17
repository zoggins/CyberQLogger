using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    public class Logger
    {
        public Logger(IOutputter outputter)
        {
            m_outputter = outputter;
        }

        private IOutputter m_outputter;

        public void Log(GuruData dataToLog)
        {
            var row = String.Format("{0:HH:mm},{1},{2},{3},{4}\n", dataToLog.Timestamp, dataToLog.PitTemp, dataToLog.FoodTemp1, dataToLog.FoodTemp2, dataToLog.FoodTemp3);

            m_outputter.Output(row);
        }
    }
}
