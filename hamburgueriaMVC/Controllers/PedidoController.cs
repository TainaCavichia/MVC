using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using hamburgueriaMVC.Models;
using System;
using hamburgueriaMVC.Repositorios;
using hamburgueriaMVC.ViewModels;

namespace hamburgueriaMVC.Controllers
{
    public class PedidoController : Controller
    {
        PedidoRepositorio pedidoRepositorio = new PedidoRepositorio();

        HamburguerRepositorio hamburguerRepositorio = new HamburguerRepositorio();

        ShakeRepositorio shakeRepositorio = new ShakeRepositorio();
        
        [HttpGet]
        public IActionResult Index()
        {
            var hamburgueres = hamburguerRepositorio.Listar();
            var shakes = shakeRepositorio.Listar();

            PedidoViewModel pedido = new PedidoViewModel();
            pedido.Hamburgueres = hamburgueres;
            pedido.Shakes = shakes;

            return View(pedido); 
        }   
        [HttpPost]
        public IActionResult RegistrarPedido(IFormCollection form)
        {
            System.Console.WriteLine(form["nome"]);
            System.Console.WriteLine(form["endereco"]);
            System.Console.WriteLine(form["telefone"]);
            System.Console.WriteLine(form["email"]);
            System.Console.WriteLine(form["hamburguer"]);
            System.Console.WriteLine(form["shake"]);


            Pedido pedido = new Pedido();
            //INSTANCIAR OBJETO - forma 1
            Cliente cliente = new Cliente();
            cliente.Nome = form["nome"];
            cliente.Endereco = form["endereco"];
            cliente.Telefone = form["telefone"];
            cliente.Email = form["email"];
            
            pedido.Cliente = cliente;

            //INSTANCIAR OBJETO - geração de construtor
            Hamburguer hamburguer = new Hamburguer(
                Nome: form["hamburguer"],
                Preco: hamburguerRepositorio.ObterPrecoDe(form["hamburguer"])
            );
            pedido.Hamburguer = hamburguer;
            

            //INSTANCIAR OBJETO - resumo da forma 1
            Shake shake = new Shake(){
                Nome = form["shake"],
                Preco = shakeRepositorio.ObterPrecoDe(form["shake"])
            };
            pedido.Shake = shake;
            pedido.PrecoTotal = pedido.Hamburguer.Preco + pedido.Shake.Preco;
            pedido.DataPedido = DateTime.Now;

            pedidoRepositorio.Inserir(pedido);

            ViewData["Controller"] = "Pedido";

            return View("Sucesso");
        }

    }
}