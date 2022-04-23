using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorios
{
    public interface IContatoRepositorio
    {
        ContatoModel Adicionar(ContatoModel contato);
    }
}
