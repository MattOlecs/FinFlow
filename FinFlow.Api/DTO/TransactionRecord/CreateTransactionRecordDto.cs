using FinFlow.DAL.Entities.Enums;

namespace FinFlow.Api.DTO.TransactionRecord;

public record CreateTransactionRecordDto(
	string Description,
	TransactionRecordType TransactionRecordType,
	decimal Amount,
	int CategoryId,
	DateOnly Date);