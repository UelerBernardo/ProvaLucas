using ProvaPraticaLucas02.Models;
using ProvaPraticaLucas02.Services;
using System.Windows.Input;
using ProvaPraticaLucas02.Views;

namespace ProvaPraticaLucas02.ViewModels
{
    public partial class UsuarioViewModel : BaseViewModels
    {
      
        UsuarioServices usuarioServices = new UsuarioServices();
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
        private string _datanascimento = string.Empty;
        private string _email = string.Empty;
        private string _senha = string.Empty;

        public string Cpf { get => _cpf; set { _cpf = value; OnPropertyChanged(); } }
        public string Nome { get => _nome; set { _nome = value; OnPropertyChanged(); } }
        public string Email { get => _email; set { _email = value; OnPropertyChanged(); } }
        public string Senha { get => _senha; set { _senha = value; OnPropertyChanged(); } }
        public string DataNascimento { get => _datanascimento; set { _datanascimento = value; OnPropertyChanged(); } }

        // --- COMANDOS ---
        public ICommand CommandCadastrarUsuario { get; set; }
        public ICommand CommandConsultarUsuario { get; set; }
        public ICommand CommandValidacaoLogin { get; set; }
        public ICommand CommandVisualizarUsuario { get; set; }
        public ICommand CommandAtualizarUsuario { get; set; }
        public ICommand CommandAbrirCadastro { get; set; }

        // --- MÉTODOS DOS COMANDOS ---

        void AbrirCadastro()
        {
            AbrirView(new pgCadastroView());
        }
        void CadastrarUsuario()
        {
            Usuario user = new Usuario();
            user.Nome = Nome;
            user.Email = Email;
            user.Cpf = Cpf;
            user.DataNascimento = DataNascimento;           
            user.Senha = Senha;


            usuarioServices.Adicionar(user);

            Voltar();
            Application.Current.MainPage.DisplayAlert("Informação",
                "Usuário Cadastrado com sucesso", "Ok");
        }

        void AtualizarUsuario()
        {
            AbrirView(new pgCadastroView());

            //Usuario? user = usuarioServices.Consultar();
            //if (user != null)
            //{
            //    Nome = user.Nome;
            //    Email = user.Email;
            //    Cpf = user.Cpf;
            //    DataNascimento = user.DataNascimento;
            //    Senha = user.Senha;
            //}
        }

        void Consultar()
        {
            Usuario? user = usuarioServices.Consultar();
         
            if (user != null)
            {
                Nome = user.Nome;
                Email = user.Email;
                Cpf = user.Cpf;
                DataNascimento = user.DataNascimento;
                Senha = user.Senha;              
            }
        }

        void Visualizar()
        {
            Usuario? user = usuarioServices.Consultar();

            if (user != null)
            {
                Nome = user.Nome;
            }
        }

        void ValidarLogin()
        {
            if (string.IsNullOrWhiteSpace(EmailDigitado) || string.IsNullOrWhiteSpace(SenhaDigitada))
            {
                Application.Current.MainPage.DisplayAlert("Erro", "Por favor, preencha o email e a senha.", "OK");
                return;
            }
           
            Usuario usuarioCadastrado = _usuarioService.ConsultarPorEmail(EmailDigitado);

            if (usuarioCadastrado == null)
            {
                Application.Current.MainPage.DisplayAlert("Erro", "Usuário não encontrado.", "OK");
                return;
            }

            if (usuarioCadastrado.Senha == SenhaDigitada)
            {
                Application.Current.MainPage.DisplayAlert("Sucesso", $"Bem Vindo! {usuarioCadastrado.Nome}", "OK");
                AbrirView(new pgPrincipalView());
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Erro", "Senha incorreta.", "OK");
            }
        }

        public UsuarioViewModel()
        {
            CommandCadastrarUsuario = new Command(CadastrarUsuario);
            CommandConsultarUsuario = new Command(Consultar);            
            CommandValidacaoLogin = new Command(ValidarLogin);
            CommandVisualizarUsuario = new Command(Visualizar);
            CommandAtualizarUsuario = new Command(AtualizarUsuario);
            CommandAbrirCadastro = new Command(AbrirCadastro);
        }
    }
}
