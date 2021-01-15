using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Rest.Test.Domain.Dto
{
  public class ErrorDto
  {
    [XmlElement("Message")]
    [JsonPropertyName("message")]
    public string Message { get; set; }
  }
}
