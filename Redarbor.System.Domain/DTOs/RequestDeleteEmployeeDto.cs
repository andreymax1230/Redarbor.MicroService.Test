using Redarbor.Domain.Eda.Interface.DTOs;

namespace Redarbor.System.Domain.DTOs;

public class RequestDeleteEmployeeDto : IPayloadMessageDTO
{
    public int Id { get; set; }
    public string EventId { get; set; }
}
