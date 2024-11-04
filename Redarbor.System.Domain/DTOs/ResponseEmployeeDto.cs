using Redarbor.Domain.Eda.Base;

namespace Redarbor.System.Domain.DTOs;

public class ResponseEmployeeDto : ResponseDTO
{
    public EmployeeExtendDto Response { get; set; }
}
