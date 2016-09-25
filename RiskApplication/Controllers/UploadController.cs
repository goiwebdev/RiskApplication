using RiskApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RiskApplication.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            var riskViewModel = new RiskViewModel();
            var settledFileName = "Settled.csv";
            var unsettledFileName = "Unsettled.csv";

            string pathSettled = string.Format("{0}/{1}", Server.MapPath("~/Content/Uploads"), settledFileName);
            string pathUnSettled = string.Format("{0}/{1}", Server.MapPath("~/Content/Uploads"), unsettledFileName);

            riskViewModel.SettledFileName = System.IO.File.Exists(pathSettled) ? settledFileName.ToString() : "";
            riskViewModel.UnSettledFileName = System.IO.File.Exists(pathSettled) ? unsettledFileName.ToString() : "";
            return View(riskViewModel);
        }
    }
}