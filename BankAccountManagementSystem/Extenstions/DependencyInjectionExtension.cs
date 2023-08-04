using AutoMapper;
using BankAccountManagementSystem.Mapper;

namespace BankAccountManagementSystem.Extenstions
{
    public static class DependencyInjectionExtension
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
