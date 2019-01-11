using CefInsiders.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CefInsiders.Controllers
{
    public class HomeController : Controller
    {
        private string recentlyTitle = "CEF Insider Overview - Recent performance";
        private string monthTitle = "CEF Insider Overview - 1 month performance";
        private string yearTitle = "CEF Insider Overview - YTD performance";

        private string recentlyTitleRev = "Overview - Recent Performance";
        private string monthTitleRev = "Overview - 1 Month Performance";
        private string yearTitleRev = "Overview - YTD Performance";

        ICefInsiderRepository repository = new CefInsiderRepository();

        public ActionResult Index()
        {
            ViewBag.Header = recentlyTitle;
            return View();
        }

        public ActionResult MaxDisplayDate()
        {
            return Json(repository.GetDateBuyWriteRecently(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LastMonth()
        {
            ViewBag.Header = monthTitle;
            return View();
        }

        public ActionResult MaxDisplayDateLastMonth()
        {
            return Json(repository.GetDateBuyWriteLastMonth(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LastYear()
        {
            ViewBag.Header = yearTitle;
            return View();
        }

        public ActionResult MaxDisplayDateLastYear()
        {
            return Json(repository.GetDateBuyWriteLastYear(), JsonRequestBehavior.AllowGet);
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

        public ActionResult RevolutionIndex()
        {
            return View();
        }

        public ActionResult RevolutionRecent()
        {
            ViewBag.Header = recentlyTitleRev;
            return View();
        }
    }
}