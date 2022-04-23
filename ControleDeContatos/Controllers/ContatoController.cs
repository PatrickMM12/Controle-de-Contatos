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
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
