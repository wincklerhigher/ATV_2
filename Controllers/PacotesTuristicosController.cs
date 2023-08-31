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
    public class PacotesTuristicosController : Controller
    {        
        [HttpGet]
        public IActionResult CadastroPacote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroPacote(PacotesTuristicos pacote)
        {

            PacotesTuristicosRepository pacotesRepo = new PacotesTuristicosRepository();
            ViewBag.UsuarioValido = pacotesRepo.UsuarioValido(pacote.Usuario);

    if (ViewBag.UsuarioValido)
    {
            pacotesRepo.Inserir(pacote);
            ViewBag.Mensagem = "Cadastro de pacote realizado com sucesso!";
    }
    else
    {
            ViewBag.Mensagem = "Usuário não encontrado. Não foi possível cadastrar o pacote.";
    }

            return View();     }

        public IActionResult ListaPacotes()
        {
            PacotesTuristicosRepository pacotesRepo = new PacotesTuristicosRepository();
            List<PacotesTuristicos> listagemDePacotes = pacotesRepo.Listar();
            
            return View(listagemDePacotes);
        }

        public IActionResult RemoverPacote(int Id)
        {
            PacotesTuristicosRepository pacotesRepo = new PacotesTuristicosRepository();
            PacotesTuristicos pacoteLocalizado = pacotesRepo.BuscarPorId(Id);
            pacotesRepo.Excluir(pacoteLocalizado);

            return RedirectToAction("ListaPacotes", "PacotesTuristicos");
        }

        public IActionResult EditarPacote(int Id)
        {
            PacotesTuristicosRepository pacotesRepo = new PacotesTuristicosRepository();
            PacotesTuristicos pacoteLocalizado = pacotesRepo.BuscarPorId(Id);

            return View(pacoteLocalizado);
        }

        [HttpPost]
        public IActionResult EditarPacote(PacotesTuristicos pacote)
        {
            PacotesTuristicosRepository pacotesRepo = new PacotesTuristicosRepository();
            pacotesRepo.Alterar(pacote);

            return RedirectToAction("ListaPacotes", "PacotesTuristicos");
        }
    }
}        