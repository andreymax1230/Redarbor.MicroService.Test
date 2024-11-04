using Redarbor.Domain.Eda.Interface.DTOs;

namespace Redarbor.System.Domain.DTOs;

public class RequestListEmployeeDto : IPayloadMessageDTO
{
    public string EventId { get; set; }
}
