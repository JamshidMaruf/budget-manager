using BudgetManager.Domain.Primitives;

namespace BudgetManager.Domain.Errors;

public class ExpanseError
{
    public static Error NotFound(int id) => Error.NotFound(
        "Expanse.NotFound", 
        "Expanse not found with id: " + id);
    
    public static Error Validation(string message) => Error.Validation(
        "Expanse.Validation", 
        message);
}