using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WaypointReaderLib.Utility
{
    public class AppService
    {
        public static DateTime LocalTime {
            get { return DateTime.UtcNow.AddHours(1.0); }
        }

    }
}
