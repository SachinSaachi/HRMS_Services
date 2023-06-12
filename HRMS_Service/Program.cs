//Created and Update by Sachin Saxena on 12 June 2023
using Common.AppConfiguration.Common;
using HRMS_Core.BussinessLogic.BLUserLogin;
using HRMS_Core.BussinessLogic.Dependent;
using HRMS_Core.DataAccessLayer.DatabaseHelper.Datablase.DatabaseHelper;
using HRMS_Core.DataAccessLayer.DAUserLogin;
using HRMS_Core.DataAccessLayer.Dependent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAppConfiguration, AppConfiguration>();
builder.Services.AddScoped<IExecuteQuery, ExecuteQuery>();
builder.Services.AddScoped<IDAUserLogin, DAUserLogin>();
builder.Services.AddScoped<IBLUserLogin, BLUserLogin>();
builder.Services.AddScoped<IDADependent, DADependent>();
builder.Services.AddScoped<IBLDependent, BLDependent>();


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
