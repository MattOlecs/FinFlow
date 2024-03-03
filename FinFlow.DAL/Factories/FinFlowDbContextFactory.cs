using FinFlow.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinFlow.DAL.Factories;

public class FinFlowDbContextFactory : IDesignTimeDbContextFactory<FinFlowDbContext>
{
	public FinFlowDbContext CreateDbContext(string[] args)
	{
		var builder = new DbContextOptionsBuilder<FinFlowDbContext>();
		builder.UseNpgsql("User ID=admin;Password=1111;Host=localhost;Port=5432;Database=FinFlow;Pooling=true;");

		return new FinFlowDbContext(builder.Options);
	}
}