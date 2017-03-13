using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    [Serializable]
    public class DateRange
    {
        private DateTime _Start;
        private DateTime _End;

        public DateRange()
        {
            _Start = DateTime.MinValue;
            _End = DateTime.MaxValue;
        }

        public DateTime Start
        {
            get { return _Start; }
            set { _Start = value; }
        } 
        public DateTime End
        {
            get { return _End; }
            set { _End = value; }
        }
    }
}
