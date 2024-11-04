using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redarbor.System.Domain.Entities;

namespace Redarbor.System.Infraestructure.Configuration;

internal class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ToTable($"{nameof(EmployeeEntity)}");
        #region required fields
        builder.Property(e => e.CompanyId).IsRequired();
        builder.Property(e => e.PortalId).IsRequired();
        builder.Property(e => e.RoleId).IsRequired();
        builder.Property(e => e.StatusId).IsRequired();
        builder.Property(e => e.Email).HasMaxLength(256).IsRequired();
        builder.Property(e => e.Password).HasMaxLength(1024).IsRequired();
        builder.Property(e => e.UserName).HasMaxLength(128).IsRequired();
        #endregion

        #region 
        builder.Property(e => e.Name).HasMaxLength(128);
        builder.Property(e => e.Fax).HasMaxLength(128);
        builder.Property(e => e.Fax).HasMaxLength(128);
        #endregion
    }
}