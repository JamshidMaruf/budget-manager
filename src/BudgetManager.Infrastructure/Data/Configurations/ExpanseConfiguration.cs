namespace BudgetManager.Infrastructure.Data.Configurations;

public class ExpanseConfiguration : IEntityTypeConfiguration<Expanse>
{
    public void Configure(EntityTypeBuilder<Expanse> builder)
    {
        builder.Property(e => e.Description).HasMaxLength(250);
        builder.Property(e => e.Amount).IsRequired();
        builder.HasIndex(e => e.Category);
    }
}