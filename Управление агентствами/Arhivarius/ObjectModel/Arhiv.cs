namespace Arhivarius.ObjectModel
{
    using System;
    using System.Linq;
    using ltp_v2.Controls;
    using ltp_v2.Framework;
using System.Data.Linq;
    using System.Collections.Generic;

    partial class ArhivDataContext
    {
        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
        {
            foreach (object itInsert in this.GetChangeSet().Inserts)
            {
                if (itInsert.GetType() == typeof(ArhiveDocument))
                {
                    ArhiveDocument arhInsItem = (ArhiveDocument)itInsert;
                    if (arhInsItem.DocumentType.ARDT_CanHaveChildren && !arhInsItem.DocumentType.ARDT_Code.IsNullOrEmptyOrSpace())
                    {
                        var q = from xA in ArhiveDocuments
                                where xA.DocumentType == arhInsItem.DocumentType
                                select xA.ARH_PkgNum;

                        if (q.Count() == 0)
                            arhInsItem.ARH_PkgNum = 1;
                        else
                            arhInsItem.ARH_PkgNum = q.Max() + 1;

                        string NumStr = arhInsItem.ARH_PkgNum.ToString();
                        while (NumStr.Length < 5)
                            NumStr = "0" + NumStr;

                        arhInsItem.ARH_Number = arhInsItem.DocumentType.ARDT_Code + "-" + NumStr;
                    }
                }
            }
            foreach (object itInsert in this.GetChangeSet().Updates)
            {
                if (itInsert.GetType() == typeof(ArhiveDocument))
                {
                    ArhiveDocument arhInsItem = (ArhiveDocument)itInsert;
                    arhInsItem.ARH_UserName = SqlConnection.ConnectionUserInformation.US_FullName;
                }
            }
            base.SubmitChanges(failureMode);
        }

        public bool PresetSubmint(Type byType)
        {
            foreach (object submintItem in this.GetChangeSet().Inserts)
            {
                if (submintItem.GetType() == byType)
                    return true;
            }
            foreach (object submintItem in this.GetChangeSet().Updates)
            {
                if (submintItem.GetType() == byType)
                    return true;
            }
            foreach (object submintItem in this.GetChangeSet().Deletes)
            {
                if (submintItem.GetType() == byType)
                    return true;
            }
            return false;
        }

        public List<ArhiveDocument> FindInSubmintItems(dict_Document findItem)
        {
            List<ArhiveDocument> result = new List<ArhiveDocument>();
            foreach (object insertItems in this.GetChangeSet().Inserts)
            {
                if (insertItems is ArhiveDocument)
                {
                    var x = (insertItems as ArhiveDocument);
                    if (x.ARH_Id == findItem.Id
                        || x.ARH_CodeKey == findItem.Id
                            && x.ARH_Number == findItem.Number)
                        result.Add(insertItems as ArhiveDocument);
                }
            }

            foreach (object updatedItems in this.GetChangeSet().Updates)
            {
                if (updatedItems is ArhiveDocument)
                {
                    var x = (updatedItems as ArhiveDocument);
                    if (x.ARH_Id == findItem.Id
                        || x.ARH_CodeKey == findItem.Id
                            && x.ARH_Number == findItem.Number)
                        result.Add(updatedItems as ArhiveDocument);
                }
            }
            return result;
        }
    }

    partial class ArhiveDocument
    {
        partial void OnCreated()
        {
            this._ARH_CRDate = DateTime.Now;
            this._ARH_UserName = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName;
        }

        public override string ToString()
        {
            return this.ARH_Number;
        }

        public string DocumentTypeName
        {
            get
            {
                if (this.DocumentType != null)
                    return this.DocumentType.ARDT_Name;
                else
                    return "мер рхою";
            }
        }
    }

    partial class DocumentType
    {
        public override string ToString()
        {
            return this.ARDT_Name;
        }
    }
}
