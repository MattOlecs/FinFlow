using System.Text.Json.Serialization;
using FinFlow.Api.DTO.TransactionCategory;
using FinFlow.Api.DTO.TransactionRecord;
using FinFlow.Api.Services.Interfaces;
using FinFlow.Api.Utils;
using FinFlow.DAL;
using FinFlow.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.ConfigureHttpJsonOptions(opt => opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

//temp
builder.Services.AddCors(policyBuilder =>
	policyBuilder.AddDefaultPolicy(policy =>
		policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<FinFlowDbContext>();
	dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.MapPost("/transaction-records", async ([FromBody] CreateTransactionRecordDto createDto, ITransactionRecordService transactionRecordService) =>
{
	await transactionRecordService.CreateAsync(createDto);
}).WithOpenApi().AllowAnonymous();

app.MapPost("/transaction-records/search",
	async ([FromBody] SearchTransactionRecordDto searchDto, ITransactionRecordService transactionRecordService) =>
	await transactionRecordService.SearchByMonthAndYearAsync(searchDto.Date)).WithOpenApi().AllowAnonymous();

app.MapPost("/transaction-category",
	async ([FromBody] CreateTransactionCategoryDto createDto, ITransactionCategoryService transactionCategoryService) =>
	await transactionCategoryService.CreateCategory(createDto)).WithOpenApi().AllowAnonymous();

app.MapPost("/transaction-category/search", async (ITransactionCategoryService transactionCategoryService) => 
	await transactionCategoryService.Search()).WithOpenApi().AllowAnonymous();

app.Run();
