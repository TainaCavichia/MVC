using System;
using hamburgueriaMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hamburgueriaMVC.Controllers
{
    public class CadastroController
    {
        public IActionResult Index()
        {
            ViewData
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = form["nome"];
            cliente.Endereco = form["endereco"];
            cliente.Telefone = form["telefone"];
            cliente.Senha = form["senha"];
            cliente.Email = form["email"];
            cliente.DataNascimento = DateTime.Parse(form["data-nascimento"]);

            clienteRepositorio.Inserir(cliente);
            ViewData["Action"] = "Cadastro";
            return View("Sucesso");
        }
    }
}