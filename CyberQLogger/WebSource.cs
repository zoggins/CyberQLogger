using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    public class WebSource : ISource
    { 
        private string m_url;

        public WebSource(string url)
        {
            m_url = url;
        }

        public string Fetch()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            String xml;

            // Create the web request  
            request = WebRequest.Create(m_url) as HttpWebRequest;

            // Get response  
            using (response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                xml = reader.ReadToEnd();
            }

            return xml;
        }

        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
