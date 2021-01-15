using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Rest.Test.Domain.Dto
{
  [XmlRoot("Response")]
  public class ResponseDto
  {
    [XmlElement("Code")]
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [XmlElement("Error")]
    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ErrorDto Error { get; set; }
  }
}
