namespace BudgetManager.Application.Incomes.Queries;

public class GetListQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetListQuery, List<GetListQueryResponse>>
{
    public async Task<List<GetListQueryResponse>> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        var incomes = await context.Incomes
            .Where(i => !i.IsDeleted)
            .Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize)
            .Select(income => new GetListQueryResponse(
                income.Id,
                income.Amount,
                income.Description,
                income.Category))
            .ToListAsync(cancellationToken);
        
        return incomes;
    }
}

public record GetListQuery(int PageIndex, int PageSize) : IRequest<List<GetListQueryResponse>>;

public record GetListQueryResponse(
    int Id,
    decimal Amount,
    string Description,
    IncomeCategory Category);