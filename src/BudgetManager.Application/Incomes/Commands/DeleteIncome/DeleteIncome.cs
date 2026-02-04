namespace BudgetManager.Application.Incomes.Commands.DeleteIncome;

public class DeleteIncomeCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteIncomeCommand, bool>
{
    public async Task<bool> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
    {
        var existingIncome = await context.Incomes
            .FindAsync([request.Id], cancellationToken)
            ?? throw new Exception("Income not found.");
        
        // Soft delete
        existingIncome.Delete();
        
        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}

public record DeleteIncomeCommand(int Id) : IRequest<bool>;