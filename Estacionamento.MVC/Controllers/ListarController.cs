using Estacionamento.MVC.Repositorio;
using Estacionamento.MVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.MVC.Controllers {
    public class ListarController : Controller{
        RegistroRepositorio registroRepositorio = new RegistroRepositorio();
        MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        RegistroViewModel registroViewModel = new RegistroViewModel ();

        [HttpGet]
        public IActionResult Index () {
            var registros = registroRepositorio.Listar ();
            registroViewModel.Registros = registros;

            return View (registroViewModel);
        }
        public IActionResult FiltrarRegistros(IFormCollection form){
            
            string data = form["data"];

            registroViewModel.Registros = registroRepositorio.Filtrar(data);

            return View(registroViewModel);
        }
    }
}