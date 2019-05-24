using Microsoft.AspNetCore.Mvc;
using WebMVC.Repositorios;

namespace WebMVC.Controllers
{
    public class MusicaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string nome)
        {
            ViewData["Mensagem"] = "Olá" + nome + ", estas são as suas músicas";

            return View(MusicaRepositorio.musicas);
        }
    }
}