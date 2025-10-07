using ProvaPraticaLucas02.ViewModels;
namespace ProvaPraticaLucas02.Views;


public partial class pgLoginUsuarioView : ContentPage
{
	public pgLoginUsuarioView(UsuarioViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}