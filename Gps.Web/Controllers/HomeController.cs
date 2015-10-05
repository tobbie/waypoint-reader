using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WaypointReaderLib.Logic;

namespace Gps.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult UploadGpx()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadGpx(HttpPostedFileBase gpsFile)
        {
            var fileStream = new StreamReader(gpsFile.InputStream);
            var gpsReader = new GpxLoader();
            //var xDoc = gpsReader.(fileStream);
            var wayPoints = gpsReader.LoadGpxWaypoints(fileStream, gpsFile.FileName);

            return View();
        }
    }
}