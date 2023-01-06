using SenaiUC17.Models;

namespace SenaiUC17.Interface_s
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario novoUsuario);
        void Atualizar(int id, Usuario usuario);
        void Deletar(int id);
        Usuario Login(string email, string senha);
    }
}
