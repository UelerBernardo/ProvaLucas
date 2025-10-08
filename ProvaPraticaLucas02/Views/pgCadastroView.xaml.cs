using ProvaPraticaLucas02.ViewModels;

namespace ProvaPraticaLucas02.Views;

public partial class pgCadastroView : ContentPage
{
	public pgCadastroView()
	{
		InitializeComponent();

		// Vincular o front com o back
		BindingContext = new UsuarioViewModel();
	}
}