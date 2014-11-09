using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Casando.Core.Enums;
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
            return View();
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
        public ActionResult Editar(int id)
        {
            return Json(convidadosRepositorio.Buscar(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Editar(Convidado convidado)
        {
            if (ModelState.IsValid)
            {
                convidadosRepositorio.Altera(convidado);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            try
            {
                convidadosRepositorio.Exclui(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, ex.Message);

                throw;
            }
        }



        [HttpGet]
        public ActionResult Resumo()
        {
            var resumoConvitesVM = new ResumoConvitesVM
            {
                Resumo = convidadosRepositorio.Totais(),
                NumeroDeConvitesPorGrupo = convidadosRepositorio.TotalDeConvites().ToList()
            };
            return View(resumoConvitesVM);
        }

        [HttpPost]
        public ActionResult Salvar(Convidado convidado)
        {
            try
            {
                convidadosRepositorio.Inclui(convidado);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, "Não foi possível cadastrar o Convidado.");
            }
        }

        public ActionResult PorCategoria(string obj)
        {
            var tipo = getTipoConvidado(obj);
            return Json(convidadosRepositorio.TodosPorTipo(tipo), JsonRequestBehavior.AllowGet);
        }

        private TipoConvidado getTipoConvidado(string tipo)
        {
            if(tipo.Equals("0")) return TipoConvidado.FamiliarNoiva;
            
            if(tipo.Equals("1")) return TipoConvidado.FamiliarNoivo;
            
            if(tipo.Equals("2")) return TipoConvidado.AmigosNoiva;

            return TipoConvidado.AmigosNoivo;
        }

    }
}