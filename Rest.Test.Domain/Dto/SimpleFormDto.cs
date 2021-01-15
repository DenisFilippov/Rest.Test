using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Rest.Test.Domain.Interfaces;

namespace Rest.Test.Domain.Dto
{
  [XmlRoot("Form")]
  public class SimpleFormDto : IForm
  {
    [XmlElement("Caption")]
    [JsonPropertyName("caption")]
    public string Caption { get; set; }

    [XmlElement("FirstName")]
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [XmlElement("MiddleName")]
    [JsonPropertyName("middleName")]
    public string MiddleName { get; set; }

    [XmlElement("LastName")]
    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [XmlElement("Age")]
    [JsonPropertyName("age")]
    public int Age { get; set; }

    [XmlElement("Sex")]
    [JsonPropertyName("sex")]
    public Sex Sex { get; set; }

    [XmlElement("FormResult")]
    [JsonPropertyName("formResult")]
    public bool? FormResult { get; set; } = false;
  }
}
