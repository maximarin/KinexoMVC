using Microsoft.Owin;
using Owin;
using Blog.App_Start;


[assembly: OwinStartupAttribute(typeof(Blog.Startup))]
namespace Blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
