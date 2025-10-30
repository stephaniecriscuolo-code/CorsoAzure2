using Microsoft.EntityFrameworkCore;
using WebApplicationAPICorsoAzure.Configuration;
using WebApplicationAPICorsoAzure.ToDoItemes;

namespace WebApplicationAPICorsoAzure.ExtensionMethod;

public static class ApplicationServices
{
    public static void RegisteredServices(this IServiceCollection services, IConfiguration configuration)//stiamo estenendendo i services nella classe
    {
        var conn = configuration["miaconnectionstring"];
        services.AddSwaggerGen();//servizio che implementa swagger per open api
        // Add services to the container.
        services.AddScoped<ITodoItems, MockItemsServicecs>();
        services.AddScoped<IProducts, ProductsService>();
        services.AddDbContext<DBContext>(x => x.UseSqlServer(configuration.GetConnectionString("miaconnectionstring")));
        // services.AddDbContext<DBContext>(x => x.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=tempdb;Trusted_Connection=True;"));//servizio per il contesto del database
        services.Configure<AppSettings>(configuration.GetSection("AppSettings")); //classe di AppSettings collegata con l'AppSettings.json
    }
}
