using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using TLW.SpamMashine.Structs;

namespace TLW.SpamMashine
{
    public partial class Service1 : ServiceBase
    {
        private Timer ExecuteTimer;
        #region Конструктор
        public Service1()
        {
            InitializeComponent();
            this.ExecuteTimer = new Timer(2000.0);
            this.ExecuteTimer.Elapsed += new ElapsedEventHandler(ExecuteTimer_Elapsed);
            this.ExecuteTimer.AutoReset = true;
            log.WriteToLog("Инициализация сервиса пройдена");
        }
        #endregion

        #region Методы
        private void Parsing(Utilites.ProcessFiles SF)
        {
            foreach (stProcess currProcess in SF.getServices()
                    .Where(x => x.NextStartAfter.TotalSeconds < 0)
                    .OrderBy(x => x.NextStartAfter))
            {
                string IDService = "";
                try
                {
                    IDService = currProcess.ServiceID;
                    Utilites.ProcessParser PP = new Utilites.ProcessParser(currProcess);
                    if (!PP.CheckStartAtTime())
                    {
                        continue;
                    }

                    stOutData OutData = PP.GetOutData();

                    if (OutData != null)
                    {
                        OutData.Insert2Base(PP.UseEnd.Value);
                        var CountInsert = OutData.Count.ToString();

                        stOutData LogData = new stOutData(currProcess);
                        LogData.Add(new stPartner(-1, "i@i.ru", "", currProcess.ServiceID, " CountInsert=" + CountInsert), 
                            PP.UseBeg.Value.ToString("dd.MM.yyyyTHH.mm.ss.fff") + " " 
                            + PP.UseEnd.Value.ToString("dd.MM.yyyyTHH.mm.ss.fff"));

                        LogData.Insert2Base(PP.UseEnd.Value);
                    }
                }
                catch (Exception err)
                {
                    log.WriteToError(IDService + " - " + err.Message);
                }
            }
        }
        #endregion

        private void ExecuteTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.ExecuteTimer.Stop();

            Utilites.ProcessFiles SF = new TLW.SpamMashine.Utilites.ProcessFiles();
            
            int NextStartTimer = 60000;
            try
            {
                Parsing(SF);
            }
            catch (Exception err)
            {
                log.WriteToError("Err00002" + err.Message);
            }
            try
            {
                NextStartTimer = (int)SF.getServices().Min(x => x.NextStartAfter.TotalMilliseconds);
                if (NextStartTimer <= 0) NextStartTimer = 1;
                if (NextStartTimer > 60000) NextStartTimer = 60000;
                this.ExecuteTimer.Interval = NextStartTimer;
            }
            catch (Exception err)
            {
                log.WriteToError("Ошибка при получение сл. времени " + err.Message);
                this.ExecuteTimer.Interval = 1000;
            }
            
            try
            {
                int CountSend  = Utilites.SendMessage.Start();
                if (CountSend > 0)
                    log.WriteToLog("Отправеленно данных: " + CountSend.ToString());
            }
            catch (Exception err)
            {
                log.WriteToError(err.Message);
            }

            this.ExecuteTimer.Start();
        }

        protected override void OnStart(string[] args)
        {
            ExecuteTimer.Start();
            log.WriteToLog("Сервис запущен");
        }

        protected override void OnStop()
        {
            ExecuteTimer.Stop();
            log.WriteToLog("Сервис остановлен");
        }
    }
}
