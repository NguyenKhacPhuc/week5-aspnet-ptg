using OderApp.DataSource;
using OderApp.DataSource.Dao;
using OderApp.Repositories;
using OderApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add Repository Depedency
builder.Services.AddScoped<IAccountRepository, AccountRepositoryImpl>();
builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepositoryImpl>();
builder.Services.AddScoped<IMenuRepository, MenuRepositoryImpl>();
builder.Services.AddScoped<IOrderRepository, OrderRepositoryImpl>();

// Add Service Depedency
builder.Services.AddScoped<LoginService, LoginServiceImpl>();
builder.Services.AddScoped<ConfigurationService, ConfigurationServiceImpl>();
builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
builder.Services.AddScoped<RegisterService, RegisterServiceImpl>();

builder.Services.AddScoped<FileJsonHandler, FileJsonHandlerImpl>();
//Add DAO Depedency
builder.Services.AddScoped<AccountDao, AccountDaoImpl>();
builder.Services.AddScoped<MenuDao, MenuDaoImpl>();
builder.Services.AddScoped<ConfigurationDao, ConfigurationDaoImpl>();
builder.Services.AddScoped<IOrderDao, OrderDaoImpl>();


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
