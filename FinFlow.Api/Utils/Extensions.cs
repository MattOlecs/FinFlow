using FinFlow.Api.Services;
using FinFlow.Api.Services.Interfaces;

namespace FinFlow.Api.Utils;

public static class Extensions
{
	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddTransient<ITransactionRecordService, TransactionRecordService>();
		services.AddTransient<ITransactionCategoryService, TransactionCategoryService>();

		return services;
	}
}