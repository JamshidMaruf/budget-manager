namespace BudgetManager.Application.Incomes.Queries;

public class GetByIdQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetByIdQuery, GetByIdQueryResponse>
{
    public async Task<GetByIdQueryResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var income = await context.Incomes
            .Where(i => !i.IsDeleted)
            .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken)
            ?? throw new Exception("Income not found.");
        
        return new GetByIdQueryResponse(
            income.Id,
            income.Amount,
            income.Description, 
            income.Category);
    }
}

public record GetByIdQuery(int Id) : IRequest<GetByIdQueryResponse>;

public record GetByIdQueryResponse(
    int Id,
    decimal Amount,
    string Description,
    IncomeCategory Category);