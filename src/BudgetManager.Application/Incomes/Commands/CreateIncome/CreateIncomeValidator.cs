namespace BudgetManager.Application.Incomes.Commands.CreateIncome;

public class CreateIncomeValidator : AbstractValidator<CreateIncomeCommand>
{
    public CreateIncomeValidator()
    {
        RuleFor(i => i.Amount)
            .NotEqual(0)
            .WithMessage("Amount must be greater than zero.");
    }
}