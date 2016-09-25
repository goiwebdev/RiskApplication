using RiskApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

            riskViewModel.SettledFileName = System.IO.File.Exists(pathSettled) ? settledFileName.ToString() + "(Existing)" : "No Uploaded File.";
            riskViewModel.UnSettledFileName = System.IO.File.Exists(pathUnSettled) ? unsettledFileName.ToString() + "(Existing)" : "No Uploaded File.";
            ViewBag.Message = TempData["ErrorMessage"];
            return View(riskViewModel);
        }

        [ActionName("UploadBets")]
        public ActionResult Index1()
        {
            if (Request.Files["FileUpload1"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload1"].FileName).ToLower();

                string[] validFileTypes = { ".csv" };
                if (validFileTypes.Contains(extension))
                {
                    string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/Uploads"), Request.Files["FileUpload1"].FileName);
                    if (!Directory.Exists(path1))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Content/Uploads"));
                    }
                    if (System.IO.File.Exists(path1))
                    { System.IO.File.Delete(path1); }
                    Request.Files["FileUpload1"].SaveAs(path1);
                }
                else
                {
                    TempData["ErrorMessage"] = "Please Upload Files in .csv format";

                }

            }

            return RedirectToAction("Index");
        }
    }
}