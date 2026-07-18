using BootcampAPI.Application.Interfaces;
using BootcampAPI.Infrastructure.Persistance;
using BootcampAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BootcampAPI.Infrastructure
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
	}
}
