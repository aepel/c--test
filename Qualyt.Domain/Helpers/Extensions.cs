using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Qualyt.Web.Helpers
{
    public static class Extensions
    {
        public static DateTimeOffset UtcToArgentinianTime(this DateTimeOffset utcTime)
        {
            TimeZoneInfo argentinaZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime.UtcDateTime, argentinaZone);
        }
    }
}
