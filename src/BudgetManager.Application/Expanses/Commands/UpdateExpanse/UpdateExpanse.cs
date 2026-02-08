using BudgetManager.Domain.Errors;
using BudgetManager.Domain.Primitives;

namespace BudgetManager.Application.Expanses.Commands.UpdateExpanse;

public class UpdateExpanseCommandHandler(
    IApplicationDbContext context,
    IValidator<UpdateExpanseCommand> validator)
    : IRequestHandler<UpdateExpanseCommand, Result>
{
    public async Task<Result> Handle(UpdateExpanseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return ExpanseError.Validation(validationResult.Errors.First().ErrorMessage);

        var existingExpanse = await context.Expanses
            .FindAsync([request.Id], cancellationToken);

        if (existingExpanse == null)
            return ExpanseError.NotFound(request.Id);
        
        existingExpanse.Update(request.Amount, request.Description, request.Category);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}

public record UpdateExpanseCommand(
    int Id, 
    decimal Amount, 
    string Description,
    ExpanseCategory Category) : IRequest<Result>;