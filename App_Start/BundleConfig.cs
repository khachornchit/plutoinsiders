using System.Web;
using System.Web.Optimization;

namespace CefInsiders
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/plutosolutionscss").Include(
                "~/Content/style.css",
                "~/Content/plutosolutions.css",
                "~/Content/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsjs").Include(
                "~/Content/js/jquery-1.3.2.min.js",
                "~/Content/js/script.js",
                "~/Content/js/cufon-yui.js",
                "~/Content/js/arial.js",
                "~/Content/js/cuf_run.js",
                "~/Content/js/chart/Chart.bundle.min.js",
                "~/Content/js/chart/utils.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsbottomjs").Include(
                "~/Content/js/plutosolutionsbottomjs.js",
                "~/Scripts/bootstrap.min"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsbuywrite").Include(
                "~/Content/js/chart/chart-buy-write.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsbuywritemonth").Include(
                "~/Content/js/chart/chart-buy-write-month.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsbuywriteyear").Include(
                "~/Content/js/chart/chart-buy-write-year.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsequity").Include(
                "~/Content/js/chart/chart-equity.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsequitymonth").Include(
                "~/Content/js/chart/chart-equity-month.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsequityyear").Include(
                "~/Content/js/chart/chart-equity-year.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsforeign").Include(
                "~/Content/js/chart/chart-foreign.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsforeignmonth").Include(
                "~/Content/js/chart/chart-foreign-month.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsforeignyear").Include(
                "~/Content/js/chart/chart-foreign-year.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsoverview").Include(
                "~/Content/js/chart/chart-combine.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsoverviewmonth").Include(
                "~/Content/js/chart/chart-combine-month.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionsoverviewyear").Include(
                "~/Content/js/chart/chart-combine-year.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionstaxablebond").Include(
                "~/Content/js/chart/chart-taxable-bond.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionstaxablebondmonth").Include(
                "~/Content/js/chart/chart-taxable-bond-month.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionstaxablebondyear").Include(
                "~/Content/js/chart/chart-taxable-bond-year.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionstaxfreebond").Include(
                "~/Content/js/chart/chart-taxfree-bond.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionstaxfreebondmonth").Include(
                "~/Content/js/chart/chart-taxfree-bond-month.js"));

            bundles.Add(new ScriptBundle("~/bundles/plutosolutionstaxfreebondyear").Include(
                "~/Content/js/chart/chart-taxfree-bond-year.js"));
        }
    }
}
