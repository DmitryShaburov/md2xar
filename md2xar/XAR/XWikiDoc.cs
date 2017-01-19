using System.Xml.Serialization;

namespace md2xar.XAR
{
    [XmlRoot(ElementName = "xwikidoc")]
    public class XWikiDoc
    {
        [XmlAttribute("version")]
        public string AttributeVersion = "1.2";

        [XmlAttribute("reference")]
        public string AttributeReference = "";

        [XmlAttribute("locale")]
        public string Locale = "";

        [XmlElement("web")]
        public string Web = "";

        [XmlElement("name")]
        public string Name = "";

        [XmlElement("language")]
        public string Language = "";

        [XmlElement("defaultLanguage")]
        public string DefaultLanguage = "";

        [XmlElement("translation")]
        public int Translation = 0;

        [XmlElement("creator")]
        public string Creator = "";

        [XmlElement("creationDate")]
        public string CreationDate = "";

        [XmlElement("parent")]
        public string Parent = "";

        [XmlElement("author")]
        public string Author = "";

        [XmlElement("contentAuthor")]
        public string ContentAuthor = "";

        [XmlElement("date")]
        public string Date = "";

        [XmlElement("contentUpdateDate")]
        public string ContentUpdateDate = "";

        [XmlElement("version")]
        public string Version = "1.1";

        [XmlElement("title")]
        public string Title = "";

        [XmlElement("comment")]
        public string Comment = "";

        [XmlElement("minorEdit")]
        public bool MinorEdit = false;

        [XmlElement("syntaxId")]
        public string SyntaxId = "markdown/1.1";

        [XmlElement("hidden")]
        public bool Hidden = false;

        [XmlElement("content")]
        public string Content = "";
    }
}
