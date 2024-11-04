using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Domain.Eda.Interface.DTOs;

public interface IPayloadMessageDTO
{
    /// <summary>
    /// Event Identifier
    /// </summary>
    public string EventId { get; set; }
}