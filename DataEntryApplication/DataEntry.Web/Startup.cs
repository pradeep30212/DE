using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DataEntry.Web.Startup))]
namespace DataEntry.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
