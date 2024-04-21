using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Telestream.Helpers;

namespace Telestream
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Global.GetContactName("+12679399716");
            CreateWebHostBuilder(args).Build().Run();
        }

        static IWebHostBuilder CreateWebHostBuilder(string[] args) => 
            WebHost.CreateDefaultBuilder(args)
                .ConfigureKestrel(so => {})
                .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
