using FinFlow.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinFlow.DAL;

public static class Extensions
{
	public static IServiceCollection AddDbContext(this IServiceCollection services, ConfigurationManager config)
	{
		var connectionString = config.GetConnectionString("PostgresDb");
		return services.AddDbContext<FinFlowDbContext>(options => options.UseNpgsql(connectionString, o => o.MigrationsAssembly("FinFlow.DAL")));
	}
}