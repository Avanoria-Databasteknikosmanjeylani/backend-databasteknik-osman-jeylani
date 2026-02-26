using Application.Instructors.Caching;
using Domain.Instructors.Repositories;
using Domain.Modules.Courses.Repositories;
using Infrastructure.Persistence.EFC.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		IConfiguration configuration,
		IHostEnvironment environment)
	{
		services.AddDbContext<CourseOnlineDbContext>(options =>
			options.UseSqlServer(
				configuration.GetConnectionString("CourseOnlineDB")));

		services.AddScoped<IInstructorRepository, InstructorRepository>();
		services.AddScoped<IInstructorRoleRepository, InstructorRoleRepository>();

		services.AddScoped<ICourseRepository, CourseRepository>();


		services.AddScoped<InstructorCache>();

		return services;
	}
}
	