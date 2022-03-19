using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab3_tranhoangquan.Startup))]
namespace lab3_tranhoangquan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
