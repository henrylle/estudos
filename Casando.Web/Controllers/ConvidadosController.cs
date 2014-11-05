using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Casando.Core.Interfaces;
using Casando.Core.Modelos;
using Casando.Data;
using Casando.Web.ViewModels.Convidado;

namespace Casando.Web.Controllers
{
    public class ConvidadosController : Controller
    {
        private readonly IConvidadosRepositorio convidadosRepositorio;

        public ConvidadosController(IConvidadosRepositorio convidadosRepositorio)
        {
            this.convidadosRepositorio = convidadosRepositorio;
        }

        // GET: Convidados
        public ActionResult Index()
        {
            var convidados = convidadosRepositorio.Todos();
            return View(convidados);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new CadastrarConvidadoVM());
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastrarConvidadoVM model)
        {
            var entidadeConvidado = Mapper.Map<CadastrarConvidadoVM, Convidado>(model);

            convidadosRepositorio.Inclui(entidadeConvidado);

            return RedirectToAction("Index","Convidados");
        }

        [HttpGet]
        public ActionResult Resumo()
        {
            return View(convidadosRepositorio.Totais());
        }

        [HttpGet]
        public JsonResult Teste()
        {
            return Json(convidadosRepositorio.Todos(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SalvaTeste(Convidado obj)
        {
            return HttpNotFound();
        }


        public ActionResult Knockout()
        {
            return View();
        }

    }
}