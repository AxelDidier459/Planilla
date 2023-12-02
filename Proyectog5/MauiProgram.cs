using Microsoft.Extensions.Logging;
using Firebase.Database;
using Firebase.Database.Query;
//using Planilla.AppMovil.Models;
//using Android.Webkit;
using Proyectog5.Models;

namespace Proyectog5
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            Registrar();
            return builder.Build();
        }

        public static void Registrar()
        {
            FirebaseClient client = new FirebaseClient("https://proyectog5-bbb47-default-rtdb.firebaseio.com/");
            var cargos = client.Child("Cargos").OnceAsync<Cargos>();
                if(cargos.Result.Count == 0)
                {
                    client.Child("Cargos").PostAsync(new Cargos { Nombre = "Administrador"});
                    client.Child("Cargos").PostAsync(new Cargos { Nombre = "Supervisor" });
                    client.Child("Cargos").PostAsync(new Cargos { Nombre = "Dependiente" });
            }

        }
    }
}