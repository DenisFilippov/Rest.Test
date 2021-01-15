using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MHost = Microsoft.Extensions.Hosting;

namespace Rest.Test.Host
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      return MHost.Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
  }
}