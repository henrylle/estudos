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
        public ActionResult IndexJson()
        {
            return Json(cotacaoPresenteRepositorio.PresentesComCotacoes(), JsonRequestBehavior.AllowGet);
        }
    }
}