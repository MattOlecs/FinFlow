using FinFlow.Api.DTO.TransactionCategory;

namespace FinFlow.Api.Services.Interfaces;

public interface ITransactionCategoryService
{
	Task CreateCategory(CreateTransactionCategoryDto createTransactionCategoryDto);
	Task<List<TransactionCategoryDto>> Search();
}