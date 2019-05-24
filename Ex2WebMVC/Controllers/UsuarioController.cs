using System;
using Ex2WebMVC.Models;
using Ex2WebMVC.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ex2WebMVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Index(){
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form){
            UsuarioModel usuario = new UsuarioModel(
            nome: form["nome"],
            email: form["email"],
            senha: form["senha"],
            dataNascimento: DateTime.Parse(form["dataNascimento"])
            );
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            usuarioRepositorio.Cadastrar(usuario); 

            TempData["mensagem"] = "Usuario cadastrado com sucesso";
            return RedirectToAction("Listar","Usuario");
        }
        [HttpGet]
        public IActionResult Listar(){
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            ViewData["usuarios"] = usuarioRepositorio.Listar();

            return View();
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            UsuarioModel usuarioRetornado = usuarioRepositorio.BuscarPorId(id);

            if (usuarioRetornado != null)
            {
                ViewBag.usuario = usuarioRetornado;
            }else
            {
                TempData["mensagem"] = "Usuário não encontrado";
                return RedirectToAction("Listar");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Editar(IFormCollection form){
            UsuarioModel usuario = new UsuarioModel(
            id: int.Parse(form["id"]),
            nome: form["nome"],
            email: form["email"],
            senha: form["senha"],
            dataNascimento: DateTime.Parse(form["dataNascimento"])
            );
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            usuarioRepositorio.Editar(usuario);

            TempData["mensagem"] = "Usuario editado com sucesso";
            return RedirectToAction("Listar");
        }
        public IActionResult Excluir(int id)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            usuarioRepositorio.Excluir(id);

            TempData["mensagem"] = "Usuário excluido com sucesso";
            return RedirectToAction("Listar");
        }
    }
}