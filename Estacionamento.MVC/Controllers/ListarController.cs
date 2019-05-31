using Estacionamento.MVC.Repositorio;
using Estacionamento.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.MVC.Controllers {
    public class ListarController : Controller{
        RegistroRepositorio registroRepositorio = new RegistroRepositorio();
        MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();

        [HttpGet]
        public IActionResult Index () {
            var registros = registroRepositorio.Listar ();
            RegistroViewModel registroViewModel = new RegistroViewModel ();
            registroViewModel.Registros = registros;

            return View (registroViewModel);
        }
    }
}