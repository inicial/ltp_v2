using System;
using System.Runtime.InteropServices;
using System.IO;

namespace Master32.Classes
{
    public class StructFile
    {
        private string RootDirectory;
        public string FullPath;
        public string FileName;
        public string Folder;
        public string Extension;
        public long Size;
        public DateTime CreateDate;
        public bool IsDelete;
        public bool IsCopy;

        public StructFile(FileInfo fileInfo, string RootDirectory)
        {
            this.RootDirectory = FileLibrary.NormalizePath(RootDirectory);
            this.FullPath = FileLibrary.NormalizePath(fileInfo.Directory.FullName);
            this.FileName = fileInfo.Name.ToLower();
            this.Folder = FileLibrary.NormalizePath(fileInfo.Directory.FullName).Replace(FileLibrary.NormalizePath(RootDirectory), "");
            this.Extension = fileInfo.Extension.ToLower();
            this.Size = fileInfo.Length;
            this.CreateDate = fileInfo.LastWriteTime;
        }

        public override string ToString()
        {
            return (this.FullPath + this.FileName);
        }
    }
}
