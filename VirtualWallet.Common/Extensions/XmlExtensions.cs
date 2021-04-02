using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace VirtualWallet.Common.Extensions
{
    public static class XmlExtensions
    {
        public static string ContentToString(this XDocument document) 
            => string.Concat(document.Declaration?.ToString()?.OrEmpty(), Environment.NewLine, document.ToString());

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }

        public static XDocument ParseToXDocumentOrDefault(this XmlNode xmlNode, Func<XmlNode, string> nodeXmlStringContent)
        {
            try
            {
                return XDocument.Parse(nodeXmlStringContent(xmlNode));
            }
            catch
            {
                return new XDocument();
            }
        }
    }
}
