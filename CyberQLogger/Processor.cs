using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    public class Processor
    {
        private IOutputter m_outputter;
        private ISource m_source;

        public Processor(ISource source, IOutputter outputter)
        {
            m_source = source;
            m_outputter = outputter;
        }

        public void Process()
        {
            var parser = new Parser(m_source);
            var data = parser.Fetch();

            var logger = new Logger(m_outputter);

            logger.Log(data);
        }
    }
}
