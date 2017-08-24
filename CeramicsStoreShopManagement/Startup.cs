using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CeramicsStoreShopManagement.Startup))]
namespace CeramicsStoreShopManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
