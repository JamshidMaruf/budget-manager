namespace BudgetManager.Infrastructure.Data.Configurations;

public class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.Property(e => e.Description).HasMaxLength(250);
        builder.Property(e => e.Amount).IsRequired();
        builder.HasIndex(e => e.Category);
    }
}