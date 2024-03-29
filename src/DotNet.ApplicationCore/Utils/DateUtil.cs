﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.ApplicationCore.Utils
{
    public class DateUtil
    {
        public static DateTime GetCurrentDate()
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);
        }
    }
}
