using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lab4WebApi;

// En enkel konsollapplikation som visar hur man
// 1) anropar ett web-API med HttpClient
// 2) deserialiserar JSON med JsonSerializer
// 3) använder attribut för att konfigurera deserialisering
internal class Program
{
    // HttpClient är dyr att skapa, därför återanvänder vi en instans
    private static readonly HttpClient _httpClient = new HttpClient();

    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Del 1: Hämta och visa .NET Foundations GitHub-repon
        await ShowDotnetReposAsync();

        // Del 2 (VG): Hämta data från Zippopotam.us om Montvale, New Jersey
        await ShowMontvaleInfoAsync();

        Console.WriteLine();
        Console.WriteLine("Klar. Tryck valfri tangent för att avsluta.");
        Console.ReadKey();
    }

    // Hämtar repos från GitHubs API och skriver ut utvalda fält
    private static async Task ShowDotnetReposAsync()
    {
        Console.WriteLine("=== .NET Foundation – GitHub-repon ===");
        Console.WriteLine();

        // GitHub kräver en User-Agent header
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            "https://api.github.com/orgs/dotnet/repos");

        request.Headers.UserAgent.ParseAdd("Lab4WebApi-AfrovitiXhoga/1.0");

        using var response = await _httpClient.SendAsync(request);

        // Kastar ett undantag om statuskoden inte är 2xx
        response.EnsureSuccessStatusCode();

        // Läser svaret som en stream
        await using var stream = await response.Content.ReadAsStreamAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // gör JSON-fältnamn skiftlägesokänsliga
        };

        // Deserialiserar JSON → lista av GitHubRepo-objekt
        var repos = await JsonSerializer.DeserializeAsync<List<GitHubRepo>>(stream, options);

        if (repos is null || repos.Count == 0)
        {
            Console.WriteLine("Inga repos hittades.");
            return;
        }

        // Sortera så att mest bevakade repos visas först
        var sorted = repos
            .OrderByDescending(r => r.Watchers)
            .ToList();

        Console.WriteLine($"{"Namn",-40} {"Watchers",9} {"Senast pushad",-20}");
        Console.WriteLine(new string('-', 75));

        foreach (var repo in sorted)
        {
            Console.WriteLine($"{repo.Name,-40} {repo.Watchers,9} {repo.PushedAt:yyyy-MM-dd HH:mm}");
            if (!string.IsNullOrWhiteSpace(repo.Description))
            {
                Console.WriteLine($"  Beskrivning: {repo.Description}");
            }

            Console.WriteLine($"  GitHub:   {repo.HtmlUrl}");

            if (!string.IsNullOrWhiteSpace(repo.Homepage))
            {
                Console.WriteLine($"  Hemsida:  {repo.Homepage}");
            }

            Console.WriteLine();
        }
    }

    // VG-del: hämtar postnummer, latitud och longitud för Montvale, New Jersey
    private static async Task ShowMontvaleInfoAsync()
    {
        Console.WriteLine();
        Console.WriteLine("=== VG-del: Zippopotam.us – Montvale, New Jersey ===");
        Console.WriteLine();

        // 07645 är postnumret för Montvale, New Jersey
        using var response = await _httpClient.GetAsync("https://api.zippopotam.us/us/07645");

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Kunde inte hämta data från Zippopotam.us. Statuskod: {response.StatusCode}");
            return;
        }

        await using var stream = await response.Content.ReadAsStreamAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var zipInfo = await JsonSerializer.DeserializeAsync<ZipResponse>(stream, options);

        if (zipInfo is null || zipInfo.Places is null || zipInfo.Places.Count == 0)
        {
            Console.WriteLine("Ingen platsdata hittades.");
            return;
        }

        var place = zipInfo.Places[0];

        Console.WriteLine($"Land:        {zipInfo.Country} ({zipInfo.CountryAbbreviation})");
        Console.WriteLine($"Postnummer:  {zipInfo.PostCode}");
        Console.WriteLine($"Ort:         {place.PlaceName}");
        Console.WriteLine($"Delstat:     {place.State} ({place.StateAbbreviation})");
        Console.WriteLine($"Latitud:     {place.Latitude}");
        Console.WriteLine($"Longitud:    {place.Longitude}");
        Console.WriteLine();
    }
}
