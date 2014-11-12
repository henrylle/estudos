using System.Collections.Generic;
using System.Linq;
using Casando.Core.Modelos;

namespace Casando.Core.Interfaces
{
    public interface IPresentesRepositorio : IRepositorio<Presente>
    {
        IQueryable<IEnumerable<CotacaoPresente>> TodosAgrupados();
        IQueryable<Presente> BuscaPorNome(string nome);
    }
}
