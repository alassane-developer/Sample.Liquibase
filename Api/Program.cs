using Api;
using Core;
using Core.Features.Create;
using Core.Features.Delete;
using Core.Features.Get;
using Core.Features.Update;
using Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => config.CustomSchemaIds(x => x.FullName));
builder.Services.RegisterCoreServices();
builder.Services.RegisterInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

var users = app.MapGroup("/users").WithOpenApi();
users.MapPost("/create", async (User user, IMediator mediator) =>
{
    var creatCommand = new CreateUserCommand(user.Name, user.FirstName, user.BirthDate.Date);
    await mediator.Send(creatCommand);
    return Results.Created($"/users/{user.Name}", user);
});

users.MapGet("/", async (IMediator mediator) =>
{
    var query = new GetAllUsersQuery();
    return await mediator.Send(query);
});

users.MapGet("/{name}", async (string name, IMediator mediator) =>
{
    var query = new GetUserByNameQuery(name);
    return await mediator.Send(query);
});

users.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
{
    var query = new GetUserByIdQuery(id);
    return await mediator.Send(query);
});

users.MapPut("/{id:Guid}", async (Guid id, User user, IMediator mediator) =>
{
    var updateCommand = new UpdateUserCommand(id, user.Name, user.FirstName, user.BirthDate);
    await mediator.Send(updateCommand);
    return Results.NoContent();
});

users.MapDelete("/{id:Guid}", async (Guid id, IMediator mediator) =>
{
    var deleteCommand = new DeleteUserCommand(id);
    await mediator.Send(deleteCommand);
    return Results.NoContent();
});

app.Run();
