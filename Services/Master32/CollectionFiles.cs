using System;
using System.Collections;
using System.IO;
using Master32.Classes;

namespace Master32
{
    public class CollectionFiles : ArrayList, IDisposable
    {
        private string RootDirectory;

        public CollectionFiles()
        {
        }

        public CollectionFiles(CollectionFiles byCollectionFiles)
        {
            foreach (StructFile file in byCollectionFiles)
            {
                this.Add(file);
            }
        }

        public void CreateFromDirectory(frmUpdate sender, string PathFromScan)
        {
            this.RootDirectory = PathFromScan;
            if (new DirectoryInfo(PathFromScan).Exists)
            {
                string[] files = Directory.GetFiles(PathFromScan, "*.*", SearchOption.AllDirectories);
                int num = 0;
                foreach (string str in files)
                {
                    num++;
                    sender.UpdateProcessBar("Сканирование файлов в \r\n" + PathFromScan, files.Length, num);
                    FileInfo fileInfo = new FileInfo(str);
                    if (fileInfo.Exists)
                    {
                        StructFile file = new StructFile(fileInfo, this.RootDirectory);
                        base.Add(file);
                    }
                }
            }
        }

        public void CreateFromVariance(frmUpdate sender, CollectionFiles Source, CollectionFiles Destination)
        {
            int num = 0;
            CollectionFiles files = new CollectionFiles(Source);
            foreach (StructFile file in Destination)
            {
                num++;
                sender.UpdateProcessBar("Сравнение файлов \r\n", Destination.Count, num);
                bool flag = false;
                foreach (StructFile file2 in files)
                {
                    if (FileLibrary.VerifyTwoFile(file2, file))
                    {
                        flag = true;
                        files.Remove(file2);
                        break;
                    }
                }
                if (!flag)
                {
                    this.Add(file);
                }
            }
        }

        public void Dispose()
        {
            this.Clear();
        }

        public int IndexOfByFileName(string FileName)
        {
            foreach (StructFile file in this)
            {
                if (FileName.Trim().ToLower() == file.FileName.ToLower().Trim())
                {
                    return this.IndexOf(file);
                }
            }
            return -1;
        }
    }
}

