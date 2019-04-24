using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLW.SpamMashine.Forms
{
    public partial class frmSQLEditor : Form
    {
        #region переменные
        private Structs.stSQL _stSQL;
        private Structs.stSQL _oldValueSTSql;
        #endregion

        #region Свойства
        public Structs.stSQL stSQL
        {
            set { 
                _stSQL = value;
                edtSqlID.Text = _stSQL.SqlID;
                edtSQLCommand.Text = _stSQL.SQLCmd;
                edtExtBody.Text = _stSQL.extBody;
                edtRequiredPresent.Checked = _stSQL.RequiredPresent;
            }
            get { return _stSQL; }
        }

        public Structs.stSQL oldSTSql
        {
            get { return _oldValueSTSql; }
        }
        #endregion

        #region инициализация
        public frmSQLEditor(Structs.stSQL Value)
        {
            InitializeComponent();
            edtExtBody.HighlightItems = Utilites.Consts.HL_HTML;
            edtSQLCommand.HighlightItems = Utilites.Consts.HL_SQL;

            this.DialogResult = DialogResult.No;
            stSQL = Value;
            _oldValueSTSql = Value;
        }
        #endregion

        #region Обработка событий
        private void btnSave_Click(object sender, EventArgs e)
        {
            _stSQL.SqlID = edtSqlID.Text;
            _stSQL.SQLCmd = edtSQLCommand.Text;
            _stSQL.extBody = edtExtBody.Text;
            _stSQL.RequiredPresent = edtRequiredPresent.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void btnDeleteSQL_Click(object sender, EventArgs e)
        {
            _stSQL.SqlID = "";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion
    }
}
