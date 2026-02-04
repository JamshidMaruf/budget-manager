using BudgetManager.Domain.Commons;
using BudgetManager.Domain.Enums;

namespace BudgetManager.Domain.Entities;

public class Expanse : BaseAuditableEntity
{
    private Expanse(decimal amount, string description, ExpanseCategory category)
    {
        Amount = amount;
        Description = description;
        Category = category;
    }
    
    public decimal Amount { get; private set; }
    public string Description { get; private set; }
    public ExpanseCategory Category { get; private set; }
    
    public static Expanse Create(decimal amount, string description, ExpanseCategory category)
    {
        return new Expanse(amount, description, category);
    }
    
    public void Update(decimal amount, string description, ExpanseCategory category)
    {
        Amount = amount;
        Description = description;
        Category = category;
    }
}