namespace ToDoService.Logic.Exceptions;

public class RequestContentException(string message) : Exception(message) { }

public class NotFoundException(string message) : Exception(message) { }