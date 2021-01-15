using System.Collections.Generic;

namespace Rest.Test.Domain.Interfaces
{
  public interface IForm
  {
    string Caption { get; set; }

    string FirstName { get; set; }

    string MiddleName { get; set; }

    string LastName { get; set; }

    int Age { get; set; }

    Sex Sex { get; set; }

    public bool? FormResult { get; set; }
  }
}