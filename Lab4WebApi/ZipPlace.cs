using System.Text.Json.Serialization;

namespace Lab4WebApi;

// En plats (ort) inne i svaret från Zippopotam.us
public class ZipPlace
{
    [JsonPropertyName("place name")]
    public string PlaceName { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("state abbreviation")]
    public string StateAbbreviation { get; set; } = string.Empty;

    [JsonPropertyName("latitude")]
    public string Latitude { get; set; } = string.Empty;

    [JsonPropertyName("longitude")]
    public string Longitude { get; set; } = string.Empty;
}
