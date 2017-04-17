using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    public class FileOutputter : IOutputter
    {
        public FileOutputter(string filename)
        {
            m_filename = filename;
        }

        public void Output(string row)
        {
            File.AppendAllText(m_filename, row);
        }

        private string m_filename;
    }
}
