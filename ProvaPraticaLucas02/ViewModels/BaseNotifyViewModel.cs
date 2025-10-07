using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProvaPraticaLucas02.Models;
using ProvaPraticaLucas02.Services;



namespace ProvaPraticaLucas02.ViewModels
{
    public partial class BaseNotifyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
