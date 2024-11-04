using MediatR;
using Redarbor.System.Application.Mapper;
using Redarbor.System.Application.Model;
using Redarbor.System.Domain.DTOs;
using Redarbor.System.Domain.Repositories;

namespace Redarbor.System.Application.Employee.Queries;

public class ListEmployeeQuery : EventBaseHandler, IRequest<ResponseListEmployeeDto>
{

}

internal class ListEmployeeQueryHandler: IRequestHandler<ListEmployeeQuery, ResponseListEmployeeDto>
{
    private readonly IRepository<Domain.Entities.EmployeeEntity> _employeeRepository;

    public ListEmployeeQueryHandler(IRepository<Domain.Entities.EmployeeEntity> employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ResponseListEmployeeDto> Handle(ListEmployeeQuery request, CancellationToken cancellationToken)
    {
        ResponseListEmployeeDto response = new()
        {
            EventId = request.EventId
        };
        try
        {
            var listEmployee = await _employeeRepository.GetAll();
            var list = MapperConfig.Mapper.Map<List<EmployeeExtendDto>>(listEmployee);
            response.Response = list;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}