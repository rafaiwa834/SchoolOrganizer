namespace SchoolOrganizer.Users.Core.Services;

public static class HashingService
{
    public static string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, SaltPassword());
    }

    public static bool Verify(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
    
    private static string SaltPassword()
    {
        return BCrypt.Net.BCrypt.GenerateSalt(10);
    }
}