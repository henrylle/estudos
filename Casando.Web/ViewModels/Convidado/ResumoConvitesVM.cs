using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casando.Web.ViewModels.Convidado
{
    public class ResumoConvitesVM
    {
        public IDictionary<string, int> Resumo { get; set; }
        public List<int> NumeroDeConvitesPorGrupo { get; set; }

        public int TotalExibiveis
        {
            get { return Resumo.Values.Sum(); }
        }

        public int TotalConvites
        {
            get { return NumeroDeConvitesPorGrupo.Sum(); }
        }

    }
}