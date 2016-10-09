using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamManagment.Startup))]
namespace TeamManagment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
