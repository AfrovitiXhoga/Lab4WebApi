using System.Text.Json.Serialization;

namespace Lab4WebApi;

// Rotobjektet från Zippopotam.us
public class ZipResponse
{
    [JsonPropertyName("post code")]
    public string PostCode { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("country abbreviation")]
    public string CountryAbbreviation { get; set; } = string.Empty;

    [JsonPropertyName("places")]
    public List<ZipPlace> Places { get; set; } = new();
}

