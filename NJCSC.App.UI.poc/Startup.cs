using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NJCSC.App.UI.poc.Startup))]
namespace NJCSC.App.UI.poc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
