using ProvaPraticaLucas02.ViewModels;

namespace ProvaPraticaLucas02.Views;

public partial class pgPrincipalView : ContentPage
{
	public pgPrincipalView()
	{
		InitializeComponent();

        var usuarioViewModel = new UsuarioViewModel();
        //Irei fazer o vincular do Binding
        BindingContext = usuarioViewModel;
        //Agora iremos chamar o ConsultarCommand diretamente
        usuarioViewModel.CommandConsultarUsuario.Execute(null);
    }
}