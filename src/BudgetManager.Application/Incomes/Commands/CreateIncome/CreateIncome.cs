namespace BudgetManager.Application.Incomes.Commands.CreateIncome;

public class CreateIncomeCommandHandler(
    IApplicationDbContext context,
    IValidator<CreateIncomeCommand> validator) : IRequestHandler<CreateIncomeCommand>
{
    public async Task Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var income = Income.Create(request.Amount, request.Description, request.Category);
        
        context.Incomes.Add(income);
        
        await context.SaveChangesAsync(cancellationToken);
    }
}

public record CreateIncomeCommand(
    decimal Amount, 
    string Description, 
    IncomeCategory Category) : IRequest;