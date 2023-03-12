using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOrganizer.Customers.Domain.Entities;

namespace SchoolOrganizer.Customers.Infrastructure.DAL.Configurations;

public class ParentConfiguration: IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder.HasKey(x => x.Id);
    }
}