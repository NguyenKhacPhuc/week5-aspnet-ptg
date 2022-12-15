
using Microsoft.EntityFrameworkCore;


using OderApp.DataSource;
using OderApp.DataSource.Dao;
using OderApp.DataSource.Database;
using OderApp.Repositories;
using OderApp.Services;

internal class Program
{
    private static void Main(string[] args)
    {
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
        builder.Services.AddScoped<IItemRepository, ItemRepositoryImpl>();
        builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();

        // Add Service Depedency
        builder.Services.AddScoped<LoginService, LoginServiceImpl>();
        builder.Services.AddScoped<ConfigurationService, ConfigurationServiceImpl>();
        builder.Services.AddScoped<ICustomerService, CustomerServiceImpl>();
        builder.Services.AddScoped<RegisterService, RegisterServiceImpl>();
        builder.Services.AddScoped<ItemService, ItemServiceImpl>();
        builder.Services.AddScoped<UserService, UserServiceImpl>();

        builder.Services.AddScoped<FileJsonHandler, FileJsonHandlerImpl>();
        //Add DAO Depedency
        builder.Services.AddScoped<AccountDao, DBAccountDaoImpl>();
        builder.Services.AddScoped<MenuDao, MenuDaoImpl>();
        builder.Services.AddScoped<ConfigurationDao, ConfigurationDaoImpl>();
        builder.Services.AddScoped<IOrderDao, OrderDaoImpl>();
        builder.Services.AddScoped<ItemDao, ItemDaoImpl>();
        builder.Services.AddScoped<UserDao, UserDaoImpl>();

        builder.Services.AddDbContext<OrderDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Order"))
           );
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
    }
}