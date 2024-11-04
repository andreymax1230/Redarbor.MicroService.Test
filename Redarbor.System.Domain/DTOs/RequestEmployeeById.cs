using Redarbor.Domain.Eda.Interface.DTOs;

namespace Redarbor.System.Domain.DTOs;

public class RequestEmployeeById : IPayloadMessageDTO
{
    public int Id { get; set; }
    public string EventId { get; set; }
}
