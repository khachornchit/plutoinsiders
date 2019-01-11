using CefInsiders.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CefInsiders.Controllers
{
    public class TaxableBondController : Controller
    {
        private string recentlyTitle = "CEF Insider Taxable Bond Sub-Index - Recent performance";
        private string monthTitle = "CEF Insider Taxable Bond Sub-Index - 1 month performance";
        private string yearTitle = "CEF Insider Taxable Bond Sub-Index - YTD performance";

        ICefInsiderRepository repository = new CefInsiderRepository();

        public ActionResult Index()
        {
            ViewBag.Header = recentlyTitle;
            return View();
        }

        public ActionResult AverageData()
        {
            return Json(repository.GetAverageTaxableBondRecently(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayDate()
        {
            return Json(repository.GetDateTaxableBondRecently(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LastMonth()
        {
            ViewBag.Header = monthTitle;
            return View();
        }

        public ActionResult AverageDataLastMonth()
        {
            return Json(repository.GetAverageTaxableBondLastMonth(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayDateLastMonth()
        {
            return Json(repository.GetDateTaxableBondLastMonth(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LastYear()
        {
            ViewBag.Header = yearTitle;
            return View();
        }

        public ActionResult AverageDataLastYear()
        {
            return Json(repository.GetAverageTaxableBondLastYear(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DisplayDateLastYear()
        {
            return Json(repository.GetDateTaxableBondLastYear(), JsonRequestBehavior.AllowGet);
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