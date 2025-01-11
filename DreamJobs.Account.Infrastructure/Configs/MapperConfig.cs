using AutoMapper;
using DreamJobs.Account.Domain.Models;

namespace DreamJobs.Account.Infrastructure.Configs;

public static class MapperConfig
{
    public static MapperConfiguration RegisterMapperConfig()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<User, Entities.User>();
            config.CreateMap<Entities.User, User>();

            config.CreateMap<Employer, Entities.Employer>();
            config.CreateMap<Entities.Employer, Employer>();

            config.CreateMap<Employee, Entities.Employee>();
            config.CreateMap<Entities.Employee, Employee>();

            config.CreateMap<EmployeeProfile, Entities.EmployeeProfile>();
            config.CreateMap<Entities.EmployeeProfile, EmployeeProfile>();
        });

        return mappingConfig;
    }
}