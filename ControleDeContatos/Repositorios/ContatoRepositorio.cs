﻿using ControleDeContatos.Models;
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
    }
}