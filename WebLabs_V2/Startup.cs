using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebLabs_V2.Startup))]
namespace WebLabs_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
