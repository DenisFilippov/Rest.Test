using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Rest.Test.Domain.Dto
{
  [XmlRoot("Person")]
  public class PersonDto
  {
    [XmlElement("Id")]
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [XmlElement("FirstName")]
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [XmlElement("LastName")]
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [XmlElement("MiddleName")]
    [JsonPropertyName("middleName")]
    public string MiddleName { get; set; }

    [XmlElement("Age")]
    [JsonPropertyName("age")]
    public int Age { get; set; }

    [XmlElement("Sex")]
    [JsonPropertyName("sex")]
    public Sex Sex { get; set; }
  }
}