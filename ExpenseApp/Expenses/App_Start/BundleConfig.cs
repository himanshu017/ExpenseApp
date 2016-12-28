using System.Web;
using System.Web.Optimization;

namespace Expenses
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/scripts/lib/bootstrap/bootstrap.min.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/lib/perfectscrollbar/perfect-scrollbar.css",
                      "~/Content/lib/font-awesome/font-awesome.min.css",
                      "~/Content/lib/ionicons/ionicons.min.css",
                      "~/Content/styles.css"));

            bundles.Add(new ScriptBundle("~/bundles/Frontend").Include(
                   "~/scripts/pages/front_end.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                "~/scripts/lib/slimscroll/jquery.slimscroll.min.js",
                "~/scripts/jquery.unobtrusive-ajax.min.js",
                "~/scripts/pages/scripts.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Gmaps").Include(
        
               "~/scripts/lib/gmaps/gmaps.js",
               "~/scripts/pages/map_google.js"));

            bundles.Add(new ScriptBundle("~/bundles/validation").Include(
            "~/scripts/jquery.validate.min.js",
            "~/scripts/additional-methods.min.js"));
        }
    }
}
