using Microsoft.AspNetCore.Mvc;
using Redarbor.Events;
using Redarbor.RequestReply.Eda.Interface;
using Redarbor.System.Domain.DTOs;

namespace Redarbor.Presentation.Api.Controllers;
public class RedarborController : ApiBaseController
{
    public RedarborController(IRequestReplayService requestReplayService) : base(requestReplayService) { }

    [HttpPost]
    public async Task<ActionResult<ResponseCreateEmployeeDto>> Post([FromBody] RequestCreateEmployeeDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        request.EventId = Guid.NewGuid().ToString();
        var response = await RequestReplayService.WaitProducer<ResponseCreateEmployeeDto>(request, EmployeeEvent.CreateEmployee, EmployeeEvent.GenerateGenericSucessEvent, new TimeSpan(0, 0, 70));
        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<ResponseListEmployeeDto>> Get()
    {
        var response = await RequestReplayService.WaitProducer<ResponseListEmployeeDto>(new RequestListEmployeeDto() { EventId = Guid.NewGuid().ToString() }, EmployeeEvent.GetListEmployee, EmployeeEvent.GenerateGenericSucessEvent, new TimeSpan(0, 0, 70));
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ResponseEmployeeDto>> GetById(int id)
    {
        var response = await RequestReplayService.WaitProducer<ResponseEmployeeDto>(new RequestEmployeeById() { Id = id, EventId = Guid.NewGuid().ToString() }, EmployeeEvent.GetEmployeeId, EmployeeEvent.GenerateGenericSucessEvent, new TimeSpan(0, 0, 70));
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseUpdateEmployeeDto>> Update([FromBody] RequestUpdateEmployeeDto request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        request.EventId = Guid.NewGuid().ToString();
        var response = await RequestReplayService.WaitProducer<ResponseUpdateEmployeeDto>(request, EmployeeEvent.UpdateEmployee, EmployeeEvent.GenerateGenericSucessEvent, new TimeSpan(0, 0, 70));
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<ResponseDeleteEmployeeDto>> Delete(int id)
    {
        var response = await RequestReplayService.WaitProducer<ResponseDeleteEmployeeDto>(new RequestDeleteEmployeeDto() { Id = id, EventId = Guid.NewGuid().ToString() }, EmployeeEvent.DeleteEmployee, EmployeeEvent.GenerateGenericSucessEvent, new TimeSpan(0, 0, 70));
        return Ok(response);
    }
}