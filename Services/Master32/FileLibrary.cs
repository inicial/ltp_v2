using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Master32.Classes;

namespace Master32
{
    public class FileLibrary
    {
        public static void Change_to_bak(string value)
        {
            File.Move(value, value + ".bak");
        }

        private static void CheckDirectory(string File)
        {
            string fullName = new FileInfo(File).Directory.FullName;
            DirectoryInfo info = new DirectoryInfo(fullName);
            if (!info.Exists)
            {
                if ((info.Parent != null) && (info.Parent != info.Root))
                {
                    CheckDirectory(info.Parent.FullName);
                }
                Directory.CreateDirectory(fullName);
            }
        }

        public static void Delete(string value)
        {
            try
            {
                new FileInfo(value).Attributes = FileAttributes.Normal;
                File.Delete(value);
            }
            catch { }
        }

        public static string NormalizePath(string value)
        {
            string str = "";
            DirectoryInfo parent = new DirectoryInfo(value);
            while (parent.Parent != null)
            {
                str = parent.Name + @"\" + str;
                parent = parent.Parent;
            }
            return (parent.Root + @"\" + str).ToLower();
        }

        public static bool VerifyTwoFile(StructFile firstFile, StructFile secondFile)
        {
            return ((firstFile.FileName == secondFile.FileName) && ((((firstFile.Folder == secondFile.Folder) && (firstFile.Size == secondFile.Size)) && ((firstFile.CreateDate.Date == secondFile.CreateDate.Date) && (firstFile.CreateDate.Hour == secondFile.CreateDate.Hour))) && (firstFile.CreateDate.Minute == secondFile.CreateDate.Minute)));
        }

        public class CopyFileHelper
        {
            private bool cancelCopyValue;
            private string destinationFile;
            private const int ERROR_REQUEST_ABORTED = 0x4d3;
            private string sourceFile;
            private Thread workingThread;

            public event SetLongCallback ChunkCopied;
            public event SetVoidCallback CopyCanceled;
            public event SetVoidCallback CopyCompleted;
            public event SetLongCallback CopyStarted;
            public event SetIntCallback ErrorCopy;

            public void CancelCopy()
            {
                this.cancelCopyValue = true;
            }

            private void CopyThreadProc()
            {
                FileLibrary.CheckDirectory(this.destinationFile);
                PROGRESS_ROUTINE lpProgressRoutine = new PROGRESS_ROUTINE(this.FileCopyProgressRoutine);
                if (!NativeMethods.CopyFileEx(this.sourceFile, this.destinationFile, lpProgressRoutine, IntPtr.Zero, ref this.cancelCopyValue, CopyFileFlag.NONE))
                {
                    int error = Marshal.GetLastWin32Error();
                    if (error != 0x4d3)
                    {
                        if (ErrorCopy != null)
                            this.ErrorCopy(error);
                    }
                    if (this.CopyCanceled != null)
                    {
                        this.CopyCanceled();
                    }
                }
                else
                {
                    FileInfo info = new FileInfo(this.destinationFile);
                    FileInfo info2 = new FileInfo(this.sourceFile);
                    if (info.Exists && info2.Exists)
                    {
                        info.Attributes = FileAttributes.Normal;
                        info.LastWriteTime = Convert.ToDateTime(string.Concat(new object[] { info2.LastWriteTime.Date.ToString("dd-MM-yyyy"), " ", info2.LastWriteTime.Hour, ":", info2.LastWriteTime.Minute, ":00" }));
                        if (this.CopyCompleted != null)
                        {
                            this.CopyCompleted();
                        }
                    }
                }
            }

            private ProgressRoutineResult FileCopyProgressRoutine(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, int dwStreamNumber, int dwCallbackReason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData)
            {
                if (TotalBytesTransferred != 0L)
                {
                    if (this.ChunkCopied != null)
                    {
                        this.ChunkCopied(TotalBytesTransferred);
                    }
                }
                else if (this.CopyStarted != null)
                {
                    this.CopyStarted(TotalFileSize);
                }
                return (this.cancelCopyValue ? ProgressRoutineResult.PROGRESS_CANCEL : ProgressRoutineResult.PROGRESS_CONTINUE);
            }

            public void StartCopy(string sourceFileName, string destinationFileName)
            {
                this.sourceFile = sourceFileName;
                this.destinationFile = destinationFileName;
                this.cancelCopyValue = false;
                this.workingThread = new Thread(new ThreadStart(this.CopyThreadProc));
                this.workingThread.Start();
            }

            [Flags]
            private enum CopyFileFlag
            {
                COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 8,
                COPY_FILE_FAIL_IF_EXISTS = 1,
                COPY_FILE_OPEN_SOURCE_FOR_WRITE = 4,
                COPY_FILE_RESTARTABLE = 2,
                NONE = 0
            }

            public class ExceptionEventArgs : EventArgs
            {
                public string message;
            }

            private class NativeMethods
            {
                private NativeMethods()
                {
                }

                [return: MarshalAs(UnmanagedType.Bool)]
                [DllImport("Kernel32.dll", SetLastError=true)]
                public static extern bool CopyFileEx(string lpExistingFileName, string lpNewFileName, FileLibrary.CopyFileHelper.PROGRESS_ROUTINE lpProgressRoutine, IntPtr lpData, [MarshalAs(UnmanagedType.Bool)] ref bool pbCancel, FileLibrary.CopyFileHelper.CopyFileFlag dwCopyFlags);
            }

            private delegate FileLibrary.CopyFileHelper.ProgressRoutineResult PROGRESS_ROUTINE(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, int dwStreamNumber, int dwCallbackReason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData);

            private enum ProgressRoutineResult
            {
                PROGRESS_CONTINUE,
                PROGRESS_CANCEL,
                PROGRESS_STOP,
                PROGRESS_QUIET
            }
        }
    }
}

