namespace BudgetManager.Domain.Primitives;

public class Result
{
    public bool IsSucceeded { get; }
    public bool IsFailure => !IsSucceeded;
    public Error Error { get; }

    protected Result(bool isSucceeded, Error error)
    {
        IsSucceeded = isSucceeded;
        Error = error;
    }
    
    public static Result Success => new Result(true, null);
    public static Result Failure(Error error) => new Result(false, error);
}