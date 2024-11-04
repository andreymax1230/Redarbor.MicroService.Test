using Redarbor.Domain.Eda.Base;

namespace Redarbor.System.Domain.DTOs;

public class ResponseListEmployeeDto : ResponseDTO
{
    public List<EmployeeExtendDto> Response { get; set; }
}