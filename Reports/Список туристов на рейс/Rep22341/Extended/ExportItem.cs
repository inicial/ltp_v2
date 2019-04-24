using System;
using System.Linq;
using System.Collections.Generic;

namespace Rep22341
{
    public class ExportItem
    {
        private IEnumerable<tbl_DogovorList> _DogovorList;
        private tbl_Turist _Turist;
        private int _RootDLKey = -1;

        public tbl_Turist Turist
        {
            set
            {
                _Turist = value;
                SetDogovorList();
            }
            get
            {
                return _Turist;
            }
        }

        public IEnumerable<tbl_DogovorList> DogovorList
        {
            set
            {
                _DogovorList = value.Where(x => x.DL_SVKEY == 1);
                SetDogovorList();
            }
            get
            {
                return _DogovorList;
            }
        }

        public tbl_DogovorList FirstReis;
        public tbl_DogovorList BackReis;

        public int RootDLKey
        {
            set
            {
                _RootDLKey = value;
                SetDogovorList();
            }
            get { return _RootDLKey; }
        }

        public int RootCode;
        public int RootCode1;

        public string NameLat
        {
            get { return Turist.TU_NAMELAT; }
        }
        public string FNameLat
        {
            get { return Turist.TU_FNAMELAT; }
        }
        public short Sex
        {
            get { return Turist.TU_SEX.GetValueOrDefault(0); }
        }
        public DateTime? Birthday
        {
            get { return Turist.TU_BIRTHDAY; }
        }

        private void SetDogovorList()
        {
            if (RootDLKey <= 0 || _DogovorList == null || Turist == null)
                return;

            _DogovorList = _DogovorList.Where(x => x.TuristServices.Count(xTS => xTS.TU_TUKEY == this.Turist.TU_KEY) > 0);
            
            FirstReis = _DogovorList.FirstOrDefault(x => x.DL_KEY == RootDLKey);
            if (FirstReis == null)
                return;

            RootCode = FirstReis.DL_CODE;
            RootCode1 = FirstReis.DL_SUBCODE1.GetValueOrDefault(0);

            var arrayReisTo = _DogovorList.Where(x =>
                x.TuristServices.Count(xTS => xTS.TU_TUKEY == this.Turist.TU_KEY) > 0 &&
                x.DL_SVKEY == 1 &&
                x.Charter.AirportTo != null &&
                FirstReis.Charter.AirportFrom != null &&
                x.Charter.AirportTo.AP_CTKEY == FirstReis.Charter.AirportFrom.AP_CTKEY &&
                x.DL_DAY.GetValueOrDefault(1) > FirstReis.DL_DAY.GetValueOrDefault(0));

            if (arrayReisTo.Count() > 0)
                BackReis = arrayReisTo.First();
            else
                BackReis = null;
        }
    }
}
