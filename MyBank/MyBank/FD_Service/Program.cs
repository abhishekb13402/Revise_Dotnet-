using AutoMapper;
using FD_Service.Data;
using Microsoft.EntityFrameworkCore;
using MyBank;
using FD_Service.Repository.Interface;
using FD_Service.Repository;
using FD_Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IMapper mapper = MappingConfigurationFD_Service.RegisterMaps().CreateMapper();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<FDDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FDdbcs")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<IFDDetailsRepository, FDDetailsRepository>();
builder.Services.AddScoped<ICustomerFDDetailsRepository, CustomerFDDetailsRepository>();
builder.Services.AddScoped<IMaturityAmountCalculation, MaturityAmountCalculationRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
