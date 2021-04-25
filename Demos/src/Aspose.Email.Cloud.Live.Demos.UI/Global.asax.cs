using Aspose.Email.Cloud.Live.Demos.UI.Config;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace Aspose.Email.Cloud.Live.Demos.UI
{
    public class Global : HttpApplication
    {

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        void Application_Start(object sender, EventArgs e)
        {

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterCustomRoutes(RouteTable.Routes);

        }
        void Session_Start(object sender, EventArgs e)
        {
            //Check URL to set language resource file
            string _language = "EN";

            SetResourceFile(_language);
        }

        private void SetResourceFile(string strLanguage)
        {
            if (Session["AsposeEmailCloudResources"] == null)
                Session["AsposeEmailCloudResources"] = new GlobalAppHelper(HttpContext.Current, Application, Configuration.ResourceFileSessionName, strLanguage);
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.RouteExistingFiles = true;
            routes.Ignore("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "NoUrl",
                url: "",
                defaults: new { controller = "Home", action = "Default" }
            );

            routes.MapRoute(
                name: "Default",
                url: "Default",
                defaults: new { controller = "Home", action = "Default" }
            );

            routes.MapRoute(
                "AsposeConversionRoute",
                "{product}/Conversion",
                 new { controller = "Conversion", action = "Conversion" }
            );
            routes.MapRoute(
                "DownloadFileRoute",
                "common/download",
                new { controller = "Common", action = "DownloadFile" }

            );

        }


    }
}
