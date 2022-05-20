using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Entry.Web.Startup))]
namespace Entry.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
