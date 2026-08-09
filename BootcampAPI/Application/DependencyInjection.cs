using BootcampAPI.Application.Common.Behaviors;
using BootcampAPI.Application.Interfaces;
using BootcampAPI.Infrastructure.Persistance;
using BootcampAPI.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BootcampAPI.Api.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>
			(options =>
				options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
			);

			services.AddScoped<IAccountRepository, AccountRepository>();

			return services;
		}

		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
	}
}
