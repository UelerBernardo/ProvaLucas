using ProvaPraticaLucas02.Services;
using ProvaPraticaLucas02.Models;
using System.Windows.Input;
using System.Runtime.ConstrainedExecution;


namespace ProvaPraticaLucas02.ViewModels
{
    public partial class UsuarioViewModel : BaseNotifyViewModel
    {
      
        private string _emailDigitado = string.Empty;
        public string EmailDigitado
        {
            get { return _emailDigitado; }
            set
            {
                _emailDigitado = value;
                OnPropertyChanged();
            }
        }

        // <-- CORREÇÃO: Convertido para o padrão manual.
        private string _senhaDigitada = string.Empty;
        public string SenhaDigitada
        {
            get { return _senhaDigitada; }
            set
            {
                _senhaDigitada = value;
                OnPropertyChanged();
            }
        }

        private UsuarioServices _usuarioService = new UsuarioServices();

        private string _cpf = string.Empty;
        private string _nome = string.Empty;
        private DateOnly _datanascimento; // DateOnly não é anulável por padrão, ok
        private string _email = string.Empty;
        private string _senha = string.Empty;

        public string CPF { get => _cpf; set { _cpf = value; OnPropertyChanged(); } }
        public string Nome { get => _nome; set { _nome = value; OnPropertyChanged(); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }
        public string Senha { get => _senha; set { _senha = value; OnPropertyChanged(); } }
        public DateOnly DataNascimento { get => _datanascimento; set { _datanascimento = value; OnPropertyChanged(); } }

        // --- COMANDOS ---
        public ICommand CommandCadastrarUsuario { get; set; }
        public ICommand CommandConsultarUsuario { get; set; }
        public ICommand CommandValidacaoLogin { get; set; } // <-- O nome aqui estava diferente do usado no construtor

        // --- MÉTODOS DOS COMANDOS ---
        void CadastrarUsuario()
        {
            Usuario user = new Usuario();
            user.Nome = Nome;
            user.DataNascimento = DataNascimento;
            user.Email = Email;
            user.Senha = Senha;
            user.CPF = CPF;

            _usuarioService.Adicionar(user);

            // Application.Current.MainPage.Navigation.PushAsync(new SuaPaginaDeLogin()); // <-- Corrigido para um exemplo válido
        }

        void Consultar()
        {
            Usuario? user = _usuarioService.Consultar(); // A variável user pode ser nula

            // ADICIONE ESTA VERIFICAÇÃO
            if (user != null)
            {
                Nome = user.Nome;
                CPF = user.CPF;
                Email = user.Email;
                Senha = user.Senha;
                DataNascimento = user.DataNascimento;
            }
        }

        void ValidarLogin()
        {
            if (string.IsNullOrWhiteSpace(EmailDigitado) || string.IsNullOrWhiteSpace(SenhaDigitada))
            {
                Application.Current.MainPage.DisplayAlert("Erro", "Por favor, preencha o email e a senha.", "OK");
                return;
            }

            // <-- CORREÇÃO: Agora _usuarioService existe e pode ser usado.
            Usuario usuarioCadastrado = _usuarioService.ConsultarPorEmail(EmailDigitado);

            if (usuarioCadastrado == null)
            {
                Application.Current.MainPage.DisplayAlert("Erro", "Usuário não encontrado.", "OK");
                return;
            }

            if (usuarioCadastrado.Senha == SenhaDigitada)
            {
                Application.Current.MainPage.DisplayAlert("Sucesso", $"Bem-vindo, {usuarioCadastrado.Nome}!", "OK");
                // Navegar para a próxima tela
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Erro", "Senha incorreta.", "OK");
            }
        }

        // --- CONSTRUTOR ---
        public UsuarioViewModel()
        {
            CommandCadastrarUsuario = new Command(CadastrarUsuario);
            CommandConsultarUsuario = new Command(Consultar);
            // <-- CORREÇÃO: Adicionada a inicialização do comando de login.
            CommandValidacaoLogin = new Command(ValidarLogin);
        }
    }
}
