using AutoMapper;
using Redarbor.System.Application.Employee.Commands;
using Redarbor.System.Application.Employee.Queries;
using Redarbor.System.Domain.DTOs;

namespace Redarbor.System.Integrator.Mapper;

internal class MappingEmployeeDto : Profile
{
    public MappingEmployeeDto()
    {
        CreateMap<CreateEmployeeCommand, RequestCreateEmployeeDto>().ReverseMap();
        CreateMap<ListEmployeeQuery, RequestListEmployeeDto>().ReverseMap();
        CreateMap<GetEmployeeByIdQuery, RequestEmployeeById>().ReverseMap();
        CreateMap<UpdateEmployeeCommand, RequestUpdateEmployeeDto>().ReverseMap();
        CreateMap<DeleteEmployeeCommand, RequestDeleteEmployeeDto>().ReverseMap();
    }
}