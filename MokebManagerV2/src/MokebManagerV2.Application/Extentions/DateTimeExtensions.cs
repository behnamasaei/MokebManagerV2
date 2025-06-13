using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokebManagerV2.Extentions
{
    public static class DateTimeExtensions
    {
        private static readonly PersianCalendar _pc = new();

        public static string ToJalaliString(this DateTime dt)
            => $"{_pc.GetYear(dt)}/" +
               $"{_pc.GetMonth(dt):D2}/" +
               $"{_pc.GetDayOfMonth(dt):D2}";

        public static DateTime ToGregorianDate(this DateTime dt)
            => new DateTime(dt.Year, dt.Month, dt.Day, _pc);
    }

}
