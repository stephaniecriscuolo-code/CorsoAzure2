using WebApplicationAPICorsoAzure.ToDoItemes;

namespace WebApplicationAPICorsoAzure.ExtensionMethod;

public static class ApplicationServices
{
    public static void RegisteredServices(this IServiceCollection services)//stiamo estenendendo i services nella classe
    {
        services.AddSwaggerGen();//servizio che implementa swagger per open api
        // Add services to the container.
        services.AddScoped<ITodoItems, MockItemsServicecs>();
        services.AddScoped<IProducts, ProductsService>();
        services.AddDbContext<DBContext>(x => x.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=tempdb;Trusted_Connection=True;"));//servizio per il contesto del database

    }
}
