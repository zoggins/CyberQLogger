using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    class MockSource : ISource
    {
        public string Input;
        public DateTime Now;

        public string Fetch()
        {
            return Input;
        }

        public DateTime GetCurrentTime()
        {
            return Now; 
        }
    }
}
