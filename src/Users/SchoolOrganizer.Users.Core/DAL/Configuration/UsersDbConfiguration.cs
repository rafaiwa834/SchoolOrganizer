using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOrganizer.Users.Core.Entities;

namespace SchoolOrganizer.Users.Core.DAL.Configuration;

public class UsersDbConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.RefreshToken)
            .IsRequired(false);
    }
}