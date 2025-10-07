using ProvaPraticaLucas02.Models;


namespace ProvaPraticaLucas02.Services
{
        public class UsuarioServices
    {
        // Pega a instância única do seu "banco de dados".
        private readonly FakeDBSingleton _dBSingleton = FakeDBSingleton.Instancia;

        // Seu método Adicionar está correto para o requisito: ele substitui o usuário.
        public void Adicionar(Usuario value)
        {
            _dBSingleton.usuario = value;
        }

        // Seu método Consultar está correto: ele retorna o único usuário que existe.
        public Usuario Consultar()
        {
            return _dBSingleton.usuario;
        }

        // --- MÉTODO CORRIGIDO ---
        // Agora ele funciona com a sua estrutura de um único usuário.
        public Usuario ConsultarPorEmail(string email)
        {
            // 1. Pega o único usuário que está salvo no Singleton.
            var usuarioCadastrado = _dBSingleton.usuario;

            // 2. Verifica se existe um usuário cadastrado E se o email dele
            //    é igual ao email que o usuário digitou no login.
            if (usuarioCadastrado != null && usuarioCadastrado.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
            {
                // 3. Se as condições forem verdadeiras, retorna o usuário encontrado.
                return usuarioCadastrado;
            }

            // 4. Se não houver usuário ou se os emails forem diferentes, retorna nulo.
            return null;
        }
    }
}
