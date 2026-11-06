using Microsoft.AspNetCore.Mvc;
using OrchestratorServer.Api.Models;
using OrchestratorServer.Api.Services;

namespace OrchestratorServer.Api.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController(OllamaService ollama) : ControllerBase
{
    private readonly OllamaService _ollama = ollama;

    [HttpPost]
    public async Task<IActionResult> Chat([FromBody] ChatRequest request)
    {
        string? result = await _ollama.ChatAsync(request.Prompt);

        return Ok(new
        {
            response = result
        });
    }
}