using BudgetManager.Domain.Errors;
using BudgetManager.Domain.Primitives;

namespace BudgetManager.Application.Expanses.Queries;

public class GetByIdQueryHandler(IApplicationDbContext context) 
    : IRequestHandler<GetByIdQuery, Result<GetByIdQueryResponse>>
{
    public async Task<Result<GetByIdQueryResponse>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var expanse = await context.Expanses
            .FindAsync([request.Id], cancellationToken);

        if (expanse == null)
            return ExpanseError.NotFound(request.Id);
        
        return new GetByIdQueryResponse(
            expanse.Id,
            expanse.Amount,
            expanse.Description, 
            expanse.Category);
    }
}

public record GetByIdQuery(int Id) : IRequest<Result<GetByIdQueryResponse>>;

public record GetByIdQueryResponse(
    int Id, 
    decimal Amount, 
    string Description,
    ExpanseCategory Category);