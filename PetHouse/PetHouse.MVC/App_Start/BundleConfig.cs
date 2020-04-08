using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace PetHouse.MVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/bootstrap-select.css")
                .Include("~/Content/css/bootstrap-datepicker3.min.css")
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/icheck/green.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/skins/skin-blue.css")
                .Include("~/Content/css/skins/skin-green.css"));

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/jquery/jquery-3.3.1.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/js/plugins/moment/moment.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/plugins/validator/validator.js")
                .Include("~/Content/js/plugins/jquery-validate/jquery.validate.min.js")
                .Include("~/Content/js/plugins/jquery-validate/jquery.validate.unobtrusive.min.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Content/js/adminlte.js")
                .Include("~/Content/js/init.js"));

            bundles.Add(new ScriptBundle("~/Bundles/create_domicilio")
                .Include("~/Content/js/CreateDomicilio.js"));

            bundles.Add(new ScriptBundle("~/Bundles/edit_domicilio")
                .Include("~/Content/js/EditDomicilio.js"));

            bundles.Add(new ScriptBundle("~/Bundles/create_persona")
                .Include("~/Content/js/CreatePersona.js"));

            bundles.Add(new ScriptBundle("~/Bundles/create_todo")
                .Include("~/Content/js/CreateCarnet.js")
                .Include("~/Content/js/CreateProcedimiento.js"));

            bundles.Add(new ScriptBundle("~/Bundles/buscar_mascota")
                .Include("~/Content/js/ShowMascota.js")
                .Include("~/Content/js/BuscarMascota.js"));

            bundles.Add(new ScriptBundle("~/Bundles/detalle_adopcion")
                .Include("~/Content/js/ShowMascota.js")
                .Include("~/Content/js/ShowAdoptante.js")
                .Include("~/Content/js/DetalleAdopcion.js"));

            bundles.Add(new ScriptBundle("~/Bundles/procedimientos")
                .Include("~/Content/js/ActionsCarnet.js")
                .Include("~/Content/js/ActionsProcedimiento.js"));
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
