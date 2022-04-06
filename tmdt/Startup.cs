using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tmdt.Startup))]
namespace tmdt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
