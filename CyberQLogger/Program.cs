using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CyberQLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("\nUsage: CyberQLogger <url> <output file>\n\nExample: CyberQLogger \"http://192.168.0.6/status.xml\" \"File.csv\"\n\n");
                return;
            }

            var source = new WebSource(args[0]);
            var outputter = new FileOutputter(args[1]);

            var process = new Processor(source, outputter);

            Console.WriteLine("Starting Processor...\n\nControl-C to quit\n");

            while(true)
            {
                try
                {
                    process.Process();
                    Console.WriteLine(String.Format("Writing data point at {0}", DateTime.Now));
                }
                catch
                {
                    Console.WriteLine(String.Format("Error writing data point at {0}", DateTime.Now));
                }

                Thread.Sleep(60000);
            }
        }
    }
}
