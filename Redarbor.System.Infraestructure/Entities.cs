using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Redarbor.System.Infraestructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.System.Infraestructure;

public partial class Entities : IdentityDbContext
{
    #region Ctor
    private readonly IHttpContextAccessor _contextAccessor;
    public Entities()
    {
    }

    public Entities(DbContextOptions<Entities> options, IHttpContextAccessor contextAccessor = null) : base(options)
    {
        _contextAccessor = contextAccessor;
    }

    #endregion

    #region Utilities

    /// <summary>
    /// Further configuration the model
    /// </summary>
    /// <param name="builder">The builder being used to construct the model for this context</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CompanyEntityConfiguration());
        builder.ApplyConfiguration(new EmployeeEntityConfiguration());
        builder.ApplyConfiguration(new PortalEntityConfiguration());
        builder.ApplyConfiguration(new RoleEntityConfiguration());
        builder.ApplyConfiguration(new StatusEntityConfiguration());
        base.OnModelCreating(builder);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates a DbSet that can be used to query and save instances of entity
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>A set for the given entity type</returns>
    public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }


    #endregion
}
