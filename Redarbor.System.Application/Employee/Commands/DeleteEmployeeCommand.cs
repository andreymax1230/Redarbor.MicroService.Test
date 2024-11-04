using MediatR;
using Redarbor.System.Application.Model;
using Redarbor.System.Domain.DTOs;
using Redarbor.System.Domain.Repositories;
using Redarbor.System.Domain.UnitOfWork;

namespace Redarbor.System.Application.Employee.Commands;

public class DeleteEmployeeCommand : EventBaseHandler, IRequest<ResponseUpdateEmployeeDto>
{
    public int Id { get; set; }
}

internal class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ResponseUpdateEmployeeDto>
{
    private readonly IRepository<Domain.Entities.EmployeeEntity> _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IRepository<Domain.Entities.EmployeeEntity> employeeRepository, 
                                        IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseUpdateEmployeeDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        ResponseUpdateEmployeeDto response = new()
        {
            EventId = request.EventId,
        };
        try
        {
            var getEntity = await _employeeRepository.GetById(request.Id);
            if (getEntity is null)
                throw new NullReferenceException($"The Employee with id: {request.Id}, not exist");
            _employeeRepository.Delete(getEntity);
            await _unitOfWork.CommitAsync(cancellationToken);
            response.Response = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}