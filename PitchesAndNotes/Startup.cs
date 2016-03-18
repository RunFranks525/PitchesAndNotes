using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PitchesAndNotes.Startup))]
namespace PitchesAndNotes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
