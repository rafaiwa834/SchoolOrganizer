namespace SchoolOrganizer.Shared.Abstractions.Exceptions;

public abstract class SchoolOrganizerException: Exception
{
    public abstract int StatusCode { get; set; }      
    public SchoolOrganizerException(string message ): base(message)
    {
        
    }
    
}