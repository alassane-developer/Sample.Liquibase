using Core.Contracts;
using Core.Entitties;
using Core.Exceptions;
using MediatR;

namespace Core.Features.Update;

public record UpdateUserCommand(Guid Id, string Name, string FirstName, DateTime BirthDate) : User(Id, Name, FirstName, BirthDate), IRequest;

internal sealed class UpdateUserCommandHandler(IUserRepository repository) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        _ = await repository.Get(request.Id) ??
            throw new NotFoundException("User not found");

        await repository.Update(request);
    }
}
