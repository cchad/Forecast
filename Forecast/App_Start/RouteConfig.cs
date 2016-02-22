namespace ForecastApp
{
    #region imports

    using System.Web.Routing;

    using Microsoft.AspNet.FriendlyUrls;

    #endregion

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}