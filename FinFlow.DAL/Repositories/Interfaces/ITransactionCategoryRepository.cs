using FinFlow.DAL.Entities;

namespace FinFlow.DAL.Repositories.Interfaces;

public interface ITransactionCategoryRepository
{
	Task<TransactionCategoryEntity?> Get(int id);
	Task CreateAsync(TransactionCategoryEntity transactionCategoryEntity);
	Task<List<TransactionCategoryEntity>> GetAllAsync();
}