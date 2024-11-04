using Microsoft.AspNetCore.Mvc;
using Redarbor.RequestReply.Eda.Interface;

namespace Redarbor.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiBaseController : Controller
{
    protected IRequestReplayService RequestReplayService;

    public ApiBaseController(IRequestReplayService requestReplayService)
    {
        RequestReplayService = requestReplayService;
    }
}