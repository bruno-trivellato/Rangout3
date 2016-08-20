using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(rangoutBackend.Startup))]

namespace rangoutBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}