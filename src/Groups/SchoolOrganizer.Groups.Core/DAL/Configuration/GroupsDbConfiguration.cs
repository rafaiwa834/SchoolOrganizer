using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOrganizer.Groups.Core.Entities;

namespace SchoolOrganizer.Groups.Core.DAL.Configuration;

public class GroupsDbConfiguration: IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);
    }
}