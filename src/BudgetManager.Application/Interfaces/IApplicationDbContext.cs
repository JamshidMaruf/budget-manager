namespace BudgetManager.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Expanse> Expanses { get; }
    DbSet<Income> Incomes { get; } 
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}