using System.Collections.Generic;
using System.IO;
using System.Linq;
using md2xar.XAR;

namespace md2xar.Implementation
{
    public class Parser
    {
        public static List<XarDocument> ParseFolder(string path, string locale, bool recursive, List<string> reference)
        {
            List<XarDocument> documents = new List<XarDocument>();
            documents.AddRange(GetDocuments(path, locale, reference));

            if (!recursive) return documents;

            List<string> subReference = new List<string>();
            subReference.AddRange(reference);
            subReference.Add(new DirectoryInfo(path).Name);

            foreach (string folder in Directory.GetDirectories(path))
            {
                if (new DirectoryInfo(folder).Name != ".git")
                {
                    documents.AddRange(ParseFolder(folder, locale, true, subReference));
                }
            }

            return documents;
        }

        private static IEnumerable<XarDocument> GetDocuments(string path, string locale, List<string> reference)
        {
            List<XarDocument> documents = new List<XarDocument>();

            string folderName = new DirectoryInfo(path).Name;

            List<string> files = Directory.GetFiles(path, "*.md").ToList();
            if (!files.Contains(Path.Combine(path, "Home.md"))) files.Add("Home.md");

            List<string> currentReference = new List<string>();
            currentReference.AddRange(reference);
            currentReference.Add(folderName);

            foreach (string file in files)
            {
                string docName = Path.GetFileNameWithoutExtension(file);
                XarDocument page = new XarDocument();

                if (docName == "Home")
                {
                    page.Document.Parent = reference.Count == 0
                        ? "Main.WebHome"
                        : string.Join(".", reference) + ".WebHome";

                    docName = folderName;
                    page.Path = string.Join(@"\", currentReference) + @"\WebHome.xml";
                    page.Document.AttributeReference = string.Join(".", currentReference) + ".WebHome";
                    page.Document.Web = string.Join(".", currentReference);
                }
                else
                {
                    page.Document.Parent = string.Join(".", currentReference) + ".WebHome";
                    page.Path = string.Join(@"\", currentReference) + @"\" + docName + @"\WebHome.xml";
                    page.Document.AttributeReference = string.Join(".", currentReference) + "." + docName + ".WebHome";
                    page.Document.Web = string.Join(".", currentReference) + "." + docName;
                }
                
                page.Document.Name = docName;
                page.Document.Title = docName;
                page.Document.DefaultLanguage = locale;

                if (File.Exists(file))
                {
                    page.Document.Content = File.ReadAllText(file);
                }

                documents.Add(page);
            }

            return documents;
        }
    }
}
