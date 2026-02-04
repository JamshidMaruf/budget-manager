namespace BudgetManager.Domain.Primitives;

public sealed class Error
{
    public string Code { get; }
    public string Message { get; }
    public ErrorType Type { get; }

    private Error(string code, string message, ErrorType type)
    {
        Code = code;
        Message = message;
        Type = type;
    }
    
    public static Error Failure(string code, string message) 
        => new Error(code, message, ErrorType.Failure);
    
    public static Error Validation(string code, string message) 
        => new Error(code, message, ErrorType.Validation);

    public static Error NotFound(string code, string message) 
        => new Error(code, message, ErrorType.NotFound);

    public static Error Unauthorized(string code, string message) 
        => new Error(code, message, ErrorType.Unauthorized);

    public static Error Conflict(string code, string message) 
        => new Error(code, message, ErrorType.Conflict);

    public static Error Forbidden(string code, string message) 
        => new Error(code, message, ErrorType.Forbidden);
    
    public static implicit operator Result(Error error) => Result.Failure(error);
}

public enum ErrorType
{
    None,
    Failure,
    Validation,
    NotFound,
    Unauthorized,
    Conflict,
    Forbidden
}