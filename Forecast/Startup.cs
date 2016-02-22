#region imports

using ForecastApp;

using Microsoft.Owin;

#endregion

[assembly: OwinStartup(typeof(Startup))]

namespace ForecastApp
{
    #region imports

    using Owin;

    #endregion

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}