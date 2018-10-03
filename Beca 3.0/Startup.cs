using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Beca_3._0.Startup))]
namespace Beca_3._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
