namespace Core.Entitties;

public record User(Guid Id, string Name, string FirstName, DateTime BirthDate)
{
    public User() : this(Guid.Empty, string.Empty, string.Empty, new DateTime())
    {
    }
};
