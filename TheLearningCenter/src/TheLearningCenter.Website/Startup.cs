using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheLearningCenter.Website.Startup))]
namespace TheLearningCenter.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
