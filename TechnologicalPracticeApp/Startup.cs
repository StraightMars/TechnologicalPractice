using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TechnologicalPracticeApp.Startup))]
namespace TechnologicalPracticeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
