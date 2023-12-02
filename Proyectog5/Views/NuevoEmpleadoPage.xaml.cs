using Firebase.Database;
using Firebase.Database.Query;
using Proyectog5.Models;


namespace Proyectog5.Views;

public partial class NuevoEmpleadoPage : ContentPage
{
	FirebaseClient client = new FirebaseClient("https://proyectog5-bbb47-default-rtdb.firebaseio.com/");

	public List<Cargos> Cargos { get; set; }
	public NuevoEmpleadoPage()
	{
		InitializeComponent();

		CargarCargos();
		BindingContext = this;
	}

	public void CargarCargos()
	{
		var cargos = client.Child("Cargos").OnceAsync<Cargos>();
		Cargos = cargos.Result.Select(x => x.Object).ToList();
	}

	private  async void guardarButton_Clicked (object sender, EventArgs e)
	{
		Cargos cargo = cargoPicker.SelectedItem as Cargos;
		await client.Child("Empleados").PostAsync(new Empleado
		{
			NombreCompleto = nombreEntry.Text,
			FechaInicio =fechaInicioPicker.Date,
			Salario = double.Parse(salarioEntry.Text),
			Cargo = cargo,

		});
		await Shell.Current.GoToAsync("..");
	}
}