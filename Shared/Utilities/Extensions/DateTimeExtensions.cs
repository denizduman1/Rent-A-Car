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
            return $"{dateTime.Year}/{dateTime.Month}/{dateTime.Day}-{dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}";
        }
    }
}
