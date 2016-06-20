using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog.Shared.Helpers
{

    
    public static class DateHelper
    {

        /// <summary>
        /// I return date like 23rd Sept
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GymLogFormattedDate(this DateTime dt)
        {
            var day = dt.Day.ToString() + DateHelper.GetDaySuffix(dt.Day);
            var month = dt.ToString("MMM");

            return $"{day} {month}";

        }

        public static string DayofWeek2(this DateTime dt)
        {
            if (dt.IsToday()) return "Today";
            if (dt.IsYesterday()) return "Yesterday";
            return dt.ToString("dddd");
        }
        

        public static bool IsToday(this DateTime dt)
        {           
            return dt.Date == DateTime.Today;
        }

        public static bool IsYesterday(this DateTime dt)
        {
            return DateTime.Today - dt.Date == TimeSpan.FromDays(1);
        }


        public static long StartOfDayTicks
        {
            get
            {
               return  DateTime.Now.Date.Ticks;
            }
        }

        public static long EndOfDayTicks
        {
            get
            {
                return DateTime.Now.Date.AddDays(1).AddTicks(-1).Ticks;
            }
        }


        public static string  GetDaySuffix(int day)
        {
            switch (day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }
    }
}
