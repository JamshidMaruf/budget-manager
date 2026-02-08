using BudgetManager.Domain.Primitives;

namespace BudgetManager.Application.Expanses.Queries;

public class GetListQueryHandler(IApplicationDbContext context) 
    : IRequestHandler<GetListQuery, Result<List<GetListQueryResponse>>>
{
    public async Task<Result<List<GetListQueryResponse>>> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        var expanses = await context.Expanses
            .Where(e => !e.IsDeleted)
            .Skip(request.PageIndex * request.PageSize)
            .Take(request.PageSize)
            .Select(expanse => new GetListQueryResponse(
                expanse.Id,
                expanse.Amount,
                expanse.Description,
                expanse.Category))
            .ToListAsync(cancellationToken);

        return expanses;
    }
}

public record GetListQuery(int PageIndex, int PageSize) 
    : IRequest<Result<List<GetListQueryResponse>>>;

public record GetListQueryResponse(
    int Id, 
    decimal Amount,
    string Description, 
    ExpanseCategory Category);