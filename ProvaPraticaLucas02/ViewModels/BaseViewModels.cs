using System.Windows.Input;

namespace ProvaPraticaLucas02.ViewModels
{
    internal partial class BaseViewModels : BaseNotifyViewModel
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
    }
}
