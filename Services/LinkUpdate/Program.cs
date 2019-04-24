using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWshRuntimeLibrary;
using System.IO;
namespace LinkUpdate
{
    class Program
    {
        private class Link
        {
            public string PathLink;
            public FileInfo PathLinkFileInfo
            {
                get { return new FileInfo(PathLink); }
            }

            public string Target;
            public FileInfo TargetFileInfo
            {
                get { return new FileInfo(Target); }
            }
            public string TargetFileName
            {
                get{
                    return TargetFileInfo.Name;
                }
            }

            public override string ToString()
            {
                return PathLinkFileInfo.Name;
            }
        }

        static private Link ConvertFileToLinkProperty(string path)
        {
            WshShell shell = new WshShell();
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(path);
            return new Link() { Target = link.TargetPath, PathLink = path };
        }

        static private void SetTargetPathToLink(string PathLink, string targetPath)
        {
            WshShell shell = new WshShell();
            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(PathLink);
            link.TargetPath = targetPath;
            link.Save();
        }

        static private Link[] GetLinksInDirectory(string path)
        {
            var searchFile = new string[] { "*.lnk" };
            return searchFile.SelectMany(x => System.IO.Directory.GetFiles(path, x, System.IO.SearchOption.AllDirectories))
                        .Select(x => ConvertFileToLinkProperty(x))
                        .Where(x => x.TargetFileInfo.Directory.Name.ToLower() == "master")
                        .ToArray();
        }

        static private void Rechange(string path)
        {
            Console.WriteLine(path);
            try
            {
                var Links = GetLinksInDirectory(path);
                Console.WriteLine("   count files " + Links.Count());
                if (Links.Length > 0)
                {
                    bool targetChange = false;
                    foreach (var linkUpdate in Links.Where(x => x.TargetFileInfo.Name.ToLower() == "ma.exe" || x.TargetFileInfo.Name.ToLower() == "master.exe"))
                    {
                        SetTargetPathToLink(linkUpdate.PathLink, linkUpdate.TargetFileInfo.Directory.FullName + "\\master32.exe");
                        targetChange = true;
                    }

                    if (targetChange)
                        Links = GetLinksInDirectory(path);

                    var groupedLinks = Links.GroupBy(x => x.TargetFileName.ToLower());

                    foreach (var linkDoubleDel in groupedLinks.Where(x => x.Count() > 1))
                    {
                        var arrayModLink = linkDoubleDel.ToArray();
                        for (int i = 1; i < arrayModLink.Length; i++)
                        {
                            System.IO.File.Delete(arrayModLink[i].PathLink);
                        }
                    }

                    foreach (var linkRename in groupedLinks)
                    {
                        var arrayModLink = linkRename.ToArray();
                        System.IO.File.Move(arrayModLink[0].PathLink, arrayModLink[0].PathLinkFileInfo.Directory.FullName + "\\Мастер-тур.lnk");
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        static void Main(string[] args)
        {
            var userDir = System.Environment.GetEnvironmentVariable("USERPROFILE");

                Console.WriteLine(" -- " + userDir);

                Rechange(userDir + "\\Desktop");
                Rechange(userDir + "\\Рабочий стол");
                Rechange(userDir + "\\Главное меню");
                Rechange(userDir + "\\Start Menu");
                userDir = System.Environment.GetEnvironmentVariable("appdata");
                Rechange(userDir + @"\Microsoft\Internet Explorer\Quick Launch");
                Rechange(userDir + @"\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar\");
        }
    }
}
