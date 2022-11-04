using System.Text.Json.Serialization;

namespace dotnet_prac.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
         Knight = 1,
         Mage = 1,
         Cleric = 1
    }
}