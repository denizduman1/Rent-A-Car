using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FullDateAndTimeStringWithUnderscore(this DateTime dateTime)
        {
            return $"{dateTime.Year}_{dateTime.Month}_{dateTime.Day}_{dateTime.Hour}_{dateTime.Minute}_{dateTime.Second}";
        }
    }
}
