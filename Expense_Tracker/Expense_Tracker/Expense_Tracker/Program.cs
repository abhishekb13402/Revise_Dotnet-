using AutoMapper;
using Expense_Tracker;
using Expense_Tracker.Data;
using Expense_Tracker.Repository.Interface;
using Expense_Tracker.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IMapper mapper = MappingConfiguration.RegisterMaps().CreateMapper();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
//builder.Services.AddDbContext<ExpenseTrackerDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));
builder.Services.AddDbContext<ExpenseTrackerDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//        .AddJwtBearer(options =>
//        {
//            options.TokenValidationParameters = new TokenValidationParameters
//            {
//                ValidateIssuer = true,
//                ValidateAudience = true,
//                ValidateLifetime = true,
//                ValidIssuer = builder.Configuration["Jwt:Issuer"],
//                ValidAudience = builder.Configuration["Jwt:Audience"],
//                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//            };
//        });

builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IPersonRepositorye, PersonRepository>();


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
