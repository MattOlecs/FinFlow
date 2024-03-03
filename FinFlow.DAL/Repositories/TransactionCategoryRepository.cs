using FinFlow.DAL.Context;
using FinFlow.DAL.Entities;
using FinFlow.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinFlow.DAL.Repositories;

internal class TransactionCategoryRepository(FinFlowDbContext finFlowDbContext) : ITransactionCategoryRepository
{
	public async Task<TransactionCategoryEntity?> Get(int id)
	{
		return await finFlowDbContext.TransactionCategories.FirstOrDefaultAsync(x => x.Id == id);
	}
	
	public async Task CreateAsync(TransactionCategoryEntity transactionCategoryEntity)
	{
		await finFlowDbContext.TransactionCategories.AddAsync(transactionCategoryEntity);
		await finFlowDbContext.SaveChangesAsync();
	}
	
	public async Task<List<TransactionCategoryEntity>> GetAllAsync()
	{
		return await finFlowDbContext.TransactionCategories.ToListAsync();
	}
}