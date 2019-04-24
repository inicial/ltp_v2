using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using System.Reflection;
using Master32.Classes;

namespace Master32
{
    public partial class frmUpdate : Form
    {
        #region Свойства
        private CollectionFiles cf_Source_for_Copy;
        private int CountReStarts = 1;

        private FileLibrary.CopyFileHelper cp;
        private string CurrentFile = "";
        private long CurrentFileSize = 0L;
        private string DestinationFolder = "";
        private string SourceFolder = "";
        #endregion

        #region Методы
        /// <summary>
        /// /// Метод вызванный при изменение % копирования данных
        /// </summary>
        /// <param name="Value"></param>
        private void CheckLiblrary(string destinationFolder)
        {
            var keyName = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client";
            var key = Registry.LocalMachine.OpenSubKey(keyName);
            // если ключа нет, тут будет null – значит фреймворк не установлен
            if (key == null)
            {
                MessageBox.Show("Не установлена .Net4, использование некоторых программ может быть затруднено, обратитесь по тел 1500");
            }

            var checkLibPath = destinationFolder + "Master32.exe.CheckLibrary";
            if (new System.IO.FileInfo(checkLibPath).Exists)
            {
                var stream = new System.IO.StreamReader(checkLibPath);
                var libArray = stream.ReadToEnd();
                stream.Close();
                stream = null;
                foreach (var libItem in libArray.Split('\n'))
                {
                    string LibName = libItem.Replace("\r", "").Replace("\n", "");
                    try
                    {
                        Assembly sampleAssembly = Assembly.Load(LibName);
                    }
                    catch
                    {
                        MessageBox.Show("Не установлен \r\n" + LibName + "\r\n, использование некоторых программ может быть затруднено, обратитесь по тел 1500");
                    }
                }

            }
        }

        private bool BreakStartUpdate(string sourceFolder, string logFileName, int ip)
        {
            SingleInstance instance = new SingleInstance();

            if (System.Windows.Forms.SystemInformation.TerminalServerSession && ip != 140)
            {
                lblProcess.Text = "Терминальная сессия";
                progressBar1.Visible = false;
                return true;
            }

            if (new FileInfo(sourceFolder).Directory.Exists)
            {
                FileInfo info = new FileInfo(logFileName);

                if (info.Exists && (info.LastWriteTime.Date == DateTime.Now.Date))
                {
                    return true;
                }
            }

            foreach (Process process in Process.GetProcesses(Environment.MachineName))
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    if (process.ProcessName.ToLower() == "ma" ||
                        process.ProcessName.ToLower() == "master32_")
                    {
                        MessageBox.Show("Для обновления мастер-тур закройте все программы мастер-тур");
                        return true;
                    }
                }
            }
            if (!instance.FirstInstance)
            {
                return true;
            }

