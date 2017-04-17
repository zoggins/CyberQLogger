using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    class MockFileOutputter : IOutputter
    {
        public MockFileOutputter()
        {
            Rows = new List<string>();
        }
        public List<string> Rows;

        public void Output(string row)
        {
            Rows.Add(row);
        }
    }
}
