using ExamenTrabajo.Persistencia;

namespace ExamenTrabajo;

public static class ApplicationRegisterExtensions
{
    public static void AddRegistrationServices(this IServiceCollection service)
    {
        service.AddScoped(typeof(IDbRepository), typeof(DbRepository));
    }
}