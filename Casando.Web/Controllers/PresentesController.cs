using System;
using System.Linq;
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
            var a = cotacaoPresenteRepositorio.PresentesComCotacoes();
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
            
            return View();
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

        [HttpGet]
        public ActionResult IndexJson()
        {
            return Json(cotacaoPresenteRepositorio.PresentesComCotacoes(), JsonRequestBehavior.AllowGet);
        }
    }
}