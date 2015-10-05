using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Xml.Linq;
using WaypointReaderLib.Models;
using WaypointReaderLib.Utility;

namespace WaypointReaderLib.Logic
{
    public class GpxLoader
    {
        /// <summary> 
        /// Load the Xml document for parsing 
        /// </summary> 
        /// <param name="sFile">Fully qualified file name (local)</param> 
        /// <returns>XDocument</returns> 
        private XDocument GetGpxDoc(string sFile)
        {
            XDocument gpxDoc = XDocument.Load(sFile);
            return gpxDoc;
        }

        private XDocument GetGpxDoc(StreamReader sFile)
        {
            XDocument gpxDoc = XDocument.Load(sFile);
            return gpxDoc;
        }

        /// <summary> 
        /// Load the namespace for a standard GPX document 
        /// </summary> 
        /// <returns></returns> 
        private XNamespace GetGpxNameSpace()
        {
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/1");
            return gpx;
        }


        /// <summary> 
        /// When passed a file, open it and parse all waypoints from it. 
        /// </summary> 
        /// <param name="fileStream">Fully qualified file name (local)</param> 
        /// <returns>string containing line delimited waypoints from 
        /// the file (for test)</returns> 
        ///  /// <param name="fileName">Name of Gpx file</param> 
        /// <remarks>Normally, this would be used to populate the 
        /// appropriate object model</remarks> 
        public IEnumerable<Waypoint> LoadGpxWaypoints(StreamReader fileStream, string fileName)
        { 
            try
            {
                XDocument gpxDoc = GetGpxDoc(fileStream);
                XNamespace gpx = GetGpxNameSpace();
                return ProcessGpxWayPoints(gpxDoc, gpx, fileName);

            }
            catch (Exception)
            {
                    
                throw;
            }
                    
        }

        public IEnumerable<Waypoint> LoadGpxWaypoints(string path, string fileName)
        {
            try
            {
                XDocument gpxDoc = GetGpxDoc(path);
                XNamespace gpx = GetGpxNameSpace();
                return ProcessGpxWayPoints(gpxDoc, gpx, fileName);

            }
            catch (Exception)
            {

                throw;
            }

        }

        private IEnumerable<Waypoint> ProcessGpxWayPoints(XDocument gpxDoc, XNamespace gpx, string fileName)
        {
            var waypoints = from waypoint in gpxDoc.Descendants(gpx + "wpt")
                            select new Waypoint
                            {
                                Latitude = waypoint.Attribute("lat").Value,
                                Longitude = waypoint.Attribute("lon").Value,
                                Elevation = waypoint.Element(gpx + "ele") != null ?
                                       waypoint.Element(gpx + "ele").Value : null,
                                Name = waypoint.Element(gpx + "name") != null ?
                                        waypoint.Element(gpx + "name").Value : null,
                                CaptureDate = waypoint.Element(gpx + "time") != null ?
                                        waypoint.Element(gpx + "time").Value : null,
                                FileName = fileName,
                                EntryDate = AppService.LocalTime
                            };


            return waypoints.AsEnumerable().ToList();
        }



    }
}
