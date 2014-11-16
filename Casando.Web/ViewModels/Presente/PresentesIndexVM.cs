using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Casando.Core.Modelos;

namespace Casando.Web.ViewModels.Presente
{
    public class PresentesIndexVM
    {
        public Dictionary<string, IEnumerable<CotacaoPresente>> PresentesComCotacoes { get; set; }
        public decimal TotalEmDinheiro { get; set; }
    }
}