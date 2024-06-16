using FinFlow.Api.DTO.TransactionRecord;
using FinFlow.Api.Services.Interfaces;
using FinFlow.DAL.Entities;
using FinFlow.DAL.Repositories.Interfaces;

namespace FinFlow.Api.Services;

public class TransactionRecordService : ITransactionRecordService
{
	private readonly ITransactionRecordRepository _transactionRecordRepository;

	public TransactionRecordService(ITransactionRecordRepository transactionRecordRepository)
	{
		_transactionRecordRepository = transactionRecordRepository;
	}

	public async Task<List<TransactionRecordDto>> SearchByMonthAndYearAsync(DateTime datetime)
	{
		var records = await _transactionRecordRepository.SearchByMonthAndYear(datetime);

		return records.Select(x => new TransactionRecordDto(
			x.Id, x.Description, x.Type, x.Amount, x.Date, x.TransactionCategory.Name)).ToList();
	}
	
	public async Task CreateAsync(CreateTransactionRecordDto createTransactionRecordDto)
	{
		var entity = new TransactionRecordEntity
		{
			Description = createTransactionRecordDto.Description,
			Type = createTransactionRecordDto.TransactionRecordType,
			Amount = createTransactionRecordDto.Amount,
			CategoryId = createTransactionRecordDto.CategoryId,
			Date = createTransactionRecordDto.Date
		};

		await _transactionRecordRepository.CreateAsync(entity);
	}
}