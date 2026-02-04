namespace BudgetManager.Application.Expanses.Queries;

public class GetByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetByIdQuery, GetByIdQueryResponse>
{
    public async Task<GetByIdQueryResponse> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var expanse = await context.Expanses
            .Where(e => !e.IsDeleted)
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new Exception("Expanse not found.");
        
        return new GetByIdQueryResponse(
            expanse.Id,
            expanse.Amount,
            expanse.Description, 
            expanse.Category);
    }
}

public record GetByIdQuery(int Id) : IRequest<GetByIdQueryResponse>;

public record GetByIdQueryResponse(
    int Id, 
    decimal Amount, 
    string Description,
    ExpanseCategory Category);