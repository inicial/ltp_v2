using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLW.SpamMashine.Structs;
using ltp_v2.Controls;

namespace TLW.SpamMashine.Forms
{
    public partial class frmConfiguration : Form
    {
        string SelectedFile;
        private Structs.stProcess ServiceSelectedValue = new TLW.SpamMashine.Structs.stProcess();
        private Structs.stProcess GetSelectetProcess
        {
            get  {
                if (dataGridView1.SelectedRows.Count > 0
                    && ((Structs.stProcess)dataGridView1.SelectedRows[0].DataBoundItem).ServiceID != ServiceSelectedValue.ServiceID)
                {
                    ServiceSelectedValue = (Structs.stProcess)dataGridView1.SelectedRows[0].DataBoundItem;
                }
                else
                {
                    if (ServiceSelectedValue.ServiceID == null)
                    {
                        ServiceSelectedValue = new Structs.stProcess();
                        ServiceSelectedValue.ServiceID = "T1";
                    }
                }

                if (ServiceSelectedValue.SQLCommands == null)
                    ServiceSelectedValue.SQLCommands = new stSqlList();

                return ServiceSelectedValue;
            }
        }

        public frmConfiguration()
        {
            InitializeComponent();
            edtExtBody.HighlightItems = Utilites.Consts.HL_HTML;
            LoadSettings();
        }

