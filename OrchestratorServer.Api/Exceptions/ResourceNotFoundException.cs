namespace OrchestratorServer.Api.Exceptions;

public sealed class ResourceNotFoundException(string message) : Exception(message);
