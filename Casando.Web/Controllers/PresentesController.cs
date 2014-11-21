using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Casando.Core.Interfaces;
using Casando.Core.Modelos;
using Casando.Web.ViewModels.Presente;

namespace Casando.Web.Controllers
{
    public class PresentesController : Controller
    {
        private readonly IPresentesRepositorio presenteRepositorio;
        private readonly ICotacaoPresenteRepositorio cotacaoPresenteRepositorio;

        public PresentesController(IPresentesRepositorio presenteRepositorio, ICotacaoPresenteRepositorio cotacaoPresenteRepositorio)
        {
            this.presenteRepositorio = presenteRepositorio;
            this.cotacaoPresenteRepositorio = cotacaoPresenteRepositorio;
        }

        // GET: Presentes
        public ActionResult Index()
        {
            var model = new PresentesIndexVM
            {
                PresentesComCotacoes = cotacaoPresenteRepositorio.PresentesComCotacoes(),
                TotalEmDinheiro = presenteRepositorio.TotalEmDinheiro()
            };

            //return View(cotacaoPresenteRepositorio.PresentesComCotacoes());
            return View(model);
        }

        public ActionResult ConvidadoIndex()
        {
            return View(cotacaoPresenteRepositorio.PresentesComCotacoes());
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Cadastrar(CadastrarPresenteVM model)
        {
            var presente = Mapper.Map<CadastrarPresenteVM, Presente>(model);
            presenteRepositorio.Inclui(presente);

            return RedirectToAction("Index", "Presente");
        }

        [HttpGet]
        public ActionResult NovaCotacao(int id)
        {
            var presente = presenteRepositorio.Buscar(id);

            var viewModel = new NovaCotacaoVM
            {
                NomePresente = presente.Nome,
                PresenteId = presente.Id
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult NovaCotacao(NovaCotacaoVM model)
        {
            if (ModelState.IsValid)
            {
                var cotacao = Mapper.Map<NovaCotacaoVM, CotacaoPresente>(model);
                cotacaoPresenteRepositorio.Inclui(cotacao);

                return RedirectToAction("Index", "Presentes");
            }

            return View(model);
        }
        
        [HttpGet]
        public ActionResult ExcluirCotacao(int id)
        {
            cotacaoPresenteRepositorio.Exclui(id);

            return RedirectToAction("Index", "Presentes");
        }

        [HttpPost]
        public ActionResult Novo(CadastrarPresenteVM model)
        {
            try
            {
                var presente = Mapper.Map<CadastrarPresenteVM, Presente>(model);
                presenteRepositorio.Inclui(presente);

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpGet]
        public ActionResult AssociarConvidado(int presenteId)
        {
            return View(presenteRepositorio.Buscar(presenteId));
        }

        [HttpGet]
        public ActionResult Todos()
        {
            var aa = cotacaoPresenteRepositorio.PresentesComCotacoes();

            return Json( aa.Select(
                    x => new
                    {
                        Nome = x.Key,
                        Cotacoes = x.Value
                    }
                ), JsonRequestBehavior.AllowGet);

            return Json(cotacaoPresenteRepositorio.PresentesComCotacoes(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult IndexJson()
        {
            return Json(cotacaoPresenteRepositorio.PresentesComCotacoes(), JsonRequestBehavior.AllowGet);
        }
    }
}