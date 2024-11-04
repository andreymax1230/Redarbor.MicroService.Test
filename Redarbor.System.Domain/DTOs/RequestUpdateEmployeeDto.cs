using Redarbor.Domain.Eda.Interface.DTOs;
using System.Text.Json.Serialization;

namespace Redarbor.System.Domain.DTOs;

public class RequestUpdateEmployeeDto : EmployeeDto, IPayloadMessageDTO
{
    public int Id { get; set; }

    [JsonIgnore]
    public string EventId { get; set; } = string.Empty;
}