        private void LoadSettings()
        {
            Utilites.ProcessFiles SF = new TLW.SpamMashine.Utilites.ProcessFiles();

            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = SF.getServices().OrderBy(x => x.NextStartAfter).ToList();
            dataGridView1.Columns.AddColumns("ServiceID", "ServiceID");
            dataGridView1.Columns.AddColumns("NextStartAfter", "Следующий через", "dd Дней HH:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Structs.stSQL stSql;
            if (edtSqlCommands.SelectedItem != null)
            {
                stSql = (Structs.stSQL)edtSqlCommands.SelectedItem;
            }
            else
            {
                stSql = new Structs.stSQL();
            }

            frmSQLEditor _fSE = new frmSQLEditor(stSql);
            if (_fSE.ShowDialog() == DialogResult.OK)
            {
                if (edtSqlCommands.SelectedItem == null)
                {
                    ServiceSelectedValue.SQLCommands.Add(_fSE.stSQL);
                }
                else
                {
                    if (ServiceSelectedValue.SQLCommands.ContainsID(_fSE.oldSTSql.SqlID))
                    {
                        ServiceSelectedValue.SQLCommands.Remove(_fSE.oldSTSql.SqlID);
                    }
                    if (_fSE.stSQL.SqlID != "")
                        ServiceSelectedValue.SQLCommands.Add(_fSE.stSQL);
                }
            }
            edtSqlCommands.DataSource = null;
            edtSqlCommands.DataSource = ServiceSelectedValue.SQLCommands;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Text = GetSelectetProcess.FilePath;
            SelectedFile = GetSelectetProcess.FilePath;
            edtMailFrom.Text = GetSelectetProcess.MailFrom;
            edtMailTo.Text = GetSelectetProcess.MailTo;
            edtSubject.Text = GetSelectetProcess.Subject;
            edtExtBody.Text = GetSelectetProcess.extBody;
            edtIDService.Text = GetSelectetProcess.ServiceID;
            edtSqlCommands.DataSource = GetSelectetProcess.SQLCommands;

            edt_D1Beg.Text = GetSelectetProcess.RunAt.GetSettingByDay(1).BeginWork.ToString();
            edt_D2Beg.Text = GetSelectetProcess.RunAt.GetSettingByDay(2).BeginWork.ToString();
            edt_D3Beg.Text = GetSelectetProcess.RunAt.GetSettingByDay(3).BeginWork.ToString();
            edt_D4Beg.Text = GetSelectetProcess.RunAt.GetSettingByDay(4).BeginWork.ToString();
            edt_D5Beg.Text = GetSelectetProcess.RunAt.GetSettingByDay(5).BeginWork.ToString();
            edt_D6Beg.Text = GetSelectetProcess.RunAt.GetSettingByDay(6).BeginWork.ToString();
            edt_D7Beg.Text = GetSelectetProcess.RunAt.GetSettingByDay(7).BeginWork.ToString();

            edt_D1End.Text = GetSelectetProcess.RunAt.GetSettingByDay(1).EndWork.ToString();
            edt_D2End.Text = GetSelectetProcess.RunAt.GetSettingByDay(2).EndWork.ToString();
            edt_D3End.Text = GetSelectetProcess.RunAt.GetSettingByDay(3).EndWork.ToString();
            edt_D4End.Text = GetSelectetProcess.RunAt.GetSettingByDay(4).EndWork.ToString();
            edt_D5End.Text = GetSelectetProcess.RunAt.GetSettingByDay(5).EndWork.ToString();
            edt_D6End.Text = GetSelectetProcess.RunAt.GetSettingByDay(6).EndWork.ToString();
            edt_D7End.Text = GetSelectetProcess.RunAt.GetSettingByDay(7).EndWork.ToString();

            edt_D1IsWork.Checked = GetSelectetProcess.RunAt.GetSettingByDay(1).IsUse;
            edt_D2IsWork.Checked = GetSelectetProcess.RunAt.GetSettingByDay(2).IsUse;
            edt_D3IsWork.Checked = GetSelectetProcess.RunAt.GetSettingByDay(3).IsUse;
            edt_D4IsWork.Checked = GetSelectetProcess.RunAt.GetSettingByDay(4).IsUse;
            edt_D5IsWork.Checked = GetSelectetProcess.RunAt.GetSettingByDay(5).IsUse;
            edt_D6IsWork.Checked = GetSelectetProcess.RunAt.GetSettingByDay(6).IsUse;
            edt_D7IsWork.Checked = GetSelectetProcess.RunAt.GetSettingByDay(7).IsUse;

            edt_D1Interval.Value = GetSelectetProcess.RunAt.GetSettingByDay(1).IntervalWorkAtMinutes;
            edt_D2Interval.Value = GetSelectetProcess.RunAt.GetSettingByDay(2).IntervalWorkAtMinutes;
            edt_D3Interval.Value = GetSelectetProcess.RunAt.GetSettingByDay(3).IntervalWorkAtMinutes;
            edt_D4Interval.Value = GetSelectetProcess.RunAt.GetSettingByDay(4).IntervalWorkAtMinutes;
            edt_D5Interval.Value = GetSelectetProcess.RunAt.GetSettingByDay(5).IntervalWorkAtMinutes;
            edt_D6Interval.Value = GetSelectetProcess.RunAt.GetSettingByDay(6).IntervalWorkAtMinutes;
            edt_D7Interval.Value = GetSelectetProcess.RunAt.GetSettingByDay(7).IntervalWorkAtMinutes;
        }

        private void tsBtnReloadSettings_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void tsBtnCheck_Click(object sender, EventArgs e)
        {
            Utilites.ProcessParser PP = new Utilites.ProcessParser(GetSelectetProcess);
            // подмена времени
            //PP.UseBeg = new DateTime(2010, 12, 27, 17, 58, 26, 393);
            //PP.UseEnd = new DateTime(2010, 12, 27, 18, 00, 24, 543);

            if (!PP.CheckStartAtTime())
            {
                return;
            }

            stOutData OutData = PP.GetOutData();

            if (OutData != null)
                OutData.Save(PP);

            //stOutData LogData = new stOutData(GetSelectetProcess);
            //LogData.Add(new stPartner(-1, "i@i.ru", "", GetSelectetProcess.ServiceID, " CountInsert="),
            //    PP.UseBeg.Value.ToString("dd.MM.yyyyTHH.mm.ss.fff") + " "
            //    + PP.UseEnd.Value.ToString("dd.MM.yyyyTHH.mm.ss.fff"));

            //LogData.Insert2Base(PP.UseEnd.Value);

            MessageBox.Show("Тестирование завершено");
        }

        private void tsBtnSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SFDConfigFile = new SaveFileDialog())
            {
                SFDConfigFile.DefaultExt = "xml";
                SFDConfigFile.Filter = "XML File (*.xml)|*.xml";
                SFDConfigFile.AddExtension = true;
                SFDConfigFile.RestoreDirectory = true;
                SFDConfigFile.Title = "Сохранение файла конфигурации";
                SFDConfigFile.InitialDirectory = new System.IO.FileInfo(Application.ExecutablePath).Directory + "\\Services";
                if (SFDConfigFile.ShowDialog() == DialogResult.OK)
                {
                    if (SFDConfigFile.FileName == "")
                        return;
                    ServiceSelectedValue.FilePath = SFDConfigFile.FileName;
                }
            }

