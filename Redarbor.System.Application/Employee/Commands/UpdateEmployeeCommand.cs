using MediatR;
using Redarbor.System.Application.Mapper;
using Redarbor.System.Application.Model;
using Redarbor.System.Domain.DTOs;
using Redarbor.System.Domain.Repositories;
using Redarbor.System.Domain.UnitOfWork;

namespace Redarbor.System.Application.Employee.Commands;

public class UpdateEmployeeCommand : EventBaseHandler, IRequest<ResponseUpdateEmployeeDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Fax { get; set; }
    public string Telephone { get; set; }
    public string Password { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    public DateTime? Lastlogin { get; set; }
    public int CompanyId { get; set; }
    public int PortalId { get; set; }
    public int RoleId { get; set; }
    public int StatusId { get; set; }
}

internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ResponseUpdateEmployeeDto>
{
    private readonly IRepository<Domain.Entities.EmployeeEntity> _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeCommandHandler(IRepository<Domain.Entities.EmployeeEntity> employeeRepository,
                                        IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseUpdateEmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        ResponseUpdateEmployeeDto response = new()
        {
            EventId = request.EventId,
        };
        try
        {
            var getEntity = _employeeRepository.GetMany(x => x.Id == request.Id).FirstOrDefault();
            if (getEntity is null)
                throw new NullReferenceException($"The Employee with id: {request.Id}, not exist");
            var entity = MapperConfig.Mapper.Map<Domain.Entities.EmployeeEntity>(request);
            if (entity is null)
                throw new ApplicationException("There is a problem in mapper");
            _employeeRepository.Update(entity);
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