using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carrent.CarManagment
{
    public class DateTimeWrapper : IDateTimeWrapper
    {
        private readonly DateTime _dateTime;
        public DateTimeWrapper()
        {
            _dateTime = default(DateTime);
        }

        public DateTimeWrapper(DateTime fixedDateTime)
        {
            _dateTime = fixedDateTime;
        }

        public DateTime GetDateTimeNow()
        {
            if(_dateTime == default(DateTime))
            {
                return DateTime.Now;
            }
            else
            {
                return _dateTime;
            }
        }
    }
}
