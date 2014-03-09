using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5._1.Startup))]
namespace MVC5._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
