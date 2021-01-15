using System.Collections.Generic;
using System.Threading.Tasks;
using Rest.Test.Domain.Dto;

namespace Rest.Test.Domain.Interfaces
{
  public interface IPersonRepository
  {
    Task<IEnumerable<PersonDto>> GetPeopleAsync();

    Task CreatePersonAsync(PersonDto person);

    Task<PersonDto> GetPersonAsync(long id);

    Task<PersonDto> UpdatePersonAsync(long id, IEnumerable<KeyValuePair<string, object>> parameters);

    Task DeletePersonAsync(long id);
  }
}