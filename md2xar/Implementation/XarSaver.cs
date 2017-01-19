using System.IO;
using System.IO.Compression;
using md2xar.XAR;

namespace md2xar.Implementation
{
    public class XarSaver
    {
        public static void SaveToXar(string filename, XarArchive archive)
        {
            using (FileStream zipStream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                using (ZipArchive zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    WriteObject("package.xml", zipArchive, archive.Package);
                    
                    foreach (XarDocument document in archive.Documents)
                    {
                        WriteObject(document.Path, zipArchive, document.Document);
                    }
                }
            }
        }

        private static void WriteObject<T>(string name, ZipArchive archive, T obj)
        {
            ZipArchiveEntry entry = archive.CreateEntry(name);
            using (BinaryWriter writer = new BinaryWriter(entry.Open()))
            {
                writer.Write(Serialization.Serialize(obj));
            }
        }
    }
}
