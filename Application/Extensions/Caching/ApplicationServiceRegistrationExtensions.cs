using Application.Instructors.Contracts;
using Application.Instructors.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.Extensions.Caching;

public static class ApplicationServiceRegistrationExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
	{
		services.AddMemoryCache();

		services.AddScoped<IInstructorService, InstructorService>();
		services.AddScoped<IInstructorRoleService, InstructorRoleService>();

		return services;
	}
}