using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redarbor.System.Domain.Entities;

namespace Redarbor.System.Infraestructure.Configuration;

internal class PortalEntityConfiguration : IEntityTypeConfiguration<PortalEntity>
{
    public void Configure(EntityTypeBuilder<PortalEntity> builder)
    {
        builder.ToTable($"{nameof(PortalEntity)}");
        builder.Property(e => e.Name).HasMaxLength(128).IsRequired();
    }
}
