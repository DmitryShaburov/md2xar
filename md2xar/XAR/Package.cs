using System.Collections.Generic;
using System.Xml.Serialization;

namespace md2xar.XAR
{
    [XmlRoot(ElementName = "package")]
    public class Package
    {
        public class Info
        {
            [XmlElement("name")]
            public string Name = "md2wiki export results";

            [XmlElement("description")]
            public string Description = "";

            [XmlElement("licence")]
            public string Licence = "";

            [XmlElement("author")]
            public string Author = "";

            [XmlElement("version")]
            public string Version = "";

            [XmlElement("backupPack")]
            public bool BackupPack = false;

            [XmlElement("preserveVersion")]
            public bool PreserveVersion = false;
        }

        public class File
        {
            [XmlAttribute("defaultAction")]
            public string DefaultAction = "0";

            [XmlAttribute("language")]
            public string Language = "";

            [XmlText]
            public string Path;
        }

        public class FilesList
        {
            [XmlElement("file")]
            public List<File> FileList = new List<File>();
        }

        [XmlElement("infos")]
        public Info Infos = new Info();

        [XmlElement("files")]
        public FilesList Files = new FilesList();
    }
}
