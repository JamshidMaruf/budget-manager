using BudgetManager.Domain.Primitives;

namespace BudgetManager.Application.Expanses.Commands.DeleteExpanse;

public class DeleteExpanseCommandHandler(IApplicationDbContext context) 
    : IRequestHandler<DeleteExpanseCommand, Result>
{
    public async Task<Result> Handle(DeleteExpanseCommand request, CancellationToken cancellationToken)
    {
        var existingExpanse = await context.Expanses
            .FindAsync([request.Id], cancellationToken);
            
        if(existingExpanse == null)
            return Result.Failure(Error.NotFound("Expanse.NotFound", "Expanse not found."));
        
        // Soft delete
        existingExpanse.Delete();
        
        await context.SaveChangesAsync(cancellationToken);
        
        return Result.Success;
    }
}

public record DeleteExpanseCommand(int Id) : IRequest<Result>;