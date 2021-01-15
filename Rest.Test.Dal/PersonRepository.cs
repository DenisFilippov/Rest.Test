using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rest.Test.Domain.Dto;
using Rest.Test.Domain.Interfaces;

namespace Rest.Test.Dal
{
  public class PersonRepository : IPersonRepository
  {
    public async Task<IEnumerable<PersonDto>> GetPeopleAsync()
    {
      return await Task.Run(() => Database.Instance.GetPeople());
    }

    public async Task CreatePersonAsync(PersonDto person)
    {
      await Task.Run(() => Database.Instance.AddPerson(person));
    }

    public async Task<PersonDto> GetPersonAsync(long id)
    {
      return await Task.Run(() => Database.Instance.GetPerson(id));
    }

    public async Task<PersonDto> UpdatePersonAsync(long id, IEnumerable<KeyValuePair<string, object>> parameters)
    {
      return await Task.Run(() => Database.Instance.UpdatePerson(id, parameters));
    }

    public async Task DeletePersonAsync(long id)
    {
      await Task.Run(() => Database.Instance.DeletePerson(id));
    }
  }
}