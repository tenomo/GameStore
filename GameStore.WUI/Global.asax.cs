using GameStore.WUI.Infrastructure.Binders;
using GameStore.WUI.Models.Concrete;
using System.Web.Mvc;
using System.Web.Routing;

namespace GameStore.WUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
