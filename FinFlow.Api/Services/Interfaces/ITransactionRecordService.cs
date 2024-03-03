using FinFlow.Api.DTO.TransactionRecord;

namespace FinFlow.Api.Services.Interfaces;

public interface ITransactionRecordService
{
	Task<List<TransactionRecordDto>> SearchByMonthAndYearAsync(DateOnly dateOnly);
	Task CreateAsync(CreateTransactionRecordDto createTransactionRecordDto);
}