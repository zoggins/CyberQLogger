using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CyberQLogger
{
    public class Parser
    {
        public Parser(ISource source)
        {
            m_source = source;
        }

        public GuruData Fetch()
        {
            var now = m_source.GetCurrentTime();
            var xml = m_source.Fetch();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            var data = new GuruData();

            data.Timestamp = now;

            ParseTemp(doc, "//COOK_TEMP", out data.PitTemp);
            ParseTemp(doc, "//FOOD1_TEMP", out data.FoodTemp1);
            ParseTemp(doc, "//FOOD2_TEMP", out data.FoodTemp2);
            ParseTemp(doc, "//FOOD3_TEMP", out data.FoodTemp3);

            return data;

        }

        private static void ParseTemp(XmlDocument doc, string elementPath, out float temp)
        {
            XmlNode node = doc.SelectSingleNode(elementPath);
            string innerText = node.InnerText;
            if (innerText != "OPEN")
            {
                innerText = innerText.Insert(innerText.Length - 1, ".");
                temp = float.Parse(innerText);
            }
            else
            {
                temp = float.NaN;
            }
        }

        private ISource m_source;
    }
}
