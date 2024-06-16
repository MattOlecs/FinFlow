using FinFlow.Api.DTO.TransactionCategory;
using FinFlow.DAL.Entities;

namespace FinFlow.Api.Services.Interfaces;

public interface ITransactionCategoryService
{
	Task<TransactionCategoryEntity> CreateCategory(CreateTransactionCategoryDto createTransactionCategoryDto);
	Task<List<TransactionCategoryDto>> Search();
}