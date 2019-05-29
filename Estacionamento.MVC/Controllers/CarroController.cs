using System;
using Estacionamento.MVC.Models;
using Estacionamento.MVC.Repositorio;
using Estacionamento.MVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.MVC.Controllers
{
    public class CarroController : Controller
    {
        MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();

        [HttpGet]
         public IActionResult Cadastrar(IFormCollection form)
         {
             RegistroModel carro = new RegistroModel(
                 nome: form["nome"],
                 marca: form["marca"],
                 modelo: form["modelo"],
                 placa: form["placa"],
                 dataDeEntrada: DateTime.Parse(form["dataDeEntrada"])
             );
             CarroRepositorio carroRepositorio = new CarroRepositorio();
             carroRepositorio.Cadastrar(carro);

             return RedirectToAction("Listar", "Carro"); 
         }
         [HttpGet]
         public IActionResult Index()
         {
             var marcas = marcaRepositorio.Listar();
             var modelos = modeloRepositorio.Listar();

             RegistroViewModel registro = new RegistroViewModel();
             registro.Marcas = marcas;
             registro.Modelos = modelos;

             return View(registro);
         }
          [HttpGet]
        public IActionResult Listar(){
            CarroRepositorio carroRepositorio = new CarroRepositorio();
            ViewData["carros"] = carroRepositorio.Listar();

            return View();
        }
    }
}