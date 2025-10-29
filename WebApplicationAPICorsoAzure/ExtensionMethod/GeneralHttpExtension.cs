namespace WebApplicationAPICorsoAzure.ExtensionMethod
{
    public static class GeneralHttpExtension
    {

        public static void RegisterHttpServices(this IServiceCollection services)//stiamo estenendendo i services nella classe
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;//configurazione per il json in camelcase
                options.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;//ignora i valori null nel json
            });
        }

    }
}
