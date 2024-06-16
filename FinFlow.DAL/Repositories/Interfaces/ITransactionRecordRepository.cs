using FinFlow.DAL.Entities;

namespace FinFlow.DAL.Repositories.Interfaces;

public interface ITransactionRecordRepository
{
	Task<TransactionRecordEntity?> Get(int id);
	Task CreateAsync(TransactionRecordEntity transactionRecordEntity);
	Task<List<TransactionRecordEntity>> SearchByMonthAndYear(DateTime dateOnly);
}