using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redarbor.System.Domain.Entities;

namespace Redarbor.System.Infraestructure.Configuration;

internal class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable($"{nameof(RoleEntity)}");
        builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
    }
}
