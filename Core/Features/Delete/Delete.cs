using Core.Contracts;
using MediatR;

namespace Core.Features.Delete;

public record DeleteUserCommand(Guid Id) : IRequest;

internal sealed class DeleteUserCommandHandler(IUserRepository repository) : IRequestHandler<DeleteUserCommand>
{
    public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return repository.Delete(request.Id);
    }
}
