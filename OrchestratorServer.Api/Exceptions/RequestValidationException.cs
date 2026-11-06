namespace OrchestratorServer.Api.Exceptions;

public sealed class RequestValidationException(string message, Exception? innerException = null)
    : Exception(message, innerException);
