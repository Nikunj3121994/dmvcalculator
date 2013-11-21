using System.Web;
using System.Web.Optimization;

namespace ps.dmv.web.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // JS
            /////

            // External
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/external/jquery/jquery-{version}.js",
                        "~/Scripts/external/jquery/jquery-ui-{version}.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/external/jquery/jquery.validate*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/external/bootstrap/bootstrap.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/external/modernizr-*"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/external").Include(
                        "~/Scripts/external/pace.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/external/angular/angular.js",
                      "~/Scripts/external/angular/angular-route.js",
                      "~/Scripts/external/angular/i18n/angular-locale_sl-si.js"
                      ));

            // Application
            bundles.Add(new ScriptBundle("~/bundles/application").Include(
                        "~/Scripts/application/applicationCore.js",
                        "~/Scripts/application/dmvCalculationController.js",
                        "~/Scripts/application/dmvDataFactory.js",
                        "~/Scripts/application/helperModule.js",
                            "~/Scripts/application/customDirectives.js"
                        ));

            // CSS
            //////
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/themes/base/jquery.ui.datepicker.css",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                      ));

            //TODO: Check why optimations fail on AngularJS
            BundleTable.EnableOptimizations = false;
        }
    }
}
