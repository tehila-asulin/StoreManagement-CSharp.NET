using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DalXml
{
    internal static class Config
    {
        static string filePath = @"../xml/data-config.xml";

        public static int CodeProduct
        {
            get
            {

                XElement configXml = XElement.Load(filePath);
                int code = int.Parse(configXml.Element("CodeProduct").Value);
                configXml.Element("CodeProduct").SetValue(code + 100);
                configXml.Save(filePath);
                return code;
            }

        }
        public static int CodeSale
        {
            get
            {

                XElement configXml = XElement.Load(filePath);
                int code = int.Parse(configXml.Element("CodeSale").Value);
                configXml.Element("CodeSale").SetValue(code + 1);
                configXml.Save(filePath);
                return code;
            }

        }
    }
}
