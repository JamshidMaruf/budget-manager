using BudgetManager.Domain.Primitives;

namespace BudgetManager.Application.Expanses.Commands.CreateExpanse;

public class CreateExpanseCommandHandler(
    IApplicationDbContext context,
    IValidator<CreateExpanseCommand> validator) 
    : IRequestHandler<CreateExpanseCommand, Result>
{
    public async Task<Result> Handle(CreateExpanseCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var expanse = Expanse.Create(request.Amount, request.Description, request.Category);

        context.Expanses.Add(expanse);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return Result.Success();
    }
}

public record CreateExpanseCommand(
    decimal Amount, 
    string Description, 
    ExpanseCategory Category) : IRequest<Result>;