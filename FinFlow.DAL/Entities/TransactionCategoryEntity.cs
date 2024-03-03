using Microsoft.EntityFrameworkCore;

namespace FinFlow.DAL.Entities;

[PrimaryKey(nameof(Id))]
public class TransactionCategoryEntity
{
	public int Id { get; set; }

	public string Name { get; set; }
}