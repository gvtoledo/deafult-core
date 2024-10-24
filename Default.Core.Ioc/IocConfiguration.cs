using Default.Core.Domain.Interfaces.Repository;
using Default.Core.Domain.Interfaces.UseCase;
using Default.Core.Repository;
using Default.Core.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Default.Core.Ioc
{
    public static class IocConfiguration
    {
        public static void AddRegistrationDependencies(this IServiceCollection services) 
        { 
            //Add configuration
            RegisterRepository(services);
            RegisterUseCases(services);
        }

        private static void RegisterUseCases(IServiceCollection services)
        {
            services
                .AddScoped<ICreateNewStudentUseCase, CreateNewStudentUseCase>()
                .AddScoped<IGetCourseUseCase, GetCourseUseCase>();

        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services
                .AddScoped<ICourseRepository, CourseRepository>()
                .AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
