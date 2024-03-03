using FinFlow.DAL.Context;
using FinFlow.DAL.Entities;
using FinFlow.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.DAL.Repositories;

internal class TransactionRecordRepository(FinFlowDbContext finFlowDbContext) : ITransactionRecordRepository
{
	public async Task<TransactionRecordEntity?> Get(int id)
	{
		return await finFlowDbContext.TransactionRecords
								.Include(x => x.TransactionCategory)
								.FirstOrDefaultAsync(x => x.Id == id);
	}

	public async Task CreateAsync(TransactionRecordEntity transactionRecordEntity)
	{
		await finFlowDbContext.TransactionRecords.AddAsync(transactionRecordEntity);
		await finFlowDbContext.SaveChangesAsync();
	}

	public async Task<List<TransactionRecordEntity>> SearchByMonthAndYear(DateOnly dateOnly)
	{
		return await finFlowDbContext
				.TransactionRecords
				.Include(x => x.TransactionCategory)
				.Where(x => x.Date.Month == dateOnly.Month && x.Date.Year == dateOnly.Year)
				.ToListAsync();
	}
}