using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;


namespace WaypointReaderLib.Models
{
    public class Waypoint
    {
        private const string dateFormat = "yyyy-MM-ddTHH:mm:ssZ";
       
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string Elevation { get; set; }

        public string CaptureDate { get; set; }

        public DateTime CaptureDateTime {
            get
            {
                var date = DateTime.ParseExact(CaptureDate, dateFormat, null, DateTimeStyles.AllowWhiteSpaces);
                return date;
            }
        }

        public string Name { get; set; }

        public string Reference
        {
            get
            {
                string lat = Latitude.Replace(".", "");
                string lon = Longitude.Replace(".", "");
                return lat + lon + CaptureDate;
            }
        }

        public string FileName { get; set; }

        public DateTime EntryDate { get; set; }
    }
}
