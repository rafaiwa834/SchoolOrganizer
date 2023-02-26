namespace SchoolOrganizer.Shared.Abstractions.Context;

public interface IUserContext
{
    public Guid? UserId { get; }
}