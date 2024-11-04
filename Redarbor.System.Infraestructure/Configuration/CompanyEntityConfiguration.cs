using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redarbor.System.Domain.Entities;
using System.Net.NetworkInformation;

namespace Redarbor.System.Infraestructure.Configuration;

internal class CompanyEntityConfiguration : IEntityTypeConfiguration<CompanyEntity>
{
    public void Configure(EntityTypeBuilder<CompanyEntity> builder)
    {
        builder.ToTable($"{nameof(CompanyEntity)}");
        builder.Property(c => c.Name).HasMaxLength(256).IsRequired();
    }
}
