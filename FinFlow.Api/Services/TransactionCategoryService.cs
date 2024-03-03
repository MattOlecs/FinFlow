using FinFlow.Api.DTO.TransactionCategory;
using FinFlow.Api.Services.Interfaces;
using FinFlow.DAL.Entities;
using FinFlow.DAL.Repositories.Interfaces;

namespace FinFlow.Api.Services;

public class TransactionCategoryService : ITransactionCategoryService
{
	private readonly ITransactionCategoryRepository _transactionCategoryRepository;

	public TransactionCategoryService(ITransactionCategoryRepository transactionCategoryRepository)
	{
		_transactionCategoryRepository = transactionCategoryRepository;
	}

	public async Task CreateCategory(CreateTransactionCategoryDto createTransactionCategoryDto)
	{
		var entity = new TransactionCategoryEntity { Name = createTransactionCategoryDto.Name };

		await _transactionCategoryRepository.CreateAsync(entity);
	}
	
	public async Task<List<TransactionCategoryDto>> Search()
	{
		var categories = await _transactionCategoryRepository.GetAllAsync();

		return categories.Select(x => new TransactionCategoryDto(x.Id, x.Name)).ToList();
	}
}