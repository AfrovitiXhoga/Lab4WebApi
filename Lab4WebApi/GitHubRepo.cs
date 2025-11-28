using System.Text.Json.Serialization;

namespace Lab4WebApi;

// Representerar ett GitHub-repo från .NET Foundation
public class GitHubRepo
{
    // JSON-fältet heter "name" → vi mappar det till "Name"
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; set; } = string.Empty;

    [JsonPropertyName("homepage")]
    public string? Homepage { get; set; }

    [JsonPropertyName("watchers")]
    public int Watchers { get; set; }

    [JsonPropertyName("pushed_at")]
    public DateTime PushedAt { get; set; }
}
