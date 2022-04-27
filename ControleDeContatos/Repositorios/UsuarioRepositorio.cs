using ControleDeContatos.Models;
using ControleDeContatos.Models.Data;

namespace ControleDeContatos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            this.bancoContext = bancoContext;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return bancoContext.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            bancoContext.Usuarios.Add(usuario);
            bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro na atualização do usuário");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Login = usuario.Login;
            usuario.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;

            bancoContext.Usuarios.Update(usuarioDb);
            bancoContext.SaveChanges();

            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro ao apagar usuário!");

            bancoContext.Usuarios.Remove(usuarioDb);
            bancoContext.SaveChanges();

            return true;
        }
    }
}
