using Core.Contracts;
using Core.Entitties;
using Core.Exceptions;
using MediatR;
using System.Collections.Generic;

namespace Core.Features.Get;

public record GetUserByNameQuery(string Name) : IRequest<User>;

internal sealed class GetUserByNameQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByNameQuery, User>
{
    public async Task<User> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
    {
        return await repository.Get(request.Name) ?? throw new NotFoundException("User not found");
    }
}

public record GetUserByIdQuery(Guid Id) : IRequest<User>;

internal sealed class GetUserByIdQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByIdQuery, User>
{
    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.Get(request.Id) ?? throw new NotFoundException("User not found");
    }
}

public record GetAllUsersQuery() : IRequest<IEnumerable<User>>;

internal sealed class GetAllUsersQueryHandler(IUserRepository repository) : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAll();
    }
}
