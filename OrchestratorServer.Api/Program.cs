using OrchestratorServer.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApi(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
builder.Services.AddHttpClient<OllamaService>(client =>
{
    client.BaseAddress = new Uri(
        builder.Configuration["Ollama:BaseUrl"]!
    );
    client.Timeout = Timeout.InfiniteTimeSpan;
});

var app = builder.Build();

app.UseExceptionHandler();
app.UseForwardedHeaders();
app.UseMiddleware<OrchestratorServer.Api.Middleware.SecurityHeadersMiddleware>();
app.UseCors("Frontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.UseHttpsRedirection();

app.Run();