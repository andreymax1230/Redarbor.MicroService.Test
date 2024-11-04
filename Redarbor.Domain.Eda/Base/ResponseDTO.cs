using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Domain.Eda.Base;

public class ResponseDTO
{
    public string EventId { get; set; } = string.Empty;

    public string ErrorMessage { get; set; } = string.Empty;

    public string Topic { get; set; } = string.Empty;
}