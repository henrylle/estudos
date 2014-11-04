using System.Collections.Generic;
using System.Linq;
using Casando.Core.Modelos;

namespace Casando.Core.Interfaces
{
    public interface ICotacaoPresenteRepositorio : IRepositorio<CotacaoPresente>
    {
        Dictionary<string, IEnumerable<CotacaoPresente>> PresentesComCotacoes();
    }
}
