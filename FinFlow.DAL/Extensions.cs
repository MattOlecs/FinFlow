using FinFlow.DAL.Context;
using FinFlow.DAL.Repositories;
using FinFlow.DAL.Repositories.Interfaces;
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

	public static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddTransient<ITransactionCategoryRepository, TransactionCategoryRepository>();
		services.AddTransient<ITransactionRecordRepository, TransactionRecordRepository>();

		return services;
	}
}