using System.ComponentModel.DataAnnotations.Schema;

namespace Redarbor.System.Domain.Entities;

public class EmployeeEntity : BaseEntity
{
    public string Name { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Fax { get; set; }

    public string Telephone { get; set; }

    public string Password { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public DateTime? Lastlogin { get; set; }

    public int CompanyId { get; set; }

    [ForeignKey("CompanyId")]
    public virtual CompanyEntity CompanyEntity { get; set; }

    public int PortalId { get; set; }

    [ForeignKey("PortalId")]
    public virtual PortalEntity PortalEntity { get; set; }

    public int RoleId { get; set; }

    [ForeignKey("RoleId")]
    public virtual RoleEntity RoleEntity { get; set; }

   
    public int StatusId { get; set; }

    [ForeignKey("StatusId")]
    public virtual StatusEntity StatusEntity { get; set; }
}