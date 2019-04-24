using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ltp_v2.Controls.Forms
{
    public class lwWaitScreen
    {
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private _frmWaitScreen FormWaitScreen;

        public lwWaitScreen()
        {
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_DoWork);

            backgroundWorker.WorkerReportsProgress = true;
        }

        public void Show()
        {
            backgroundWorker.RunWorkerAsync();
        }

        public void Close()
        {
            try
            {
                backgroundWorker.ReportProgress(100);
            }
            catch
            {
            }
        }

        void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (FormWaitScreen == null)
            {
                FormWaitScreen = new _frmWaitScreen();
                FormWaitScreen.ShowDialog();
                System.Threading.Thread.Sleep(500);
                FormWaitScreen.Dispose();
                FormWaitScreen = null;
            }
        }

        void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                System.Threading.Thread.Sleep(500);
                FormWaitScreen.CloseForm();
            }
        }
    }
}
