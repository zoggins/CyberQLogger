using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    public struct GuruData
    {
        public GuruData(DateTime timestamp, float pitTemp, float foodTemp1, float foodTemp2, float foodTemp3)
        {
            Timestamp = timestamp;
            PitTemp = pitTemp;
            FoodTemp1 = foodTemp1;
            FoodTemp2 = foodTemp2;
            FoodTemp3 = foodTemp3;
        }

        public DateTime Timestamp;
        public float PitTemp;
        public float FoodTemp1;
        public float FoodTemp2;
        public float FoodTemp3;
    }
}
