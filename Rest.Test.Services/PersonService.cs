using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rest.Test.Domain;
using Rest.Test.Domain.Dto;
using Rest.Test.Domain.Interfaces;

namespace Rest.Test.Services
{
  public class PersonService : IPersonService
  {
    private readonly IPersonRepository _personRepository;
    private readonly IServiceProvider _serviceProvider;

    public PersonService(IServiceProvider serviceProvider, IPersonRepository personRepository)
    {
      _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
      _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public async Task<IEnumerable<PersonDto>> GetPeopleAsync()
    {
      return await _personRepository.GetPeopleAsync();
    }

    public async Task CreatePersonAsync(PersonDto person)
    {
      await _personRepository.CreatePersonAsync(person);
    }

    public async Task<IForm> CreatePersonFormAsync()
    {
      var result = _serviceProvider.GetService<IForm>();
      if (result == null)
        throw new InvalidOperationException();

      result.Caption = "Create person form";
      return result;
    }

    public async Task<IForm> EditPersonFormAsync(long id)
    {
      var person = await _personRepository.GetPersonAsync(id);
      var result = _serviceProvider.GetService<IForm>();
      if (result == null)
        throw new InvalidOperationException();

      result.Caption = "Edit person form";
      result.FirstName = person.FirstName;
      result.MiddleName = person.MiddleName;
      result.LastName = person.LastName;
      result.Age = person.Age;
      result.Sex = person.Sex;
      return result;
    }

    public async Task<PersonDto> GetPersonAsync(long id)
    {
      return await _personRepository.GetPersonAsync(id);
    }

    public async Task<PersonDto> UpdatePersonAsync(long id, string firstName, string middleName, string lastName,
      int age, Sex sex)
    {
      var parameters = new KeyValuePair<string, object>[5];
      parameters[0] = new KeyValuePair<string, object>(ParametersNames.AGE, age);
      parameters[1] = new KeyValuePair<string, object>(ParametersNames.FIRST_NAME, firstName);
      parameters[2] = new KeyValuePair<string, object>(ParametersNames.LAST_NAME, lastName);
      parameters[3] = new KeyValuePair<string, object>(ParametersNames.MIDDLE_NAME, middleName);
      parameters[4] = new KeyValuePair<string, object>(ParametersNames.SEX, sex);
      return await _personRepository.UpdatePersonAsync(id, parameters);
    }

    public async Task DeletePersonAsync(long id)
    {
      await _personRepository.DeletePersonAsync(id);
    }
  }
}