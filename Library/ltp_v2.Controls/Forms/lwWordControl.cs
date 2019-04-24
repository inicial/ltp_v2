using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace ltp_v2.Controls.Forms
{
    public class DocumentInstanceException : Exception
    { }

    public class ValidDocumentException : Exception
    { }

    public class WordInstanceException : Exception
    { }

    public class lwWordControl : UserControl
    {
        #region Импорт DLL методов
        [DllImport("user32.dll")]
        public static extern int FindWindow(string strclassName, string strWindowName);

        [DllImport("user32.dll")]
        static extern int SetParent(int hWndChild, int hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
            int hWnd,               // handle to window
            int hWndInsertAfter,    // placement-order handle
            int X,                  // horizontal position
            int Y,                  // vertical position
            int cx,                 // width
            int cy,                 // height
            uint uFlags             // window-positioning options
        );

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        static extern bool MoveWindow(
            int hWnd,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            bool bRepaint
        );
        #endregion

        #region Константы
        const int SWP_DRAWFRAME = 0x20;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;
        #endregion

        #region Переменные
        private Microsoft.Office.Interop.Word.Document document;
        private Word.ApplicationClass wd = null;
        private string filename = null;
        private bool deactivateevents = false;
        private System.ComponentModel.Container components = null;

        object False = false;
        object True = false;
        object Missing = System.Reflection.Missing.Value;
        object Null = null;
        object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
        #endregion

        #region Свойства
        public int wordWnd = 0;
        #endregion

        #region Конструктор
        public lwWordControl()
		{
			InitializeComponent();
        }
		protected override void Dispose( bool disposing )
		{
			CloseControl();
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		private void InitializeComponent()
		{
			this.Name = "WinWordControl";
			this.Size = new System.Drawing.Size(440, 336);
			this.Resize += new System.EventHandler(this.OnResize);			
		}
		#endregion

		public void PreActivate()
		{
            //if(wd == null) 
            //    wd = new Word.ApplicationClass();
		}

        public void CloseControl()
        {
            deactivateevents = true;
            document.Close(ref Null, ref Null, ref Null);
            wd.Quit(ref False, ref Null, ref Null);
            wd = null;
            deactivateevents = false;
        }

		private void OnClose(Microsoft.Office.Interop.Word.Document doc, ref bool chancel)
		{
			if(!deactivateevents)
			{
				chancel=true;
			}
		}

		private void OnOpenDoc(Microsoft.Office.Interop.Word.Document doc)
		{
			OnNewDoc(doc);
		}

		private void OnNewDoc(Microsoft.Office.Interop.Word.Document doc)
		{
            if (!deactivateevents)
            {
                deactivateevents = true;
                doc.Close(ref Null, ref Null, ref Null);
                deactivateevents = false;
            }
		}

		private void OnQuit()
		{
            document = null;
            wordWnd = 0;
		}

		private void OnResize(object sender, System.EventArgs e)
		{
            if (!this.DesignMode)
                MoveWindow(wordWnd, -5, -33, this.Bounds.Width + 10, this.Bounds.Height + 57, true);
		}

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (base.DesignMode)
                e.Graphics.Clear(Color.Black);
            else
                base.OnPaintBackground(e);
        }

        #region Методы
        public void LoadDocument(string t_filename)
        {
            if (this.DesignMode)
                return;

            deactivateevents = true;
            filename = t_filename;

            if (wd == null) 
                wd = new Microsoft.Office.Interop.Word.ApplicationClass();
            try
            {
                wd.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(OnClose);
                wd.DocumentOpen += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentOpenEventHandler(OnOpenDoc);
                wd.ApplicationEvents2_Event_Quit += new Word.ApplicationEvents2_QuitEventHandler(OnQuit);
                wd.ApplicationEvents2_Event_DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents2_DocumentBeforeCloseEventHandler(OnClose);
            }
            catch { }

            if (document != null)
            {
                try
                {
                    wd.Documents.Close(ref Null, ref Null, ref Null);
                }
                catch { }
            }

            if (wordWnd == 0)
                wordWnd = FindWindow("Opusapp", null);

            if (wordWnd != 0)
            {
                SetParent(wordWnd, this.Handle.ToInt32());

                object fileName = filename;
                object newTemplate = false;
                object docType = 0;
                object readOnly = true;
                object isVisible = true;

                try
                {
                    if (wd == null)
                    {
                        throw new WordInstanceException();
                    }

                    if (wd.Documents == null)
                    {
                        throw new DocumentInstanceException();
                    }

                    if (wd != null && wd.Documents != null)
                    {
                        document = wd.Documents.Open(ref fileName, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing, ref Missing);
                    }

                    if (document == null)
                    {
                        throw new ValidDocumentException();
                    }
                }
                catch
                {
                }

                try
                {
                    wd.ActiveWindow.DisplayRightRuler = true;
                    wd.ActiveWindow.DisplayScreenTips = false;
                    wd.ActiveWindow.DisplayVerticalRuler = true;
                    wd.ActiveWindow.ActivePane.DisplayRulers = true;
                    wd.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;
                }
                catch
                {

                }

                try
                {
                    wd.Visible = true;
                    wd.Activate();

                    SetWindowPos(wordWnd, this.Handle.ToInt32(), 0, 0, this.Bounds.Width + 20, this.Bounds.Height + 20, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME);
                    MoveWindow(wordWnd, -5, -33, this.Bounds.Width + 10, this.Bounds.Height + 57, true);
                }
                catch
                {
                    MessageBox.Show("Error: do not load the document into the control until the parent window is shown!");
                }
                this.Parent.Focus();

            }
            deactivateevents = false;
        }

        public void SaveDocument()
        {
            wd.ActiveDocument.Save();
        }

        public void InsertText(string Text)
        {
            wd.Selection.TypeText(Text);
        }

        public void ReplaceText(string from, string to)
        {
            var docFind = wd.Selection.Find;
            docFind.ClearFormatting();
            docFind.Text = from;
            docFind.Replacement.Text = to;
            docFind.Wrap = Word.WdFindWrap.wdFindContinue;

            wd.Selection.Find.Execute(ref Missing, ref Missing, ref Missing,
                                ref Missing, ref Missing, ref Missing, ref Missing,
                                ref Missing, ref Missing, ref Missing, ref replaceAll,
                                ref Missing, ref Missing, ref Missing, ref Missing);
        }

        public void InsertFieldComment(string CommentMsg)
        {
            object Text = "COMMENTS \"" + CommentMsg +"\" ";
            object type = Word.WdFieldType.wdFieldEmpty;
            wd.Selection.Fields.Add(wd.Selection.Range, ref type, ref Text, ref True);
            InsertText(" ");
        }
        #endregion
    }
}
