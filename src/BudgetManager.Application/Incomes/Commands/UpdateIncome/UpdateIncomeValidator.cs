namespace BudgetManager.Application.Incomes.Commands.UpdateIncome;

public class UpdateIncomeValidator : AbstractValidator<UpdateIncomeCommand>
{
    public UpdateIncomeValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than zero.");
        
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

