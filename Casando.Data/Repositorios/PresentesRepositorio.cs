using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Casando.Core.Interfaces;
using Casando.Core.Modelos;
using Casando.Data.Interfaces;

namespace Casando.Data.Repositorios
{
    public class PresentesRepositorio : Repositorio<Presente>, IPresentesRepositorio
    {
        public PresentesRepositorio(IUnitOfWork<CasandoContext> unitOfWork)
            :base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<IEnumerable<CotacaoPresente>> TodosAgrupados()
        {
            return unitOfWork.Context.Presentes.GroupBy(p => p.Nome).SelectMany(x => x.Select(p => p.Cotacoes));
        }

        public IQueryable<Presente> BuscaPorNome(string nome)
        {
            return unitOfWork.Context.Presentes.Where(p => p.Nome == nome);
        }

        public decimal TotalEmDinheiro()
        {
            return unitOfWork.Context.Presentes.Sum(p => p.Cotacoes.Select(c => c.Valor).Min());
        }
    }
}
