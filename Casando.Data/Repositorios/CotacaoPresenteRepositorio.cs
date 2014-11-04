using System.Collections.Generic;
using System.Linq;
using Casando.Core.Interfaces;
using Casando.Core.Modelos;
using Casando.Data.Interfaces;

namespace Casando.Data.Repositorios
{
    public class CotacaoPresenteRepositorio : Repositorio<CotacaoPresente>, ICotacaoPresenteRepositorio
    {
        public CotacaoPresenteRepositorio(IUnitOfWork<CasandoContext> unitOfWork) 
            : base(unitOfWork)
        {
        }

        public Dictionary<string, IEnumerable<CotacaoPresente>> PresentesComCotacoes()
        {
            return unitOfWork.Context.CotacaoPresentes.GroupBy(cp => cp.Presente.Nome)
                .ToDictionary(cp => cp.Key, cp => cp.Select(x => x));
        }
    }
}
