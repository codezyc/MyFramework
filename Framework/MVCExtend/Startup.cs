using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCExtend.Startup))]
namespace MVCExtend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
