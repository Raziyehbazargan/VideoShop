using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoShop.Startup))]
namespace VideoShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
