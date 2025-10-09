using ProvaPraticaLucas02.ViewModels;

namespace ProvaPraticaLucas02.Views;

public partial class pgPrincipalView : ContentPage
{
	public pgPrincipalView()
	{
		InitializeComponent();
		BindingContext = new UsuarioViewModel();

        var userViewModel = new UsuarioViewModel();
        
        BindingContext = userViewModel;
        
        userViewModel.CommandVisualizarUsuario.Execute(null);
    }
}