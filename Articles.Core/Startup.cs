using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Articles.Core.Startup))]
namespace Articles.Core
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
