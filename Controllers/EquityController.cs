using CefInsiders.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CefInsiders.Controllers
{
    public class EquityController : Controller
    {
        private string recentlyTitle = "CEF Insider Equity Sub-Index - Recent performance";
        private string monthTitle = "CEF Insider Equity Sub-Index - 1 month performance";
        private string yearTitle = "CEF Insider Equity Sub-Index - YTD performance";

        ICefInsiderRepository repository = new CefInsiderRepository();

        public ActionResult Index()
        {
            ViewBag.Header = recentlyTitle;
            return View();
        }

        public ActionResult AverageData()
        {
            return Json(repository.GetAverageEquityRecently(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayDate()
        {
            return Json(repository.GetDateEquityRecently(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LastMonth()
        {
            ViewBag.Header = monthTitle;
            return View();
        }

        public ActionResult AverageDataLastMonth()
        {
            return Json(repository.GetAverageEquityLastMonth(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayDateLastMonth()
        {
            return Json(repository.GetDateEquityLastMonth(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LastYear()
        {
            ViewBag.Header = yearTitle;
            return View();
        }

        public ActionResult AverageDataLastYear()
        {
            return Json(repository.GetAverageEquityLastYear(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayDateLastYear()
        {
            return Json(repository.GetDateEquityLastYear(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Recently()
        {
            ViewBag.Header = recentlyTitle;
            return View();
        }

        public ActionResult Month()
        {
            ViewBag.Header = monthTitle;
            return View();
        }

        public ActionResult Year()
        {
            ViewBag.Header = yearTitle;
            return View();
        }
    }
}