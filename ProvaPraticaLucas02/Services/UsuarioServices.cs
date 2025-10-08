using ProvaPraticaLucas02.Models;

namespace ProvaPraticaLucas02.Services
{
        public class UsuarioServices
    {
        // Pegar instancia do DB
        private readonly FakeDBSingleton _dBSingleton = FakeDBSingleton.Instancia;
      
        public void Adicionar(Usuario value)
        {
            _dBSingleton.usuario = value;
        }
       
        public Usuario Consultar()
        {
            return _dBSingleton.usuario;
        }

        public Usuario ConsultarPorEmail(string email)
        {
            var usuarioCadastrado = _dBSingleton.usuario;


            if (usuarioCadastrado != null && usuarioCadastrado.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
            { 
                return usuarioCadastrado;
            }

            return null;
        }
    }
}
