namespace Core.Entitties;

public record User(Guid Id, string Name, string FirstName, DateOnly BirthDate);
