using ControleDeContatos.Models;
using ControleDeContatos.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{

    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            this.contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {

            if (ModelState.IsValid)
            {
                contatoRepositorio.Adicionar(contato);
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {

            if (ModelState.IsValid)
            {
                contatoRepositorio.Atualizar(contato);
                return RedirectToAction("Index");
            }

            return View(contato);
        }
    }
}