            return false;
        }

        private void SetAutomaticBackground()
        {
            if (DateTime.Now.Month == 12 && DateTime.Now.Day > 13)
            {
                var ny = (new DateTime(DateTime.Now.Year + 1, 1, 1) - DateTime.Now);
                //int TotalH = (int)Math.Round(Math.Abs(ny.TotalHours)) / 24;
                int TotalD = (int)Math.Round(Math.Abs(ny.TotalDays)) - 1;

                lbl_Holiday.Text = "До Нового года осталось " + TotalD.ToString() + "дн. ";// +TotalH.ToString() + " час.";
                this.BackgroundImage = global::Master32.Properties.Resources.NewYear;
            }

            if (DateTime.Now.Month == 1 && DateTime.Now.Day < 8)
            {
                lbl_Holiday.Text = "С Новым годом Уважаемые.";
                this.BackgroundImage = global::Master32.Properties.Resources.NewYear;
            }
        }

        private void CopyFirstFile()
        {
            if (base.InvokeRequired)
            {
                base.BeginInvoke(new SetVoidCallback(CopyFirstFile));
                return;
            }
            if (this.cf_Source_for_Copy.Count > 0)
            {
                StructFile file = (StructFile)this.cf_Source_for_Copy[0];
                this.cf_Source_for_Copy.RemoveAt(0);
                this.CurrentFile = "Копирование файла " + file.Folder + file.FileName;
                this.CurrentFileSize = file.Size;
                this.cp.StartCopy(file.ToString(), this.DestinationFolder + @"\" + file.Folder + file.FileName);
            }
            else
            {
                cfh_CopyEnd();
            }
        }
        #endregion

        #region Конструктор
        public frmUpdate(string destinationFolder, string sourceFolder, string logFileName, int ip)
        {
            this.InitializeComponent();

            CheckLiblrary(destinationFolder);

            this.lblProcess.Text = "";
            this.lbl_Holiday.Text = "";
            SetAutomaticBackground();
            
            //CheckLiblrary();
                
            if (BreakStartUpdate(sourceFolder, logFileName, ip))
            {
                BreakTimer.Enabled = true;
                return;
            }
            
            this.SourceFolder = sourceFolder;
            this.DestinationFolder = destinationFolder;
            this.CopyTimer.Enabled = true;
        }
        #endregion

        #region Обработка событий
        #region Потоковые результаты
        private void cfh_ErrorCopy(int exceptionW32Code)
        {
            if (base.InvokeRequired)
            {
                base.BeginInvoke(new SetIntCallback(this.cfh_ErrorCopy), exceptionW32Code);
                return;
            }

            if (exceptionW32Code == 2 && CountReStarts < 2)
            {
                CountReStarts++;
                CopyTimer.Enabled = true;
                return;
            }
            throw new Exception(new Win32Exception(exceptionW32Code).Message);
        }

        private void cfh_UpdatePosition(long e)
        {
            if (base.InvokeRequired)
            {
                base.BeginInvoke(new SetLongCallback(cfh_UpdatePosition), e);
                return;
            }
            if (e > int.MaxValue)
                e = int.MaxValue - 1;
            UpdateProcessBar(this.CurrentFile, (int)this.CurrentFileSize, (int)e);
        }

        private void cfh_CopyEnd()
        {
            if (base.InvokeRequired)
            {
                base.BeginInvoke(new SetVoidCallback(this.cfh_CopyEnd));
                return;
            }

            if (CopyTimer.Enabled)
                return;

            base.Close();
        }

        private void thread_cfh_CopyStarted(long e)
        {
            this.CurrentFileSize = e;
        }
        #endregion


        public void UpdateProcessBar(string Text, int MaxValue, int Value)
        {
            this.lblProcess.Text = Text;
            this.progressBar1.Maximum = MaxValue;
            if (this.progressBar1.Maximum < Value)
            {
                this.progressBar1.Maximum = Value + 1;
            }
            this.progressBar1.Value = Value;
            this.Refresh();
        }

        private void CopyTimer_Tick(object sender, EventArgs e)
        {
            this.CopyTimer.Enabled = false;
            
            CollectionFiles cf_Source = new CollectionFiles();
            cf_Source.CreateFromDirectory(this, this.SourceFolder);

            CollectionFiles cf_Destination = new CollectionFiles();
            cf_Destination.CreateFromDirectory(this, this.DestinationFolder);

            CollectionFiles cf_Destination_for_Delete = new CollectionFiles();
            cf_Destination_for_Delete.CreateFromVariance(this, cf_Source, cf_Destination);

            int num = 0;
            foreach (StructFile file in cf_Destination_for_Delete)
            {
                num++;
                UpdateProcessBar("Удаление файлов", cf_Destination_for_Delete.Count, num);
                FileLibrary.Change_to_bak(file.ToString());
                FileLibrary.Delete(file.ToString() + ".bak");
            }

            this.cf_Source_for_Copy = new CollectionFiles();
            this.cf_Source_for_Copy.CreateFromVariance(this, cf_Destination, cf_Source);


            if (this.cf_Source_for_Copy.Count == 0)
            {
                this.cfh_CopyEnd();
                return;
            }

            cp = new FileLibrary.CopyFileHelper();
            this.cp.CopyStarted += new SetLongCallback(this.thread_cfh_CopyStarted);
            this.cp.ChunkCopied += new SetLongCallback(this.cfh_UpdatePosition);
            this.cp.CopyCanceled += new SetVoidCallback(this.cfh_CopyEnd);
            this.cp.ErrorCopy += new Classes.SetIntCallback(cfh_ErrorCopy);
            this.cp.CopyCompleted += new SetVoidCallback(this.CopyFirstFile);

            CopyFirstFile();
        }

        private void BreakTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

