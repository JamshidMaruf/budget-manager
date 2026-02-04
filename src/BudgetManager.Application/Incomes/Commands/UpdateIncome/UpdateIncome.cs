namespace BudgetManager.Application.Incomes.Commands.UpdateIncome;

public class UpdateIncomeCommandHandler(
    IApplicationDbContext context,
    IValidator<UpdateIncomeCommand> validator) : IRequestHandler<UpdateIncomeCommand>
{
    public async Task Handle(UpdateIncomeCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var existingIncome = await context.Incomes
            .FindAsync([request.Id], cancellationToken)
            ?? throw new Exception("Income not found.");
        
        existingIncome.Update(request.Amount, request.Description, request.Category);
        
        await context.SaveChangesAsync(cancellationToken);
    }
}

public record UpdateIncomeCommand(
    int Id,
    decimal Amount, 
    string Description,
    IncomeCategory Category) : IRequest;