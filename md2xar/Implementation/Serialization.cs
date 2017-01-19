using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace md2xar.Implementation
{
    public class Serialization
    {
        public static byte[] Serialize<T>(T obj)
        {
            XmlSerializer xsResult = new XmlSerializer(typeof(T));
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                Encoding = new UTF8Encoding(false)
            };

            using (MemoryStream stream = new MemoryStream())
            using (XmlWriter xmlWriter = XmlWriter.Create(stream, settings))
            {
                xsResult.Serialize(xmlWriter, obj);
                return stream.ToArray();
            }
        }
    }
}
