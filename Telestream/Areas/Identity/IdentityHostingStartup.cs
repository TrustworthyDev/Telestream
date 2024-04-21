using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Telestream.Areas.Identity.IdentityHostingStartup))]
namespace Telestream.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}