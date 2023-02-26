namespace SchoolOrganizer.Users.Core.DTO;

public record UpdatePasswordDto(string oldPassword, string newPassword);