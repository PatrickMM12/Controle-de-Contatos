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

        public UsuarioModel BuscarPorLogin(string login)
        {
            return bancoContext.Usuarios.FirstOrDefault(u => u.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorEmailELogin(string email, string login)
        {
            return bancoContext.Usuarios.FirstOrDefault(u => u.Email.ToUpper() == email.ToUpper() && u.Login.ToUpper() == login.ToUpper());
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
            usuario.SetSenhaHash();
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
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAtualizacao = DateTime.Now;

            bancoContext.Usuarios.Update(usuarioDb);
            bancoContext.SaveChanges();

            return usuarioDb;
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListarPorId(alterarSenhaModel.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere!");

            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizacao = DateTime.Now;

            bancoContext.Usuarios.Update(usuarioDB);
            bancoContext.SaveChanges();

            return usuarioDB;
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
