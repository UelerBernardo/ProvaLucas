using System.Windows.Input;

namespace ProvaPraticaLucas02.ViewModels
{
    public partial class BaseViewModels : BaseNotifyViewModel
    {
        public ICommand VoltarCommand { get; set; }
        public async void Voltar()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public  BaseViewModels()
        {
            VoltarCommand = new Command(Voltar);
        }
        public async void AbrirView(ContentPage view)
        {
            await Application.Current.MainPage.Navigation.PushAsync(view);
        }
    }
}
