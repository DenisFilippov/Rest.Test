using Microsoft.Extensions.DependencyInjection;
using Rest.Test.Dal;
using Rest.Test.Domain.Dto;
using Rest.Test.Domain.Interfaces;
using Rest.Test.Services;

namespace Rest.Test.Host
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddRestDto(this IServiceCollection services)
    {
      services.AddScoped<IForm>(r => new SimpleFormDto());
      return services;
    }

    public static IServiceCollection AddRestRepositories(this IServiceCollection services)
    {
      services.AddScoped<IPersonRepository>(r => new PersonRepository());
      return services;
    }

    public static IServiceCollection AddRestServices(this IServiceCollection services)
    {
      services.AddScoped<IPersonService>(r => new PersonService(r, r.GetService<IPersonRepository>()));
      return services;
    }
  }
}