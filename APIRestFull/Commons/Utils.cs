using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIRestFull.Commons
{
    public static class Utils
    {
        public static void insertServices(WebApplicationBuilder builder)
        {
            var listaclases = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t =>t.IsClass && !t.IsAbstract && (t.Name.Contains("_serv") || t.Name.Contains("_sserv"))).ToList();

            foreach (var t in listaclases)
            {
                if (t.Name.Contains("_sserv"))
                {
                    builder.Services.AddSingleton(t);
                }
                else
                {
                    builder.Services.AddScoped(t.GetInterfaces().FirstOrDefault(), t);
                }                                    
            }
        }

        public static T transform<T>(object input)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(input));
        }
    }
}
