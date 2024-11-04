using System.ComponentModel.DataAnnotations;

namespace Redarbor.System.Domain.DTOs;

public class EmployeeDto
{
    public string Name { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Email { get; set; }
    public string Fax { get; set; }
    public string Telephone { get; set; }

    [Required]
    public string Password { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public DateTime? Lastlogin { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public int PortalId { get; set; }

    [Required]
    public int RoleId { get; set; }

    [Required]
    public int StatusId { get; set; }
}
