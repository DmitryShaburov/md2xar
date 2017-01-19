using System;
using System.Collections.Generic;
using System.IO;
using md2xar.Implementation;
using md2xar.XAR;

namespace md2xar
{
    public class EntryPoint
    {
        public static int Main(string[] args)
        {
            if (!ValidateArgs(args))
            {
                DisplayHelp();
                return 1;
            }

            DoJob(args);
            return 0;
        }

        private static bool ValidateArgs(IReadOnlyList<string> args)
        {
            return (args.Count == 3) && Directory.Exists(args[0]);
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("dotnet run -- <md wiki directory> <out file> <locale>");
            Console.WriteLine("Example:");
            Console.WriteLine(@"dotnet run -- C:\MyOldWiki wiki.xar en_US");
        }

        private static void DoJob(IReadOnlyList<string> args)
        {
            XarArchive archive = new XarArchive();

            Console.WriteLine($"Parsing: {args[0]}");
            archive.Documents.AddRange(Parser.ParseFolder(args[0], args[2], false, new List<string>()));

            foreach (string folder in Directory.GetDirectories(args[0]))
            {
                if (new DirectoryInfo(folder).Name != ".git")
                {
                    Console.WriteLine($"Parsing: {folder}");
                    archive.Documents.AddRange(Parser.ParseFolder(folder, args[2], true, new List<string>()));
                }
            }

            foreach (XarDocument document in archive.Documents)
            {
                archive.Package.Files.FileList.Add(new Package.File { Path = document.Document.AttributeReference });
            }

            Console.WriteLine("Packing result...");
            XarSaver.SaveToXar(args[1], archive);

            Console.WriteLine($"Done! Result: {args[1]}");
        }
    }
}
