using ControleDeContatos.Models;
using ControleDeContatos.Models.Data;

namespace ControleDeContatos.Repositorios
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            this.bancoContext = bancoContext;
        }

        public ContatoModel ListarPorId(int id)
        {
            return bancoContext.Contatos.FirstOrDefault(c => c.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            bancoContext.Contatos.Add(contato);
            bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);

            if (contatoDb == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            bancoContext.Contatos.Update(contatoDb);
            bancoContext.SaveChanges();

            return contatoDb;
        }
    }
}
