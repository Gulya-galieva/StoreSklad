using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSklad2.Startup))]
namespace WebSklad2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
