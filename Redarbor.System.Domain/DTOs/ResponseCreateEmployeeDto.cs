using Redarbor.Domain.Eda.Base;

namespace Redarbor.System.Domain.DTOs;

public class ResponseCreateEmployeeDto : ResponseDTO
{
    public int Id { get; set; }
    public bool Response { get; set; }
}