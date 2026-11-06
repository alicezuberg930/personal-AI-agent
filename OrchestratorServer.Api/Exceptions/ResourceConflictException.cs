namespace OrchestratorServer.Api.Exceptions;

public sealed class ResourceConflictException(string message) : Exception(message);
