using AutoMapper;
using DreamJobs.Account.Core.Models;
using DreamJobs.Account.Core.Models.DTOs;

namespace DreamJobs.Account.BL.Configs;

public static class MapperConfig
{
    public static MapperConfiguration RegisterMapperConfig()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<Employee, EmployeeDto>();
            config.CreateMap<EmployeeDto, Employee>();

            config.CreateMap<EmployeeDto, EmployeeRegisterDto>();
            config.CreateMap<EmployeeRegisterDto, EmployeeDto>();

            config.CreateMap<Employer, EmployerDto>();
            config.CreateMap<EmployerDto, Employer>();

            config.CreateMap<EmployerDto, EmployerRegisterDto>();
            config.CreateMap<EmployerRegisterDto, EmployerDto>();
        });

        return mappingConfig;
    }
}