            ServiceSelectedValue.MailFrom = edtMailFrom.Text;
            ServiceSelectedValue.MailTo = edtMailTo.Text;
            ServiceSelectedValue.Subject = edtSubject.Text;
            ServiceSelectedValue.extBody = edtExtBody.Text;
            ServiceSelectedValue.ServiceID = edtIDService.Text;

            ServiceSelectedValue.RunAt.SetDay(1, new stRunAtDay(new stTime(edt_D1Beg.Text), new stTime(edt_D1End.Text), edt_D1IsWork.Checked, (int)edt_D1Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(2, new stRunAtDay(new stTime(edt_D2Beg.Text), new stTime(edt_D2End.Text), edt_D2IsWork.Checked, (int)edt_D2Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(3, new stRunAtDay(new stTime(edt_D3Beg.Text), new stTime(edt_D3End.Text), edt_D3IsWork.Checked, (int)edt_D3Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(4, new stRunAtDay(new stTime(edt_D4Beg.Text), new stTime(edt_D4End.Text), edt_D4IsWork.Checked, (int)edt_D4Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(5, new stRunAtDay(new stTime(edt_D5Beg.Text), new stTime(edt_D5End.Text), edt_D5IsWork.Checked, (int)edt_D5Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(6, new stRunAtDay(new stTime(edt_D6Beg.Text), new stTime(edt_D6End.Text), edt_D6IsWork.Checked, (int)edt_D6Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(7, new stRunAtDay(new stTime(edt_D7Beg.Text), new stTime(edt_D7End.Text), edt_D7IsWork.Checked, (int)edt_D7Interval.Value));

            Utilites.ProcessFiles SF = new TLW.SpamMashine.Utilites.ProcessFiles();
            SF.SaveXML(ServiceSelectedValue);
            LoadSettings();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            ServiceSelectedValue.MailFrom = edtMailFrom.Text;
            ServiceSelectedValue.MailTo = edtMailTo.Text;
            ServiceSelectedValue.Subject = edtSubject.Text;
            ServiceSelectedValue.extBody = edtExtBody.Text;
            ServiceSelectedValue.ServiceID = edtIDService.Text;

            ServiceSelectedValue.RunAt.SetDay(1, new stRunAtDay(new stTime(edt_D1Beg.Text), new stTime(edt_D1End.Text), edt_D1IsWork.Checked, (int)edt_D1Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(2, new stRunAtDay(new stTime(edt_D2Beg.Text), new stTime(edt_D2End.Text), edt_D2IsWork.Checked, (int)edt_D2Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(3, new stRunAtDay(new stTime(edt_D3Beg.Text), new stTime(edt_D3End.Text), edt_D3IsWork.Checked, (int)edt_D3Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(4, new stRunAtDay(new stTime(edt_D4Beg.Text), new stTime(edt_D4End.Text), edt_D4IsWork.Checked, (int)edt_D4Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(5, new stRunAtDay(new stTime(edt_D5Beg.Text), new stTime(edt_D5End.Text), edt_D5IsWork.Checked, (int)edt_D5Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(6, new stRunAtDay(new stTime(edt_D6Beg.Text), new stTime(edt_D6End.Text), edt_D6IsWork.Checked, (int)edt_D6Interval.Value));
            ServiceSelectedValue.RunAt.SetDay(7, new stRunAtDay(new stTime(edt_D7Beg.Text), new stTime(edt_D7End.Text), edt_D7IsWork.Checked, (int)edt_D7Interval.Value));

            Utilites.ProcessFiles SF = new TLW.SpamMashine.Utilites.ProcessFiles();
            SF.SaveXML(ServiceSelectedValue);
            LoadSettings();
        }
    }
}
