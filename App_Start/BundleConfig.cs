using System.Web;
using System.Web.Optimization;

namespace ControlUniversitario
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.min.js"));


            bundles.Add(new Bundle("~/bundles/dialogo").Include(
                      "~/Scripts/dialogo.js"));

            bundles.Add(new Bundle("~/bundles/carreras").Include(
                      "~/Scripts/carreras.js"));

            bundles.Add(new Bundle("~/bundles/validacionFormularios").Include(
                      "~/Scripts/validacionFormularios.js"));

            bundles.Add(new Bundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));
        }
    }
}
