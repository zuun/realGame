using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(realGame.Startup))]
namespace realGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
