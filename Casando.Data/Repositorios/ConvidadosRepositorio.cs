using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Casando.Core.Interfaces;
using Casando.Core.Modelos;
using Casando.Data.Interfaces;

namespace Casando.Data.Repositorios
{
    public class ConvidadosRepositorio : Repositorio<Convidado>, IConvidadosRepositorio
    {
        public ConvidadosRepositorio(IUnitOfWork<CasandoContext> unitOfWork) 
            :base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IDictionary<string, int> Totais()
        {
            return unitOfWork.Context.Convidados
                        .GroupBy(c => c.TipoConvidado)
                        .ToDictionary(c => c.Key.ToString(), c => c.Sum(x => x.NumeroDeExibiveis));
        }

        public IQueryable<int> TotalDeConvites()
        {
            return unitOfWork.Context.Convidados
                .GroupBy(c => c.TipoConvidado)
                .Select(c => c.Count(x => x.ComConvite));
        }
        
        public IQueryable<Convidado> TodosPorTipo(Core.Enums.TipoConvidado tipo)
        {
            return unitOfWork.Context.Convidados.Where(c => c.TipoConvidado == tipo).OrderBy(c => c.Nome);
        }
    }
}
