using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casando.Web.ViewModels.Convidado
{
    public class ResumoConvitesVM
    {
        public IDictionary<string, int> Resumo { get; set; }

        public int Total
        {
            get { return Resumo.Values.Sum(); }
        }
    }
}