using MediatR;
using Redarbor.System.Application.Mapper;
using Redarbor.System.Application.Model;
using Redarbor.System.Domain.DTOs;
using Redarbor.System.Domain.Repositories;
using Redarbor.System.Domain.UnitOfWork;

namespace Redarbor.System.Application.Employee.Commands;

public class CreateEmployeeCommand : EventBaseHandler, IRequest<ResponseCreateEmployeeDto>
{
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

internal class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResponseCreateEmployeeDto>
{
    private readonly IRepository<Domain.Entities.EmployeeEntity> _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IRepository<Domain.Entities.EmployeeEntity> employeeRepository, 
                                        IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseCreateEmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        ResponseCreateEmployeeDto response = new()
        {
            EventId = request.EventId,
        };
        try
        {
            var exist = await _employeeRepository.Get(x => x.Email.Trim().ToUpper() == request.Email);
            if (exist is not null)
                throw new ApplicationException($"There is already a registration with email: {request.Email}");
            var entity = MapperConfig.Mapper.Map<Domain.Entities.EmployeeEntity>(request);
            if (entity is null)
                throw new ApplicationException("There is a problem in mapper");
            _employeeRepository.Insert(entity);
            var responseBD = await _unitOfWork.CommitAsync(cancellationToken);
            if (responseBD <= 0)
                response.ErrorMessage = $"Error save entitie: {nameof(Domain.Entities.EmployeeEntity)} in BD";
            response.Id = entity.Id;
            response.Response = responseBD > 0;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }
        return response;
    }
}