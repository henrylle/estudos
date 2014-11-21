using System.Collections;
using System.Collections.Generic;

namespace Casando.Core.Modelos
{
    public class Presente : EntidadeBase
    {
        public string Nome { get; set; }
        public virtual IList<CotacaoPresente> Cotacoes { get; set; }
        public virtual IList<Convidado> Compradores { get; set; }
    }
}
