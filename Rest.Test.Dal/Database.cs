using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rest.Test.Domain;
using Rest.Test.Domain.Dto;

namespace Rest.Test.Dal
{
  public class Database : IEnumerable<PersonDto>
  {
    private static Database _instance;
    private static readonly object LockObject = new();
    private readonly List<PersonDto> _list = new();

    private Database () { }

    public static Database Instance
    {
      get
      {
        if (_instance != null) return _instance;
        lock (LockObject)
        {
          _instance ??= new Database();
        }

        return _instance;
      }
    }

    public IEnumerator<PersonDto> GetEnumerator()
    {
      return ((IEnumerable<PersonDto>) _list).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return _list.GetEnumerator();
    }

    public IEnumerable<PersonDto> GetPeople()
    {
      return _list;
    }

    public PersonDto GetPerson(long id)
    {
      return _list.First(r => r.Id == id);
    }

    public void AddPerson(PersonDto person)
    {
      if (person == null)
        throw new ArgumentNullException(nameof(person));

      _list.Add(person);
    }

    public void DeletePerson(long id)
    {
      if (!_list.Remove(_list.Find(r => r.Id == id)))
        throw new InvalidOperationException("Error deleting person.");
    }

    public PersonDto UpdatePerson(long id, IEnumerable<KeyValuePair<string, object>> parameters)
    {
      var person = GetPerson(id);
      foreach (var parameter in parameters)
      {
        switch (parameter.Key)
        {
          case ParametersNames.AGE:
            person.Age = (int)parameter.Value;
            break;
          case ParametersNames.FIRST_NAME:
            person.FirstName = (string)parameter.Value;
            break;
          case ParametersNames.ID:
            break;
          case ParametersNames.LAST_NAME:
            person.LastName = (string)parameter.Value;
            break;
          case ParametersNames.MIDDLE_NAME:
            person.MiddleName = (string)parameter.Value;
            break;
          case ParametersNames.SEX:
            person.Sex = (Sex)parameter.Value;
            break;
          default:
            throw new ArgumentException();
        }
      }

      return person;
    }
  }
}
