namespace BudgetManager.Application.Expanses.Commands.CreateExpanse;

public class CreateExpanseValidator : AbstractValidator<CreateExpanseCommand>
{
    public CreateExpanseValidator()
    {
        RuleFor(v => v.Amount)
            .NotEmpty()
            .WithMessage("Amount is required.")
            .GreaterThan(0)
            .WithMessage("Amount must be greater than zero.");
        
        RuleFor(v => v.Description)
            .NotEmpty()
            .WithMessage("Description is required.");
    }
}