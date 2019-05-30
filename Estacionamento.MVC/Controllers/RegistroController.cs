using System;
using Estacionamento.MVC.Models;
using Estacionamento.MVC.Repositorio;
using Estacionamento.MVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estacionamento.MVC.Controllers
{
    public class RegistroController : Controller
    {
        RegistroRepositorio registroRepositorio = new RegistroRepositorio();
        MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        ModeloRepositorio modeloRepositorio = new ModeloRepositorio();

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
        [HttpPost]
         public IActionResult Registrar(IFormCollection form)
         {
             RegistroModel registro = new RegistroModel(
                 nome: form["nome"],
                 placa: form["placa"]
             );
             MarcaModel marca = new MarcaModel(
                 marca: form["marca"]
             );
             registro.Marca = marca;

             ModeloModel modelo = new ModeloModel(
                 modelo: form["modelo"]
             );
             registro.Modelo = modelo;
             registro.DataDeEntrada = DateTime.Parse(form["dataDeEntrada"]);

             registroRepositorio.Cadastrar(registro);

             return RedirectToAction("Listar", "Registro"); 
         }
          [HttpGet]
        public IActionResult Listar(){
            RegistroRepositorio registroRepositorio = new RegistroRepositorio();
            ViewData["registros"] = registroRepositorio.Listar();

            return View();
        }
    }
}