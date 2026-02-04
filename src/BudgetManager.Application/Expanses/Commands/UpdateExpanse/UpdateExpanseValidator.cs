namespace BudgetManager.Application.Expanses.Commands.UpdateExpanse;

public class UpdateExpanseValidator : AbstractValidator<UpdateExpanseCommand>
{
    public UpdateExpanseValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        
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