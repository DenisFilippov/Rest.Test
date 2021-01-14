using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MHost = Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting;

namespace Rest.Test.Host
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static MHost.IHostBuilder CreateHostBuilder(string[] args) =>
      MHost.Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
  }
}