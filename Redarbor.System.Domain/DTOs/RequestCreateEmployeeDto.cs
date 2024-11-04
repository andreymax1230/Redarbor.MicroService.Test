using Redarbor.Domain.Eda.Interface.DTOs;
using System.Text.Json.Serialization;

namespace Redarbor.System.Domain.DTOs;

public class RequestCreateEmployeeDto : EmployeeDto, IPayloadMessageDTO
{
    [JsonIgnore]
    public string EventId { get; set; } = string.Empty;
}
