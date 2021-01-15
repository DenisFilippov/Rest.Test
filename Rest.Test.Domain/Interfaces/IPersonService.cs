using System.Collections.Generic;
using System.Threading.Tasks;
using Rest.Test.Domain.Dto;

namespace Rest.Test.Domain.Interfaces
{
  public interface IPersonService
  {
    Task<IEnumerable<PersonDto>> GetPeopleAsync();

    Task CreatePersonAsync(PersonDto person);

    Task<IForm> CreatePersonFormAsync();

    Task<IForm> EditPersonFormAsync(long id);

    Task<PersonDto> GetPersonAsync(long id);

    Task<PersonDto> UpdatePersonAsync(long id, string firstName, string middleName, string lastName, int age, Sex sex);

    Task DeletePersonAsync(long id);
  }
}