using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(LiMarket_V1._0._0.Startup))]
namespace LiMarket_V1._0._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}