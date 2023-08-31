using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using ATV_2.Models;

namespace ATV_2.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            usuarioRepo.Inserir(usuario);
            ViewBag.Mensagem = "Cadastro realizado com sucesso!";
            
            return View();
        }

        public IActionResult Lista()
        {
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            List<Usuario> listagemDeUsuarios = usuarioRepo.Listar();
            
            return View(listagemDeUsuarios);
        }

public IActionResult Remover(int Id)
{
    UsuarioRepository usuarioRepo = new UsuarioRepository();
    Usuario usuarioLocalizado = usuarioRepo.BuscarPorId(Id);

    if (usuarioLocalizado != null)
    {
        usuarioRepo.Excluir(usuarioLocalizado);
    }

    return RedirectToAction("Lista", "Usuario");
}

        public IActionResult Editar(int Id)
        {
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            Usuario usuarioLocalizado = usuarioRepo.BuscarPorId(Id);

            return View(usuarioLocalizado);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            usuarioRepo.Alterar(usuario);

            return RedirectToAction("Lista", "Usuario");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            UsuarioRepository usuarioRepo = new UsuarioRepository();
            Usuario usuarioLocalizado = usuarioRepo.ValidarLogin(usuario);

            if (usuarioLocalizado == null)
            {
                ViewBag.Mensagem = "Login ou Senha estão incorretos.";
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("Id", usuarioLocalizado.Id);
                HttpContext.Session.SetString("NomeUsuario", usuarioLocalizado.Nome);

                return RedirectToAction("Lista", "Usuario");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}