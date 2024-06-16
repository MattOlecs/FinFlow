using FinFlow.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.DAL.Context;

public class FinFlowDbContext : DbContext
{
	public FinFlowDbContext(DbContextOptions<FinFlowDbContext> options): base(options) { }
	
	public FinFlowDbContext()
	{
		
	}
	
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<TransactionRecordEntity>()
				.HasKey(x => x.Id);
		
		modelBuilder.Entity<TransactionRecordEntity>()
				.HasOne(x => x.TransactionCategory)
				.WithMany()
				.HasForeignKey(x => x.CategoryId);

		modelBuilder.Entity<TransactionRecordEntity>()
			.Property(x => x.Amount)
			.HasPrecision(18, 2);

		modelBuilder.Entity<TransactionCategoryEntity>().HasKey(x => x.Id);
		
		base.OnModelCreating(modelBuilder);
	}

	public DbSet<TransactionRecordEntity> TransactionRecords { get; set; }
	public DbSet<TransactionCategoryEntity> TransactionCategories { get; set; }
}