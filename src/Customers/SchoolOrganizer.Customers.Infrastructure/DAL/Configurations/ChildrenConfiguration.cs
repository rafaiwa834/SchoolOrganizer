using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOrganizer.Customers.Domain.Entities;

namespace SchoolOrganizer.Customers.Infrastructure.DAL.Configurations;

public class ChildrenConfiguration: IEntityTypeConfiguration<Child>
{
    public void Configure(EntityTypeBuilder<Child> builder)
    {
        builder.HasKey(x => x.Id);
    }
}