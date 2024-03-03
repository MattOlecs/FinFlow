using FinFlow.DAL.Entities.Enums;

namespace FinFlow.Api.DTO.TransactionRecord;

public record TransactionRecordDto(
	int Id,
	string Description,
	TransactionRecordType TransactionRecordType,
	decimal Amount,
	DateOnly Date,
	string CategoryName);