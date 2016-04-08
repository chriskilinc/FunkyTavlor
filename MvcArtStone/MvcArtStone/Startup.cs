using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcArtStone.Startup))]
namespace MvcArtStone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
