using MediatR;
using Redarbor.System.Application.Mapper;
using Redarbor.System.Application.Model;
using Redarbor.System.Domain.DTOs;
using Redarbor.System.Domain.Repositories;

namespace Redarbor.System.Application.Employee.Queries;

public class GetEmployeeByIdQuery : EventBaseHandler, IRequest<ResponseEmployeeDto>
{
    public int Id { get; set; }
}

internal class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, ResponseEmployeeDto>
{
    private readonly IRepository<Domain.Entities.EmployeeEntity> _employeeRepository;
    public GetEmployeeByIdQueryHandler(IRepository<Domain.Entities.EmployeeEntity> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ResponseEmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        ResponseEmployeeDto response = new()
        {
            EventId = request.EventId
        };
        try
        {
            var entityEmployee = await _employeeRepository.GetById(request.Id);
            var entity = MapperConfig.Mapper.Map<EmployeeExtendDto>(entityEmployee);
            response.Response = entity;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}