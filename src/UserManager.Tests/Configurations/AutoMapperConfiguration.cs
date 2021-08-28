using AutoMapper;
using UserManager.Domain.Entities;
using UserManager.Services.DTO;

namespace UserManager.Tests.configurations
{
    public static class AutoMapperConfiguration
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserDTO>()
                    .ReverseMap();
            });

            return autoMapperConfig.CreateMapper();
        }
    }
}