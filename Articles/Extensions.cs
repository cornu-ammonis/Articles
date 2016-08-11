using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Articles
{
    public static class Extensions
    {
        public static string ToConfigLocalTime(this DateTime utcDT)
        {
            var istTZ = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time" /* ConfigurationManager.AppSettings["Timezone"] */);
            return String.Format("{0}", TimeZoneInfo.ConvertTimeFromUtc(utcDT, istTZ).ToShortDateString()/*, -- in string({1}) -- ConfigurationManager.AppSettings["TimezoneAbbr"] */);
        }

    }
}