using AutoMapper;
using Redarbor.System.Application.Employee.Commands;
using Redarbor.System.Domain.DTOs;

namespace Redarbor.System.Application.Mapper;

internal class MappingEmployee : Profile
{
    public MappingEmployee()
    {
        CreateMap<Domain.Entities.EmployeeEntity, CreateEmployeeCommand>().ReverseMap();
        CreateMap<Domain.Entities.EmployeeEntity, EmployeeDto>().ReverseMap();
        CreateMap<Domain.Entities.EmployeeEntity, EmployeeExtendDto>().ReverseMap();
        CreateMap<Domain.Entities.EmployeeEntity, UpdateEmployeeCommand>().ReverseMap();
    }
}