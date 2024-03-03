using FinFlow.DAL.Entities.Enums;

namespace FinFlow.DAL.Entities;

public class TransactionRecordEntity
{
	public int Id { get; set; }
	public string Description { get; set; }
	public TransactionRecordType Type { get; set; }
	public decimal Amount { get; set; }
	public int CategoryId { get; set; }

	public virtual TransactionCategoryEntity TransactionCategory { get; set; }
}