using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorios
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();

        ContatoModel Adicionar(ContatoModel contato);
    }

}
