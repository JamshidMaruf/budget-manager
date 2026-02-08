namespace BudgetManager.Domain.Primitives;

public class Result
{
    public bool IsSucceeded { get; }
    public bool IsFailure => !IsSucceeded;
    public Error Error { get; }

    public Result(bool isSucceeded, Error error)
    {
        IsSucceeded = isSucceeded;
        Error = error;
    }
    
    public static Result Success() => new(true, Error.None);
   
    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => 
        new(value, true, Error.None);
    
    public static Result<TValue> Failure<TValue>(Error error) => 
        new(default, false, error);
}

public class Result<TValue> : Result
{
    public Result(TValue value, bool isSucceeded, Error error) : base(isSucceeded, error)
    {
        Value = value;
    }
    
    public TValue Value { get; }
    
    public static implicit operator Result<TValue>(TValue value) => Success(value);
    public static implicit operator Result<TValue>(Error error) => Failure<TValue>(error);
}