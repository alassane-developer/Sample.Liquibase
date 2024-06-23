using Core.Contracts;
using Core.Entitties;
using MediatR;

namespace Core.Features.Create;

public record CreateUserCommand(string Name, string FirstName, DateTime BirthDate) : IRequest;

internal sealed class CreateUserCommandHandler(IUserRepository repository) : IRequestHandler<CreateUserCommand>
{
    public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(Guid.NewGuid(), request.Name, request.FirstName, request.BirthDate);
        return repository.Add(user);
    }
}
