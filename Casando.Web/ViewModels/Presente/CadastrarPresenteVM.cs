using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Casando.Web.ViewModels.Presente
{
    public class CadastrarPresenteVM
    {
        [Display(Name = "Presente")]
        public string Nome { get; set; }
        [Display(Name = "Nome do Site")]
        public string SiteNome { get; set; }
        [Display(Name = "URL")]
        public string Url { get; set; }
        [Display(Name = "Preço")]
        public decimal Valor { get; set; }
    }
}