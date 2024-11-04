using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redarbor.System.Domain.Entities;

namespace Redarbor.System.Infraestructure.Configuration;

internal class StatusEntityConfiguration : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.ToTable($"{nameof(StatusEntity)}");
        builder.Property(e => e.Name).HasMaxLength(128).IsRequired();
    }
}
