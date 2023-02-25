using System.Text.Json.Serialization;
namespace rcs_p.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Requests
    {
        Send = 1,
        Recieve = 2
    }
}