using System.Text.Json;

namespace OrchestratorServer.Api.Services;

public class OllamaService(
    HttpClient httpClient,
    IConfiguration configuration)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly IConfiguration _configuration = configuration;

    public async Task<string> ChatAsync(string prompt)
    {
        var model = _configuration["Ollama:Model"];

        var request = new
        {
            model,
            messages = new[]
            {
                new
                {
                    role = "user",
                    content = prompt
                }
            },
            stream = false
        };

        var response = await _httpClient.PostAsJsonAsync(
            "/api/chat",
            request
        );

        response.EnsureSuccessStatusCode();

        using var json = await response.Content.ReadFromJsonAsync<JsonDocument>();

        return json!.RootElement.GetProperty("message").GetProperty("content").GetString() ?? string.Empty;
    }
}