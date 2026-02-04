using BudgetManager.Domain.Commons;
using BudgetManager.Domain.Enums;

namespace BudgetManager.Domain.Entities;

public class Income : BaseAuditableEntity
{
    private Income(decimal amount, string description, IncomeCategory category)
    {
        Amount = amount;
        Description = description;
        Category = category;
    }
    
    public decimal Amount { get; private set; }
    public string Description { get; private set; }
    public IncomeCategory Category { get; private set; }
    
    public static Income Create(decimal amount, string description, IncomeCategory category)
    {
        return new Income(amount, description, category);
    }
    
    public void Update(decimal amount, string description, IncomeCategory category)
    {
        Amount = amount;
        Description = description;
        Category = category;
    }
}