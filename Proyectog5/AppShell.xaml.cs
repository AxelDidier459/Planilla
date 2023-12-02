using Proyectog5.Views;

namespace Proyectog5
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Rutas de acceso
            Routing.RegisterRoute(nameof(NuevoEmpleadoPage), typeof(NuevoEmpleadoPage));
        }
    }
}